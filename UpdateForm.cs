using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinBoostPro
{
    public partial class UpdateForm : Form
    {
        private static readonly string NotionApiKey = "ntn_X873034169457Og2yNeAXKzhOIthrdhdLYrwExhxd1eanS";
        private static readonly string DatabaseId = "1852085e-713e-80de-ae1c-d615c0fcce72";

        public UpdateForm()
        {
            InitializeComponent();
        }

        private async void UpdateForm_Load(object sender, EventArgs e)
        {
            label1.Text = "Téléchargement des mises à jour...";
            label1.Refresh();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            // ✅ Lancer la mise à jour
            await PerformUpdateAsync();

            // ✅ Affichage du message et fermeture d’UpdateForm
            this.Invoke((MethodInvoker)delegate
            {
                MessageBox.Show("Mise à jour terminée !", "WinBoost Pro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CloseUpdateForm();
            });
        }

        private async Task PerformUpdateAsync()
        {
            try
            {
                NotionHelper notionHelper = new NotionHelper(NotionApiKey);
                List<string> newCommands = await notionHelper.FetchCommandsAsync(DatabaseId);

                if (newCommands != null && newCommands.Count > 0)
                {
                    Program.Commands = newCommands;
                    int totalCommands = newCommands.Count;
                    int progressStep = progressBar1.Maximum / totalCommands;

                    foreach (var command in newCommands)
                    {
                        Console.WriteLine($"🔄 Téléchargement : {command}");

                        // ✅ Simulation du téléchargement pour l'effet progressif
                        for (int i = 0; i < progressStep; i++)
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                progressBar1.Value = Math.Min(progressBar1.Value + 1, progressBar1.Maximum);
                                progressBar1.Refresh();
                                Application.DoEvents();
                            });
                            await Task.Delay(30);
                        }
                    }

                    // ✅ Assurer que la barre est bien à 100% avant de fermer
                    this.Invoke((MethodInvoker)delegate
                    {
                        progressBar1.Value = progressBar1.Maximum;
                        label1.Text = "Mise à jour terminée !";
                        label1.Refresh();
                    });

                    await Task.Delay(500);
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        label1.Text = "Aucune mise à jour disponible.";
                        label1.Refresh();
                    });

                    await Task.Delay(1000);
                }
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show($"❌ Erreur lors de la mise à jour : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    label1.Text = "Échec de la mise à jour.";
                });
            }
        }

        // ✅ Fonction pour fermer proprement UpdateForm et laisser WinBoostPro en arrière-plan
        private void CloseUpdateForm()
        {
            this.Invoke((MethodInvoker)async delegate
            {
                await Task.Delay(500); // ✅ Laisse le message s'afficher avant de fermer
                this.Close(); // ✅ Ferme UpdateForm proprement
            });
        }
    }
}