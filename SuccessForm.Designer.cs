using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinBoostPro
{
    partial class SuccessForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuccessForm));
            this.TranksForBoosting = new System.Windows.Forms.Label();
            this.TipRestart = new System.Windows.Forms.Label();
            this.CreateBackupPoint = new System.Windows.Forms.Button();
            this.DocSupport = new System.Windows.Forms.Label();
            this.Feedback = new System.Windows.Forms.Label();
            this.Conseil1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // TranksForBoosting
            // 
            resources.ApplyResources(this.TranksForBoosting, "TranksForBoosting");
            this.TranksForBoosting.BackColor = System.Drawing.Color.Transparent;
            this.TranksForBoosting.Name = "TranksForBoosting";
            // 
            // TipRestart
            // 
            resources.ApplyResources(this.TipRestart, "TipRestart");
            this.TipRestart.BackColor = System.Drawing.Color.Transparent;
            this.TipRestart.Name = "TipRestart";
            // 
            // CreateBackupPoint
            // 
            this.CreateBackupPoint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(161)))), ((int)(((byte)(255)))));
            this.CreateBackupPoint.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.CreateBackupPoint, "CreateBackupPoint");
            this.CreateBackupPoint.ForeColor = System.Drawing.Color.Transparent;
            this.CreateBackupPoint.Name = "CreateBackupPoint";
            this.CreateBackupPoint.UseVisualStyleBackColor = false;
            this.CreateBackupPoint.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // DocSupport
            // 
            resources.ApplyResources(this.DocSupport, "DocSupport");
            this.DocSupport.BackColor = System.Drawing.Color.Transparent;
            this.DocSupport.Name = "DocSupport";
            // 
            // Feedback
            // 
            resources.ApplyResources(this.Feedback, "Feedback");
            this.Feedback.BackColor = System.Drawing.Color.Transparent;
            this.Feedback.Name = "Feedback";
            // 
            // Conseil1
            // 
            resources.ApplyResources(this.Conseil1, "Conseil1");
            this.Conseil1.BackColor = System.Drawing.Color.Transparent;
            this.Conseil1.Name = "Conseil1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(80)))), ((int)(((byte)(136)))));
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(120)))), ((int)(((byte)(202)))));
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(80)))), ((int)(((byte)(136)))));
            resources.ApplyResources(this.linkLabel2, "linkLabel2");
            this.linkLabel2.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel2.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(120)))), ((int)(((byte)(202)))));
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.TabStop = true;
            // 
            // linkLabel3
            // 
            this.linkLabel3.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(80)))), ((int)(((byte)(136)))));
            resources.ApplyResources(this.linkLabel3, "linkLabel3");
            this.linkLabel3.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel3.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(120)))), ((int)(((byte)(202)))));
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.TabStop = true;
            // 
            // SuccessForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ControlBox = false;
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Conseil1);
            this.Controls.Add(this.Feedback);
            this.Controls.Add(this.DocSupport);
            this.Controls.Add(this.CreateBackupPoint);
            this.Controls.Add(this.TipRestart);
            this.Controls.Add(this.TranksForBoosting);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SuccessForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SuccessForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            // ✅ Masquer la fenêtre sans quitter complètement l'application
            this.Hide();

            // ✅ Ajouter une icône dans la barre des tâches si nécessaire
            NotifyIcon trayIcon = new NotifyIcon
            {
                Icon = SystemIcons.Information, // Icône par défaut (peut être remplacée par ton logo)
                Visible = true,
                BalloonTipTitle = "WinBoost Pro",
                BalloonTipText = "L'application garde un oeil sur ton PC gros 👀"
            };

            trayIcon.ShowBalloonTip(3000);

            // ✅ Ajouter un menu contextuel pour rouvrir l’app ou la quitter
            ContextMenuStrip trayMenu = new ContextMenuStrip();
            trayMenu.Items.Add("Ouvrir", null, (s, ev) => this.Show());
            trayMenu.Items.Add("Quitter", null, (s, ev) =>
            {
                trayIcon.Visible = false; // Supprime l'icône avant de quitter
                Application.Exit();
            });

            trayIcon.ContextMenuStrip = trayMenu;
        }

        private void SuccessForm_Load(object sender, EventArgs e)
        {
            // ✅ Suppression de l'exception
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Rien ici, donc pas d'erreur
        }

        #endregion

        private System.Windows.Forms.Label TranksForBoosting;
        private System.Windows.Forms.Label TipRestart;
        private System.Windows.Forms.Button CreateBackupPoint;
        private System.Windows.Forms.Label DocSupport;
        private System.Windows.Forms.Label Feedback;
        private System.Windows.Forms.Label Conseil1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
    }
}