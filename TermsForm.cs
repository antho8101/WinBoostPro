using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinBoostPro
{
    public partial class TermsForm : Form
    {
        public TermsForm()
        {
            InitializeComponent();

            // Abonne l'événement Paint pour gérer l'affichage du texte
            NextButton.Paint += NextButton_Paint;
        }

        private void Alpha_Click(object sender, EventArgs e)
        {

        }

        private void CheckBoxAccept_CheckedChanged(object sender, EventArgs e)
        {
            NextButton.Enabled = checkBoxAccept.Checked;
            if (NextButton.Enabled)
            {
                NextButton.BackColor = Color.FromArgb(52, 161, 255); // Bleu clair quand activé
                NextButton.ForeColor = Color.FromArgb(255, 255, 255); // Texte blanc
            }
            else
            {
                NextButton.BackColor = Color.FromArgb(201, 230, 255); // Transparent quand désactivé
                NextButton.ForeColor = Color.FromArgb(255, 255, 255); // Texte blanc
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            this.Hide(); // Masque la fenêtre actuelle
            BackupForm cguForm = new BackupForm(); // Crée une instance de CGUForm
            cguForm.Show(); // Affiche la deuxième fenêtre
        }

        // Nouvelle méthode pour peindre le texte manuellement
        private void NextButton_Paint(object sender, PaintEventArgs e)
        {
            if (!NextButton.Enabled)
            {
                TextRenderer.DrawText(
                    e.Graphics,
                    NextButton.Text,
                    NextButton.Font,
                    NextButton.ClientRectangle,
                    Color.White, // Texte blanc même quand désactivé
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );
            }
        }
    }
}