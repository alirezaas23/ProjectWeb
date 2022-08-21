using ProjectWeb.Domain.Models;
using System.Collections.Generic;

namespace ProjectWeb.Domain.Interfaces
{
    public interface ITicketRepository
    {
        void AddTicket(Ticket ticket);
        void SaveChanges();
        IEnumerable<Ticket> GetTickets();
        Ticket SearchById(int id);
        void DeleteTicket(int id);
    }
}
