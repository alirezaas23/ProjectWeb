using ProjectWeb.Domain.Models;
using System.Collections.Generic;

namespace ProjectWeb.Application.Interfaces
{
    public interface ITicketInterface
    {
        void AddTicket(Ticket ticket);
        IEnumerable<Ticket> GetTickets();
        Ticket SearchById(int id);
    }
}
