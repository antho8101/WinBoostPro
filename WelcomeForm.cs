using System;
using System.Windows.Forms;

namespace WinBoostPro
{
    public partial class WelcomeForm : Form // <- Ici, il était déjà "public"
    {
        private Timer fadeInTimer;

        public WelcomeForm()
        {
            InitializeComponent();
            this.Opacity = 0; // Début transparent

            fadeInTimer = new Timer
            {
                Interval = 30 // Vitesse du fade-in
            };
            fadeInTimer.Tick += FadeInEffect;
            fadeInTimer.Start();
        }

        private void FadeInEffect(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += 0.05; // Augmente l'opacité progressivement
            }
            else
            {
                fadeInTimer.Stop();
            }
        }

        private void WinBoost_Click(object sender, EventArgs e)
        {
        }

        private void Professional_Click(object sender, EventArgs e)
        {
        }

        private void Label1_Click(object sender, EventArgs e)
        {
        }

        private void BoutonCommencer_Click(object sender, EventArgs e)
        {
            this.Hide(); // Masque la fenêtre actuelle
            TermsForm cguForm = new TermsForm(); // Crée une instance de CGUForm
            cguForm.Show(); // Affiche la deuxième fenêtre
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {
        }

        private void WouldYouLikeToCreate_Click(object sender, EventArgs e)
        {

        }
    }
}