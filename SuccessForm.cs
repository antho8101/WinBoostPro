using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace WinBoostPro
{
    public partial class SuccessForm : Form
    {
        private readonly List<PictureBox> confettis = new List<PictureBox>();
        private readonly Timer confettiTimer;
        private readonly Timer stopConfettiTimer;
        private readonly Random random = new Random();
        private NotifyIcon trayIcon;
        private bool isGenerating = true;

        public SuccessForm()
        {
            InitializeComponent();
            confettiTimer = new Timer { Interval = 100 };
            confettiTimer.Tick += (sender, e) => GenerateConfetti();
            confettiTimer.Start();

            stopConfettiTimer = new Timer { Interval = 3000 };
            stopConfettiTimer.Tick += (sender, e) =>
            {
                isGenerating = false;
                stopConfettiTimer.Stop();
            };
            stopConfettiTimer.Start();

            // ✅ Assure que l'événement est bien attaché à la bonne méthode
            RestartLater.LinkClicked += RestartLater_LinkClicked;
        }

        private void GenerateConfetti()
        {
            if (!isGenerating) return;

            var confetti = new PictureBox
            {
                Size = new Size(10, 10),
                BackColor = GetRandomColor(),
                Location = new Point(random.Next(0, Width - 10), 0)
            };

            Controls.Add(confetti);
            confettis.Add(confetti);

            var fallTimer = new Timer { Interval = 50 };
            fallTimer.Tick += (sender, e) =>
            {
                if (confetti.Top < Height)
                {
                    confetti.Top += 10;
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

        private void RestartButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to restart your PC?",
                                         "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Process.Start("shutdown", "/r /t 0");
                Application.Exit();
            }
        }

        private void RestartLater_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (trayIcon == null)
            {
                trayIcon = new NotifyIcon
                {
                    Icon = new Icon(GetType().Assembly.GetManifestResourceStream("WinBoostPro.WinBoostPro.ico")),
                    Visible = true,
                    BalloonTipTitle = "WinBoost Pro",
                    BalloonTipText = "The application runs in the background."
                };

                trayIcon.ShowBalloonTip(3000);

                var trayMenu = new ContextMenuStrip();
                trayMenu.Items.Add("Open", null, (s, ev) =>
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        BackupForm backupForm = new BackupForm
                        {
                            StartPosition = FormStartPosition.CenterScreen
                        };
                        backupForm.Show();
                    });
                });
                trayMenu.Items.Add("Exit", null, (s, ev) =>
                {
                    trayIcon.Visible = false;
                    trayIcon.Dispose();
                    Application.Exit();
                });

                trayIcon.ContextMenuStrip = trayMenu;
            }

            trayIcon.Visible = true;
            this.Hide();
        }
    }
}