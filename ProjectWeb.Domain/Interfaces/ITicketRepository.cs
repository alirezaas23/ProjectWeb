using ProjectWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Domain.Interfaces
{
    public interface ITicketRepository
    {
        void AddTicket(Ticket ticket);
        void SaveChanges();
        IEnumerable<Ticket> GetTickets();
    }
}
