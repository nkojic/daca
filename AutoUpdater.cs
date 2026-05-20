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
                string batch = "@echo off\r\n" +
                    "echo Ažuriranje u toku...\r\n" +
                    "timeout /t 3 /nobreak >nul\r\n" +
                    "xcopy /E /Y /Q \"" + sourceDir + "\\*\" \"" + appDir + "\"\r\n" +
                    "echo Ažuriranje završeno!\r\n" +
                    "start \"\" \"" + Path.Combine(appDir, "WpfAmsterdam.exe") + "\"\r\n" +
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
                    CreateNoWindow = true,
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Hidden
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
