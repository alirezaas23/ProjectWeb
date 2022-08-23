using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models;
using ProjectWeb.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Infra.Data.Repositories
{
    public class TicketAnswerRepository : ITicketAnswerRepository
    {
        private readonly ApplicationContext _ctx;

        public TicketAnswerRepository(ApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public void AddTicketAsnwer(TicketAnswer ticketAnswer)
        {
            _ctx.TicketAnswers.Add(ticketAnswer);
        }
    }
}
