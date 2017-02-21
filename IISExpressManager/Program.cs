using System;
using System.Windows.Forms;
using IISExpressManager.Helpers;
using IISExpressManager.Properties;
using IISExpressManager.ViewModels;
using WinForms.Framework.Messaging;

namespace IISExpressManager
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (App.InstanceAlreadyExists())
            {
                MessageBox.Show(
                    Resources.Program_Main_SingleInstance_ErrorMessage,
                    Resources.Program_Main_Warning_Header,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!App.IISExpressConfig.ConfigurationFound() ||
                !App.IISExpressConfig.IISExpressInstalled())
            {
                MessageBox.Show(
                    Resources.Program_Main_IIS_Express_not_installed_or_configuration_not_found_Message,
                    Resources.Program_Main_Abort_Header,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var eventAggregator = EventAggregator.Instance;
            var mainVm = new MainViewModel(eventAggregator);

            //Create a process monitor thread for running processes and 
            //update VM when process is created or exited
            //Start the UI with VM
            Application.Run(new MainForm(mainVm, eventAggregator));
        }
    }
}