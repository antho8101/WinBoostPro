using System;

namespace WinBoostPro
{
    public partial class WelcomeForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeForm));
            this.BoutonCommencer = new System.Windows.Forms.Button();
            this.Alpha = new System.Windows.Forms.Label();
            this.Professional = new System.Windows.Forms.Label();
            this.WinBoost = new System.Windows.Forms.Label();
            this.WouldYouLikeToCreate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BoutonCommencer
            // 
            this.BoutonCommencer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(161)))), ((int)(((byte)(255)))));
            this.BoutonCommencer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BoutonCommencer.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.BoutonCommencer, "BoutonCommencer");
            this.BoutonCommencer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BoutonCommencer.Name = "BoutonCommencer";
            this.BoutonCommencer.UseVisualStyleBackColor = false;
            this.BoutonCommencer.Click += new System.EventHandler(this.BoutonCommencer_Click);
            // 
            // Alpha
            // 
            resources.ApplyResources(this.Alpha, "Alpha");
            this.Alpha.BackColor = System.Drawing.Color.Transparent;
            this.Alpha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.Alpha.Name = "Alpha";
            // 
            // Professional
            // 
            resources.ApplyResources(this.Professional, "Professional");
            this.Professional.BackColor = System.Drawing.Color.Transparent;
            this.Professional.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Professional.Name = "Professional";
            // 
            // WinBoost
            // 
            resources.ApplyResources(this.WinBoost, "WinBoost");
            this.WinBoost.BackColor = System.Drawing.Color.Transparent;
            this.WinBoost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.WinBoost.Name = "WinBoost";
            // 
            // WouldYouLikeToCreate
            // 
            resources.ApplyResources(this.WouldYouLikeToCreate, "WouldYouLikeToCreate");
            this.WouldYouLikeToCreate.BackColor = System.Drawing.Color.Transparent;
            this.WouldYouLikeToCreate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.WouldYouLikeToCreate.Name = "WouldYouLikeToCreate";
            // 
            // WelcomeForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.WouldYouLikeToCreate);
            this.Controls.Add(this.Professional);
            this.Controls.Add(this.WinBoost);
            this.Controls.Add(this.Alpha);
            this.Controls.Add(this.BoutonCommencer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WelcomeForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button BoutonCommencer;
        private System.Windows.Forms.Label Alpha;
        private System.Windows.Forms.Label Professional;
        private System.Windows.Forms.Label WinBoost;
        private System.Windows.Forms.Label WouldYouLikeToCreate;
    }
}