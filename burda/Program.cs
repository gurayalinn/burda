// Program.cs
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using burda.Models;
using burda.Helpers;
using Serilog;

namespace burda
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            try
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());

            }
            catch (Exception ex)
            {
                await Logger.Error("An error occurred during program execution", ex);
            }
        }


    }
}
