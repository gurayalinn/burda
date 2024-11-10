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

namespace burda.Helpers
{
    internal class DbSync
    {
        private AppDbContext context;

        public DbSync()
        {
            context = new AppDbContext(); // Database context'i başlat
        }

        // Veritabanında yeni kart ekleme ve var olanları güncelleme
        public async Task SyncWithDatabaseAsync(List<RFIDCard> cards)
        {
            try
            {
                if (cards == null || cards.Count == 0)
                {
                    Console.WriteLine("Senkronize edilecek veri bulunamadı.");
                    return;
                }

                using (var transaction = context.Database.BeginTransaction()) // Transaction başlat
                {
                    foreach (var card in cards)
                    {
                        if (card == null || string.IsNullOrEmpty(card.RFIDNumber))
                        {
                            Console.WriteLine($"Geçersiz kart verisi: {card?.RFIDNumber}. Veri eklenmeyecek.");
                            continue;
                        }

                        var existingCard = await FindExistingCardAsync(card.RFIDNumber);

                        if (existingCard != null)
                        {
                            // Var olan kartı güncelle
                            await UpdateCardAsync(existingCard, card);
                        }
                        else
                        {
                            // Yeni kart ekle
                            await AddNewCardAsync(card);
                        }
                    }

                    // Veritabanını güncelle
                    await context.SaveChangesAsync();
                    transaction.Commit();
                    Console.WriteLine("Veri başarıyla senkronize edildi.");
                }
            }
            catch (DbEntityValidationException ex)
            {
                HandleValidationException(ex);
            }
            catch (DbUpdateException ex)
            {
                HandleDbUpdateException(ex);
            }
            catch (Exception ex)
            {
                HandleGeneralException(ex);
            }
        }

        // Kartı veritabanında arar
        private async Task<RFIDCard> FindExistingCardAsync(string rfidNumber)
        {
            return await context.RFIDCards
                .FirstOrDefaultAsync(c => c.RFIDNumber == rfidNumber);
        }

        // Yeni kartı ekler
        private async Task AddNewCardAsync(RFIDCard card)
        {
            context.RFIDCards.Add(card);
            Console.WriteLine($"Yeni kart eklendi: {card.RFIDNumber}");
        }

        // Var olan kartı günceller
        private async Task<bool> UpdateCardAsync(RFIDCard existingCard, RFIDCard newCard)
        {
            if (!IsCardDataValid(existingCard, newCard))
            {
                Console.WriteLine("Kart verisi geçersiz veya eksik, güncelleme yapılmadı.");
                return false;
            }

            bool isUpdated = false;

            // Use local variables to allow 'ref' usage
            var rfidNumber = existingCard.RFIDNumber;
            var rawData = existingCard.RawData;
            var updatedDate = existingCard.UpdatedDate;
            var createdDate = existingCard.CreatedDate;

            try
            {
                // Update fields if they differ
                isUpdated |= UpdateFieldIfDifferent(ref rfidNumber, newCard.RFIDNumber, "RFIDNumber");
                isUpdated |= UpdateFieldIfDifferent(ref rawData, newCard.RawData, "RawData");
                isUpdated |= UpdateFieldIfDifferent(ref updatedDate, newCard.UpdatedDate, "UpdatedDate");
                isUpdated |= UpdateFieldIfDifferent(ref createdDate, newCard.CreatedDate, "CreatedDate");

                // Assign back to properties only if updates were made
                if (isUpdated)
                {
                    existingCard.RFIDNumber = rfidNumber;
                    existingCard.RawData = rawData;
                    existingCard.UpdatedDate = updatedDate;
                    existingCard.CreatedDate = createdDate;

                    context.Entry(existingCard).State = EntityState.Modified;
                    Console.WriteLine($"Kart güncellendi: {newCard.RFIDNumber}");
                }
                else
                {
                    Console.WriteLine("Kartta güncellenmesi gereken bir değişiklik bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Kart güncellemesi sırasında hata oluştu: {ex.Message}");
                return false;
            }

            return isUpdated;
        }

        private bool IsCardDataValid(RFIDCard existingCard, RFIDCard newCard)
        {
            if (existingCard == null || newCard == null)
            {
                Console.WriteLine("Kart verisi null.");
                return false;
            }

            if (string.IsNullOrEmpty(existingCard.RawData) || string.IsNullOrEmpty(newCard.RawData))
            {
                Console.WriteLine("Kart verisi boş.");
                return false;
            }

            return true;
        }

        private bool UpdateFieldIfDifferent<T>(ref T existingValue, T newValue, string fieldName)
        {
            if (!EqualityComparer<T>.Default.Equals(existingValue, newValue))
            {
                existingValue = newValue;
                Console.WriteLine($"{fieldName} güncellendi: {newValue}");
                return true;
            }
            return false;
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

        // DbUpdateException hatalarını loglar
        private void HandleDbUpdateException(DbUpdateException ex)
        {
            Console.WriteLine("Veri güncellenirken bir hata oluştu.");
            Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
        }

        // Diğer genel hataları loglar
        private void HandleGeneralException(Exception ex)
        {
            Console.WriteLine($"Beklenmeyen hata: {ex.Message}");
            Console.WriteLine($"Hata Detayı: {ex.InnerException?.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
        }
    }
}
