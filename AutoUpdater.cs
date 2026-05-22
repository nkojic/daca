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

        /// <summary>
        /// Na startupu: obriši .old fajlove od prethodnog update-a
        /// </summary>
        public static void CleanupAfterUpdate()
        {
            try
            {
                string appDir = AppDomain.CurrentDomain.BaseDirectory;
                string[] oldFiles = Directory.GetFiles(appDir, "*.old", SearchOption.AllDirectories);
                foreach (string f in oldFiles)
                {
                    try { File.Delete(f); } catch { }
                }

                // Obriši update temp folder ako postoji
                string tempExtract = Path.Combine(Path.GetTempPath(), "WpfAmsterdam_update");
                if (Directory.Exists(tempExtract))
                {
                    try { Directory.Delete(tempExtract, true); } catch { }
                }

                string tempZip = Path.Combine(Path.GetTempPath(), "WpfAmsterdam_update.zip");
                if (File.Exists(tempZip))
                {
                    try { File.Delete(tempZip); } catch { }
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

                progressDlg.SetStatus("Preuzimanje ažuriranja...");
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

                progressDlg.SetStatus("Zamena fajlova...");

                // Zameni fajlove direktno - rename zaključanih, pa kopiraj nove
                int replaced = 0;
                int failed = 0;
                string logPath = Path.Combine(Path.GetTempPath(), "wpfamsterdam_update.log");
                using (var log = new StreamWriter(logPath, false))
                {
                    log.WriteLine("=== Update started " + DateTime.Now + " ===");
                    log.WriteLine("Source: " + sourceDir);
                    log.WriteLine("Dest:   " + appDir);
                    log.WriteLine("Version: " + AppVersion.Current + " -> " + version);
                    log.WriteLine();

                    ReplaceFiles(sourceDir, appDir, sourceDir, log, ref replaced, ref failed);

                    log.WriteLine();
                    log.WriteLine("Replaced: " + replaced + ", Failed: " + failed);
                    log.WriteLine("=== Update finished " + DateTime.Now + " ===");
                }

                progressDlg.Close();
                progressDlg = null;

                if (failed > 0)
                {
                    MessageBox.Show(
                        "Ažuriranje delimično uspelo (" + replaced + " fajlova zamenjeno, " + failed + " neuspelo).\n" +
                        "Pogledaj log: " + logPath,
                        "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                // Pokreni novu verziju aplikacije i zatvori trenutnu
                string exePath = Path.Combine(appDir, "WpfAmsterdam.exe");
                Process.Start(new ProcessStartInfo
                {
                    FileName = exePath,
                    UseShellExecute = true
                });

                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                progressDlg?.Close();
                MessageBox.Show("Greška pri ažuriranju: " + ex.Message,
                    "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private static void ReplaceFiles(string sourceDir, string destDir, string rootSourceDir, StreamWriter log, ref int replaced, ref int failed)
        {
            // Kopiraj fajlove
            foreach (string sourceFile in Directory.GetFiles(sourceDir))
            {
                string fileName = Path.GetFileName(sourceFile);
                string destFile = Path.Combine(destDir, fileName);

                try
                {
                    // Pokušaj direktno kopiranje
                    File.Copy(sourceFile, destFile, true);
                    replaced++;
                    log.WriteLine("OK: " + fileName);
                }
                catch
                {
                    // Fajl je zaključan - preimenuj stari pa kopiraj novi
                    try
                    {
                        string oldFile = destFile + ".old";
                        if (File.Exists(oldFile))
                            File.Delete(oldFile);
                        File.Move(destFile, oldFile);
                        File.Copy(sourceFile, destFile, true);
                        replaced++;
                        log.WriteLine("OK (rename): " + fileName);
                    }
                    catch (Exception ex2)
                    {
                        failed++;
                        log.WriteLine("FAIL: " + fileName + " - " + ex2.Message);
                    }
                }
            }

            // Rekurzivno za poddirektorijume
            foreach (string subDir in Directory.GetDirectories(sourceDir))
            {
                string dirName = Path.GetFileName(subDir);
                string destSubDir = Path.Combine(destDir, dirName);
                if (!Directory.Exists(destSubDir))
                    Directory.CreateDirectory(destSubDir);
                ReplaceFiles(subDir, destSubDir, rootSourceDir, log, ref replaced, ref failed);
            }
        }
    }
}
