using ProjectWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Domain.Interfaces
{
    public interface ITicketsCollectionRepository
    {
        void AddTicketCollection(TicketsCollection ticketsCollection);
        void SaveChanges();
    }
}
