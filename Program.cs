using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;
using System.Timers;
using System.Threading.Tasks;
using System.Drawing;

namespace WinBoostPro
{
    internal static class Program
    {
        public static List<string> Commands { get; internal set; } = new List<string>(); // ✅ Stockage global
        private static System.Timers.Timer updateTimer;
        private static readonly string NotionApiKey = "ntn_X873034169457Og2yNeAXKzhOIthrdhdLYrwExhxd1eanS";
        private static readonly string DatabaseId = "1852085e-713e-80de-ae1c-d615c0fcce72";

        [STAThread]
        static void Main()
        {
            // ✅ Vérification et élévation en administrateur
            if (!IsRunningAsAdministrator())
            {
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = Application.ExecutablePath,
                        UseShellExecute = true,
                        Verb = "runas" // ✅ Demande les droits admin
                    };
                    Process.Start(startInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Impossible de relancer en mode administrateur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return; // ✅ Quitte l'instance actuelle non admin
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ✅ Démarre la vérification automatique des mises à jour toutes les 24h
            StartUpdateChecker();

            // ✅ Suppression du chargement Notion ici (fait dans `LoadingForm`)
            Application.Run(new WelcomeForm());
        }

        private static bool IsRunningAsAdministrator()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        private static void StartUpdateChecker()
        {
            updateTimer = new System.Timers.Timer(30 * 1000); // ✅ Vérification toutes les 24h

            updateTimer.Elapsed += async (sender, e) => await CheckForUpdates();
            updateTimer.AutoReset = true;
            updateTimer.Start();
        }

        private static async Task CheckForUpdates()
        {
            try
            {
                Console.WriteLine("🔍 Vérification des mises à jour...");

                NotionHelper notionHelper = new NotionHelper(NotionApiKey);
                List<string> newCommands = await notionHelper.FetchCommandsAsync(DatabaseId);

                if (newCommands != null)
                {
                    if (Program.Commands == null || newCommands.Count > Program.Commands.Count)
                    {
                        Console.WriteLine("✅ Nouvelle mise à jour détectée !");
                        ShowUpdateDialog();
                    }
                    else
                    {
                        Console.WriteLine("⚠️ Aucune mise à jour trouvée.");
                    }
                }
                else
                {
                    Console.WriteLine("⚠️ Erreur : Impossible de récupérer les données Notion.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Erreur lors de la vérification des mises à jour : {ex.Message}");
            }
        }

        private static void ShowUpdateDialog()
        {
            Application.OpenForms[0]?.Invoke(new Action(() =>
            {
                Form updateForm = new Form
                {
                    Text = "Mise à jour disponible",
                    Size = new Size(350, 200),
                    StartPosition = FormStartPosition.CenterScreen,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    MinimizeBox = false,
                    TopMost = true
                };

                Label messageLabel = new Label
                {
                    Text = "Une mise à jour est disponible.\nVoulez-vous l'installer maintenant ?",
                    AutoSize = false,
                    Size = new Size(300, 50),
                    Location = new Point(25, 20),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                Button updateButton = new Button
                {
                    Text = "Mettre à jour",
                    Size = new Size(120, 30),
                    Location = new Point(50, 90)
                };
                updateButton.Click += (s, e) =>
                {
                    updateForm.Close(); // Ferme la boîte de dialogue
                    Task.Run(() => LaunchUpdate()); // Exécute la mise à jour sans bloquer l'UI
                };

                Button laterButton = new Button
                {
                    Text = "Plus tard",
                    Size = new Size(120, 30),
                    Location = new Point(180, 90)
                };
                laterButton.Click += (s, e) => updateForm.Close(); // ✅ Ferme juste la fenêtre

                updateForm.Controls.Add(messageLabel);
                updateForm.Controls.Add(updateButton);
                updateForm.Controls.Add(laterButton);
                updateForm.ShowDialog();
            }));
        }

        private static void LaunchUpdate()
        {
            Application.OpenForms[0]?.Invoke(new Action(() =>
            {
                Console.WriteLine("🔄 Lancement de la mise à jour...");
                UpdateForm updateForm = new UpdateForm
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    TopMost = true
                }; // ✅ Ouvre `UpdateForm`
                updateForm.ShowDialog(); // ✅ Ouvre en mode bloquant jusqu'à la fin

                // ✅ Une fois `UpdateForm` fermé, passe à `LoadingForm`
                LoadingForm loadingForm = new LoadingForm
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    TopMost = true
                };
                loadingForm.Show();
            }));
        }
    }
}