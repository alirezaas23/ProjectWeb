﻿using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models;
using ProjectWeb.Infra.Data.Context;
using System.Collections.Generic;

namespace ProjectWeb.Infra.Data.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationContext _ctx;

        public TicketRepository(ApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public void AddTicket(Ticket ticket)
        {
            _ctx.Tickets.Add(ticket);
            SaveChanges();
        }

        public IEnumerable<Ticket> GetTickets()
        {
            return _ctx.Tickets;
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }
    }
}