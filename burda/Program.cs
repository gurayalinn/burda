// Program.cs
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using burda.Models;
using burda.Helpers;

namespace burda
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Burda());
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

                Console.WriteLine("Veri başarıyla senkronize edildi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata oluştu: " + ex.Message);
            }
        }
    }
}
