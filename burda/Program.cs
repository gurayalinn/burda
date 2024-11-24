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

                await Logger.Information("Program started.");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());

            }
            catch (Exception ex)
            {
                await Logger.Error("An error occurred during program execution", ex);
            }
        }

        public static async Task SyncGist()
        {
            try
            {
                // Gist verisini çekmek ve senkronizasyon işlemi
                Gist gistService = new Gist();
                Json jsonParser = new Json();
                DbSync databaseSyncService = new DbSync();

                // Gist verisini çek
                var jsonData = await gistService.FetchGistDataAsync();

                // JSON verisini parse et
                var cards = jsonParser.ParseRFIDCards(jsonData);

                // Veritabanı ile senkronize et
                await databaseSyncService.SyncWithDatabaseAsync(cards);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata oluştu: " + ex.Message);
                await Logger.Error("An error occurred during data synchronization", ex);
            }
        }
    }
}
