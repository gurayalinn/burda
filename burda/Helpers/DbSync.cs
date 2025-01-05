//DbSync.cs
using burda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace burda.Helpers
{
    internal class DbSync
    {
        private readonly AppDbContext context;
        // List<RFIDCard> existingCards;
        //private List<RFIDCard> updatedCards;

        public DbSync()
        {
            context = new AppDbContext(); // Database context'i başlat
        }

        // Veritabanında yeni kart ekleme ve var olanları güncelleme
        public async Task SyncWithDatabaseAsync(List<RFIDCard> gistCards)
        {
            try
            {
                if (gistCards == null || gistCards.Count == 0)
                {
                    Console.WriteLine("Senkronize edilecek veri bulunamadı.");
                    return;
                }

                using (var transaction = context.Database.BeginTransaction())
                {
                    foreach (var gistCard in gistCards)
                    {
                        if (gistCard == null || string.IsNullOrEmpty(gistCard.RFIDNumber))
                        {
                            Console.WriteLine($"Geçersiz kart verisi. Veri eklenmeyecek.");
                            continue;
                        }

                        var existingCard = await FindExistingCardAsync(gistCard.RFIDNumber);
                        //existingCards = await context.RFIDCards.ToListAsync();

                        if (existingCard == null)
                        {
                            context.RFIDCards.Add(gistCard);
                            Console.WriteLine($"Yeni kart eklendi: {gistCard.RFIDNumber}");
                            continue;

                        }
                        if (existingCard != null && existingCard.UpdatedDate == gistCard.UpdatedDate)
                        {
                            //Console.WriteLine($"Kart zaten güncel: {gistCard.RFIDNumber}");
                            continue;
                        }
                        if (existingCard != null && existingCard.UpdatedDate > gistCard.UpdatedDate && existingCard.UpdatedDate != gistCard.UpdatedDate)
                        {
                            existingCard.UpdatedDate = gistCard.UpdatedDate;
                            //Console.WriteLine($"Kart güncellendi: {gistCard.RFIDNumber}");
                            continue;
                        }


                    }
                    await context.SaveChangesAsync();
                    transaction.Commit();
                    //Console.WriteLine("Senkronizasyon tamamlandı.");
                }
            }
            catch (DbEntityValidationException ex)
            {
                HandleValidationException(ex);
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Veritabanı güncelleme hatası: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Senkronizasyon hatası: {ex.Message}");
            }
        }

        // Kartı veritabanında arar
        private async Task<RFIDCard> FindExistingCardAsync(string rfidNumber)
        {
            return await context.RFIDCards
                .FirstOrDefaultAsync(c => c.RFIDNumber == rfidNumber);
        }

        // Entity validation hatalarını loglar
        private void HandleValidationException(DbEntityValidationException ex)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var eve in ex.EntityValidationErrors)
            {
                sb.AppendLine($"Entity of type {eve.Entry.Entity.GetType().Name} in state {eve.Entry.State} has the following validation errors:");
                foreach (var ve in eve.ValidationErrors)
                {
                    sb.AppendLine($"- Property: {ve.PropertyName}, Error: {ve.ErrorMessage}");
                }
            }
            Console.WriteLine(sb.ToString());
        }

    }
}
