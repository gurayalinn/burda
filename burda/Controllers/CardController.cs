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

        public RFIDCard FindCardByCardID(int cardID)
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

    }
}