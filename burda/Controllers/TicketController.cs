using burda.Helpers;
using burda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace burda.Controllers
{
    internal class TicketController : BaseController<Ticket>
    {
        public TicketController() : base()
        {
        }


        public List<Ticket> GetAllTickets()
        {
            return _context.Tickets.ToList();
        }

        public Ticket FindTicketByTicketID(int ID)
        {
            return _context.Tickets.FirstOrDefault(t => t.ID == ID);
        }

        public Ticket FindTicketByEmail(string email)
        {
            return _context.Tickets.FirstOrDefault(t => t.Email == email);
        }

        public Ticket FindTicketBySubject(string message)
        {
            return _context.Tickets.FirstOrDefault(t => t.Message == message);
        }

        public bool AddTicket(Ticket ticket)
        {
            try
            {
                Create(ticket);
                Logger.Information($"Ticket: {ticket.Email} - {ticket.Message} yeni ticket oluşturuldu.");
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error($"Error creating Ticket: {ex.Message}");
                throw new Exception($"Error creating Ticket: {ex.Message}");
            }
        }
    }
}
