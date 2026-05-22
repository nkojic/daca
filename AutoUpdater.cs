using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAmsterdam
{
    public static class AutoUpdater
    {
        private const string GitHubApiUrl = "https://api.github.com/repos/nkojic/daca/releases/latest";
        private static readonly HttpClient client = new HttpClient();

        static AutoUpdater()
        {
            client.DefaultRequestHeaders.Add("User-Agent", "WpfAmsterdam-Updater");
        }

        public static void CheckUpdateResult()
        {
            try
            {
                string markerPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "update_pending.txt");
                if (File.Exists(markerPath))
                {
                    string expectedVersion = File.ReadAllText(markerPath).Trim();
                    if (AppVersion.Current != expectedVersion)
                    {
                        MessageBox.Show(
                            "Ažuriranje na verziju " + expectedVersion + " nije uspelo.\n" +
                            "Trenutna verzija je još uvek " + AppVersion.Current + ".\n\n" +
                            "Preuzmite novu verziju ručno sa GitHub-a.",
                            "Ažuriranje neuspešno", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    File.Delete(markerPath);
                }
            }
            catch { }
        }

        public static async Task CheckForUpdatesAsync()
        {
            try
            {
                string json = await client.GetStringAsync(GitHubApiUrl);
                using (JsonDocument doc = JsonDocument.Parse(json))
                {
                    JsonElement root = doc.RootElement;
                    string latestTag = root.GetProperty("tag_name").GetString();
                    string latestVersion = latestTag.TrimStart('v');

                    if (IsNewerVersion(latestVersion, AppVersion.Current))
                    {
                        // Pronađi zip asset
                        string downloadUrl = null;
                        if (root.TryGetProperty("assets", out JsonElement assets))
                        {
                            foreach (JsonElement asset in assets.EnumerateArray())
                            {
                                string name = asset.GetProperty("name").GetString();
                                if (name.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
                                {
                                    downloadUrl = asset.GetProperty("browser_download_url").GetString();
                                    break;
                                }
                            }
                        }

                        if (downloadUrl == null) return;

                        DlgUpdatePrompt prompt = new DlgUpdatePrompt(
                            "Nova verzija " + latestVersion + " je dostupna!\n\n" +
                            "Trenutna verzija: " + AppVersion.Current + "\n" +
                            "Da li želite da ažurirate?");
                        prompt.ShowDialog();

                        if (prompt.Accepted)
                        {
                            await DownloadAndInstall(downloadUrl, latestVersion);
                        }
                    }
                }
            }
            catch
            {
                // Nema interneta ili greška - tiho ignorišemo
            }
        }

        private static bool IsNewerVersion(string latest, string current)
        {
            try
            {
                Version vLatest = new Version(latest);
                Version vCurrent = new Version(current);
                return vLatest > vCurrent;
            }
            catch
            {
                return false;
            }
        }

        private static async Task DownloadAndInstall(string url, string version)
        {
            DlgUpdateProgress progressDlg = null;
            try
            {
                string appDir = AppDomain.CurrentDomain.BaseDirectory;
                string tempZip = Path.Combine(Path.GetTempPath(), "WpfAmsterdam_update.zip");
                string tempExtract = Path.Combine(Path.GetTempPath(), "WpfAmsterdam_update");

                // Prikaži progress dijalog
                progressDlg = new DlgUpdateProgress();
                progressDlg.Show();

                byte[] data = await client.GetByteArrayAsync(url);
                File.WriteAllBytes(tempZip, data);

                progressDlg.SetStatus("Raspakivanje ažuriranja...");

                // Očisti temp folder
                if (Directory.Exists(tempExtract))
                    Directory.Delete(tempExtract, true);

                // Raspakuj
                ZipFile.ExtractToDirectory(tempZip, tempExtract);

                // Pronađi folder sa exe-om unutar zip-a
                string sourceDir = tempExtract;
                string[] exeFiles = Directory.GetFiles(tempExtract, "WpfAmsterdam.exe", SearchOption.AllDirectories);
                if (exeFiles.Length > 0)
                    sourceDir = Path.GetDirectoryName(exeFiles[0]);

                // Napravi batch skriptu za zamenu fajlova posle zatvaranja app
                string batchPath = Path.Combine(Path.GetTempPath(), "update_wpfamsterdam.bat");
                string logPath = Path.Combine(Path.GetTempPath(), "wpfamsterdam_update.log");
                string exePath = Path.Combine(appDir, "WpfAmsterdam.exe");
                string markerPath = Path.Combine(appDir, "update_pending.txt");
                int currentPid = Process.GetCurrentProcess().Id;

                // Zapiši marker fajl sa očekivanom novom verzijom
                File.WriteAllText(markerPath, version);

                string batch = "@echo off\r\n" +
                    "chcp 65001 >nul 2>&1\r\n" +
                    "title WpfAmsterdam - Azuriranje\r\n" +
                    "set LOGFILE=\"" + logPath + "\"\r\n" +
                    "echo === Update started %DATE% %TIME% > %LOGFILE%\r\n" +
                    "echo Source: \"" + sourceDir + "\" >> %LOGFILE%\r\n" +
                    "echo Dest:   \"" + appDir + "\" >> %LOGFILE%\r\n" +
                    "echo PID:    " + currentPid + " >> %LOGFILE%\r\n" +
                    "echo.\r\n" +
                    "echo ============================================\r\n" +
                    "echo   Azuriranje u toku... Ne zatvarajte prozor!\r\n" +
                    "echo ============================================\r\n" +
                    "echo.\r\n" +
                    "\r\n" +
                    "echo Cekanje da se proces " + currentPid + " zatvori... >> %LOGFILE%\r\n" +
                    ":WAIT_LOOP\r\n" +
                    "tasklist /FI \"PID eq " + currentPid + "\" 2>nul | find \"" + currentPid + "\" >nul\r\n" +
                    "if not errorlevel 1 (\r\n" +
                    "    timeout /t 1 /nobreak >nul\r\n" +
                    "    goto WAIT_LOOP\r\n" +
                    ")\r\n" +
                    "echo Proces zatvoren %TIME% >> %LOGFILE%\r\n" +
                    "\r\n" +
                    "echo Zaustavljanje svih instanci WpfAmsterdam... >> %LOGFILE%\r\n" +
                    "taskkill /F /IM WpfAmsterdam.exe >nul 2>&1\r\n" +
                    "timeout /t 3 /nobreak >nul\r\n" +
                    "\r\n" +
                    "echo Pokretanje robocopy... >> %LOGFILE%\r\n" +
                    "robocopy \"" + sourceDir + "\" \"" + appDir.TrimEnd('\\') + "\" /E /R:10 /W:3 >> %LOGFILE% 2>&1\r\n" +
                    "set RC=%ERRORLEVEL%\r\n" +
                    "echo Robocopy exit code: %RC% >> %LOGFILE%\r\n" +
                    "\r\n" +
                    "if %RC% GEQ 8 (\r\n" +
                    "    echo GRESKA pri kopiranju! Exit code: %RC% >> %LOGFILE%\r\n" +
                    "    echo.\r\n" +
                    "    echo GRESKA pri azuriranju! Pogledaj log: " + logPath + "\r\n" +
                    "    echo.\r\n" +
                    "    pause\r\n" +
                    "    exit /b 1\r\n" +
                    ")\r\n" +
                    "\r\n" +
                    "echo Azuriranje zavrseno uspesno %TIME% >> %LOGFILE%\r\n" +
                    "echo.\r\n" +
                    "echo Azuriranje zavrseno! Pokretanje aplikacije...\r\n" +
                    "del \"" + markerPath + "\" 2>nul\r\n" +
                    "start \"\" \"" + exePath + "\"\r\n" +
                    "del \"" + tempZip + "\" 2>nul\r\n" +
                    "rmdir /S /Q \"" + tempExtract + "\" 2>nul\r\n" +
                    "del \"%~f0\"\r\n";

                File.WriteAllText(batchPath, batch);

                // Zatvori progress dijalog
                progressDlg.Close();
                progressDlg = null;

                // Pokreni batch i zatvori app
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = batchPath,
                    CreateNoWindow = false,
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Normal
                };
                Process.Start(psi);

                // Zatvori app
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                progressDlg?.Close();
                MessageBox.Show("Greška pri ažuriranju: " + ex.Message,
                    "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
