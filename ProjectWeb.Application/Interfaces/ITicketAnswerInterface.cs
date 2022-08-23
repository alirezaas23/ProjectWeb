using ProjectWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Application.Interfaces
{
    public interface ITicketAnswerInterface
    {
        void AddTicketAnswer(TicketAnswer ticketAnswer);
    }
}
