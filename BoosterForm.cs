using System;
using System.Windows.Forms;

namespace WinBoostPro
{
    public partial class BoosterForm : Form
    {
        public BoosterForm()
        {
            InitializeComponent();
        }

        private void BoostNow_Click(object sender, EventArgs e)
        {
            this.Hide(); // Masquer la fenêtre actuelle
            LoadingForm loadingPage = new LoadingForm();
            loadingPage.Show();
        }

        private void BoosterForm_Load(object sender, EventArgs e)
        {

        }
    }
}