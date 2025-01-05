using burda.Helpers;
using burda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace burda.Controllers
{
    internal class CardController : BaseController<RFIDCard>
    {
        public CardController() : base()
        {
        }

        public RFIDCard FindCardByCardNumber(string cardNumber)
        {
            return _context.RFIDCards.FirstOrDefault(c => c.RFIDNumber == cardNumber);
        }

        public RFIDCard FindCardByCardID(long cardID)
        {
            return _context.RFIDCards.FirstOrDefault(c => c.ID == cardID);
        }

        public RFIDCard FindCardByUser(User user)
        {
            return _context.RFIDCards.FirstOrDefault(c => c.ID == user.RFIDCardID);
            
        }

        public List<RFIDCard> FindCardsByUser(User user)
        {
            return _context.RFIDCards.Where(c => c.ID == user.RFIDCardID).ToList();
        }

        internal object Search(string text)
        {
            return _context.RFIDCards.Where(c => c.RFIDNumber.Contains(text)).ToList();
        }

        public bool AddCard(RFIDCard NewRFIDCard)
        {
            try
            {
                if (_context.RFIDCards.Any(c => c.RFIDNumber == NewRFIDCard.RFIDNumber))
                {
                    return false;
                }
                Create(NewRFIDCard);
                Logger.Information($"RFID Card: {NewRFIDCard.RFIDNumber} yeni kart oluşturuldu.");
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error($"Error creating RFID Card: {ex.Message}");
                throw new Exception($"Error creating RFID Card: {ex.Message}");
            }
        }

        public bool UpdateCard(RFIDCard updatedCard)
        {
            try
            {
                RFIDCard existingCard = FindCardByCardID(updatedCard.ID);
                if (existingCard == null)
                {
                    return false;
                }

                if (_context.RFIDCards.Any(c => c.RFIDNumber == updatedCard.RFIDNumber && c.ID != updatedCard.ID))
                {
                    return false;
                }

                existingCard.RFIDNumber = updatedCard.RFIDNumber;
                existingCard.RawData = updatedCard.RawData;
                existingCard.UpdatedDate = DateTime.Now;

                Update(existingCard);
                Logger.Information($"RFID Card: {existingCard.RFIDNumber} kart güncellendi.");
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error($"Error updating RFID Card: {ex.Message}");
                throw new Exception($"Error updating RFID Card: {ex.Message}");
            }
        }
    }
}