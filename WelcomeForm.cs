using System;
using System.Windows.Forms;

namespace WinBoostPro
{
    public partial class WelcomeForm : Form
    {
        private readonly Timer fadeInTimer;

        public WelcomeForm()
        {
            InitializeComponent();
            this.Opacity = 0;

            fadeInTimer = new Timer
            {
                Interval = 30
            };
            fadeInTimer.Tick += FadeInEffect;
            fadeInTimer.Start();
        }

        private void FadeInEffect(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += 0.05;
            }
            else
            {
                fadeInTimer.Stop();
            }
        }

        private void BoutonCommencer_Click(object sender, EventArgs e)
        {
            this.Hide();
            new TermsForm().Show();
        }
    }
}