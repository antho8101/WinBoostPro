using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;

namespace WinBoostPro
{
    internal static class Program
    {
        public static List<string> Commands { get; internal set; } = new List<string>(); // ✅ Stockage global

        [STAThread]
        static void Main()
        {
            // ✅ Vérification et élévation en administrateur
            if (!IsRunningAsAdministrator())
            {
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = Application.ExecutablePath,
                        UseShellExecute = true,
                        Verb = "runas" // ✅ Demande les droits admin
                    };
                    Process.Start(startInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Impossible de relancer en mode administrateur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return; // ✅ Quitte l'instance actuelle non admin
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ✅ Suppression du chargement Notion ici (fait dans `LoadingForm`)
            Application.Run(new WelcomeForm());
        }

        private static bool IsRunningAsAdministrator()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }
    }
}