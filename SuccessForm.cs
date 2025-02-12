using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinBoostPro
{
    public partial class SuccessForm : Form
    {
        private List<PictureBox> confettis = new List<PictureBox>();
        private System.Windows.Forms.Timer confettiTimer;
        private System.Windows.Forms.Timer stopConfettiTimer;
        private Random random = new Random();
        private bool isGenerating = true; // Permet d’arrêter le flux après quelques secondes

        public SuccessForm()
        {
            InitializeComponent();
            StartConfettiAnimation();
        }

        private void StartConfettiAnimation()
        {
            confettiTimer = new System.Windows.Forms.Timer();
            confettiTimer.Interval = 100; // Génère un confetti toutes les 100ms
            confettiTimer.Tick += (sender, e) => GenerateConfetti();
            confettiTimer.Start();

            // **Stopper la génération après 3 secondes**
            stopConfettiTimer = new System.Windows.Forms.Timer();
            stopConfettiTimer.Interval = 3000;
            stopConfettiTimer.Tick += (sender, e) =>
            {
                isGenerating = false; // Arrête la création de nouveaux confettis
                stopConfettiTimer.Stop();
            };
            stopConfettiTimer.Start();
        }

        private void GenerateConfetti()
        {
            if (!isGenerating) return; // Arrête la création si le temps est écoulé

            PictureBox confetti = new PictureBox
            {
                Size = new Size(10, 10),
                BackColor = GetRandomColor(),
                Location = new Point(random.Next(0, this.Width - 10), 0)
            };

            this.Controls.Add(confetti);
            confettis.Add(confetti);

            System.Windows.Forms.Timer fallTimer = new System.Windows.Forms.Timer();
            fallTimer.Interval = 50;
            fallTimer.Tick += (sender, e) =>
            {
                if (confetti.Top < this.Height)
                {
                    confetti.Top += 10; // Fait tomber le confetti
                }
                else
                {
                    fallTimer.Stop();
                    fallTimer.Dispose();
                    confetti.Dispose();
                    confettis.Remove(confetti);
                }
            };
            fallTimer.Start();
        }

        private Color GetRandomColor()
        {
            Color[] colors = { Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Purple, Color.Orange };
            return colors[random.Next(colors.Length)];
        }
    }
}