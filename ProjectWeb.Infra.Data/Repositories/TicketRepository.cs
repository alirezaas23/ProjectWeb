using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models;
using ProjectWeb.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

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

        public void DeleteTicket(int id)
        {
            var ticket = _ctx.Tickets.Find(id);
            _ctx.Tickets.Remove(ticket);
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

        public Ticket SearchById(int id)
        {
            return _ctx.Tickets.Find(id);
        }
    }
}
