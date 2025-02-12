using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinBoostPro
{
    public partial class LoadingForm : Form
    {
        private static readonly string NotionApiKey = "ntn_X873034169457Og2yNeAXKzhOIthrdhdLYrwExhxd1eanS";
        private static readonly string DatabaseId = "1852085e-713e-80de-ae1c-d615c0fcce72";

        public LoadingForm()
        {
            InitializeComponent();
        }

        private async void OnLoadingFormLoad(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("🔄 Début du chargement...");

                // ✅ Étape 1 : Récupération des commandes Notion
                await LoadNotionCommandsAsync();

                if (Program.Commands != null && Program.Commands.Count > 0)
                {
                    Console.WriteLine($"✅ {Program.Commands.Count} commandes récupérées depuis Notion :");
                    foreach (string command in Program.Commands)
                    {
                        Console.WriteLine($"📌 {command}");
                    }

                    // ✅ Étape 2 : Exécution des commandes PowerShell en temps réel
                    await ExecutePowerShellCommandsAsync();

                    // ✅ Vérification finale avant de passer à SuccessForm
                    Console.WriteLine("🎯 Toutes les commandes ont été exécutées avec succès ! Passage à SuccessForm...");

                    this.Invoke((MethodInvoker)delegate
                    {
                        this.Hide();
                        SuccessForm successForm = new SuccessForm();
                        successForm.StartPosition = FormStartPosition.CenterScreen;
                        successForm.TopMost = true;  // ✅ Pour éviter que la fenêtre soit cachée
                        successForm.Show();
                        Console.WriteLine("✅ SuccessForm affiché !");
                    });
                }
                else
                {
                    Console.WriteLine("⚠️ Aucune commande récupérée depuis Notion.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Erreur fatale : {ex}");
            }
        }

        private async Task LoadNotionCommandsAsync()
        {
            try
            {
                Console.WriteLine("🌐 Envoi de la requête API à Notion...");

                NotionHelper notionHelper = new NotionHelper(NotionApiKey);
                List<string> commands = await notionHelper.FetchCommandsAsync(DatabaseId);

                if (commands != null && commands.Count > 0)
                {
                    Program.Commands = commands;
                    Console.WriteLine($"✅ {commands.Count} commandes récupérées depuis Notion !");
                }
                else
                {
                    Console.WriteLine("⚠️ Aucune commande récupérée depuis Notion.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Erreur Notion API : {ex.Message}");
            }
        }

        private async Task ExecutePowerShellCommandsAsync()
        {
            if (Program.Commands == null || Program.Commands.Count == 0)
            {
                Console.WriteLine("⚠️ Aucune commande à exécuter.");
                return;
            }

            try
            {
                Console.WriteLine("🚀 Début de l'exécution des commandes PowerShell...");

                int totalCommands = Program.Commands.Count;
                int progressStep = progressBarLoading.Maximum / totalCommands; // Fraction de progression par commande

                foreach (string command in Program.Commands)
                {
                    Console.WriteLine($"🔹 Exécution de : {command}");

                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = "powershell.exe",
                        Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{command}\"",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    using (Process psProcess = new Process { StartInfo = psi })
                    {
                        psProcess.OutputDataReceived += (sender, e) =>
                        {
                            if (!string.IsNullOrEmpty(e.Data))
                                Console.WriteLine($"🟢 {e.Data}");
                        };

                        psProcess.ErrorDataReceived += (sender, e) =>
                        {
                            if (!string.IsNullOrEmpty(e.Data))
                                Console.WriteLine($"❌ {e.Data}");
                        };

                        psProcess.Start();
                        psProcess.BeginOutputReadLine();
                        psProcess.BeginErrorReadLine();
                        await Task.Run(() => psProcess.WaitForExit());
                    }

                    Console.WriteLine($"✅ Commande terminée : {command}\n");

                    // **Mise à jour de la barre de progression**
                    this.Invoke((MethodInvoker)delegate
                    {
                        progressBarLoading.Value = Math.Min(progressBarLoading.Value + progressStep, progressBarLoading.Maximum);
                    });

                    await Task.Delay(200); // Petit délai pour une transition fluide
                }

                Console.WriteLine("🎉 Toutes les commandes ont été exécutées !");

                // **Forcer la barre à 100% avant de passer à SuccessForm**
                this.Invoke((MethodInvoker)delegate
                {
                    progressBarLoading.Value = progressBarLoading.Maximum;
                });

                await Task.Delay(500); // Pause pour lisibilité avant le changement d'écran

                // **Passage automatique à SuccessForm**
                this.Invoke((MethodInvoker)delegate
                {
                    Console.WriteLine("🎯 Passage à SuccessForm...");
                    this.Hide();
                    SuccessForm successForm = new SuccessForm();
                    successForm.StartPosition = FormStartPosition.CenterScreen;
                    successForm.TopMost = true;
                    successForm.Show();
                    Console.WriteLine("✅ SuccessForm affiché !");
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Erreur PowerShell : {ex.Message}");
            }
        }
    }
}