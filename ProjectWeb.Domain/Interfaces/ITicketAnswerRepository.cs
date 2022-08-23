using ProjectWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Domain.Interfaces
{
    public interface ITicketAnswerRepository
    {
        void AddTicketAsnwer(TicketAnswer ticketAnswer);
    }
}
