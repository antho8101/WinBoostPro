using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinBoostPro
{
    public partial class BackupForm : Form
    {
        public BackupForm()
        {
            InitializeComponent();
        }

        private async void CreateBackupButton_Click(object sender, EventArgs e)
        {
            try
            {
                string checkProtectionCommand = "Get-ComputerRestorePoint";
                string createBackupCommand = "Checkpoint-Computer -Description 'WinBoost Backup' -RestorePointType 'Modify_Settings'";

                // ✅ Affichage d'une boîte de dialogue sans bouton OK qui reste affichée
                using (LoadingMessageBox loadingBox = new LoadingMessageBox("Creating a save point, please wait..."))
                {
                    loadingBox.Show();
                    await Task.Delay(2000); // Simule un délai de chargement

                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = "powershell.exe",
                        Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{checkProtectionCommand}\"",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    Process checkProcess = new Process { StartInfo = psi };
                    checkProcess.Start();
                    string output = checkProcess.StandardOutput.ReadToEnd();
                    string error = checkProcess.StandardError.ReadToEnd();
                    checkProcess.WaitForExit();

                    if (!string.IsNullOrWhiteSpace(error) && error.Contains("no restore point"))
                    {
                        loadingBox.Close(); // Ferme la boîte de chargement en cas d'erreur
                        MessageBox.Show("⚠️ System protection appears to be disabled. Enable it before creating a save point.",
                                        "Problem detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    ProcessStartInfo psiBackup = new ProcessStartInfo
                    {
                        FileName = "powershell.exe",
                        Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{createBackupCommand}\"",
                        Verb = "runas",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    Process backupProcess = new Process { StartInfo = psiBackup };
                    backupProcess.Start();
                    string backupOutput = backupProcess.StandardOutput.ReadToEnd();
                    string backupError = backupProcess.StandardError.ReadToEnd();
                    backupProcess.WaitForExit();

                    loadingBox.Close(); // ✅ Fermeture de la boîte de chargement dès que le backup est fini

                    if (string.IsNullOrWhiteSpace(backupError))
                    {
                        // ✅ Message de confirmation + transition vers BoosterForm
                        MessageBox.Show("✅ The restore point has been created successfully!",
                                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();
                        BoosterForm nextForm = new BoosterForm();
                        nextForm.Show();
                    }
                    else
                    {
                        MessageBox.Show($"❌ Error creating save point :\n{backupError}",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ An error has occurred : {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LinkLabelNoThanks_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to skip this step?\n\nWe recommend that you create a save point before continuing.",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                BoosterForm nextForm = new BoosterForm();
                nextForm.Show();
            }
        }
    }

    // ✅ Form personnalisée pour afficher un message sans bouton OK
    public class LoadingMessageBox : Form
    {
        private Label labelMessage;

        public LoadingMessageBox(string message)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(400, 120);
            this.TopMost = true;
            this.ControlBox = false;

            labelMessage = new Label
            {
                Text = message,
                Dock = DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold)
            };

            this.Controls.Add(labelMessage);
        }
    }
}