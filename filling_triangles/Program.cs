using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace filling_triangles
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            // makes it work on different computers
            string workingDirectory = Environment.CurrentDirectory;
            var projectDir = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            
            // remove colorComputationMethod from app.config
            var config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings.Remove("colorComputationMethod");
            config.AppSettings.Settings.Add("colorComputationMethod", "vectorInterpolation");
            config.Save(ConfigurationSaveMode.Minimal);
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}