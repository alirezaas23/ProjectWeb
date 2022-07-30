using ProjectWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Application.Interfaces
{
    public interface ITicketInterface
    {
        void AddTicket(Ticket ticket);
    }
}
