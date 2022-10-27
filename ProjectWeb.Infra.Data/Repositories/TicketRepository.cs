using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models;
using ProjectWeb.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWeb.Infra.Data.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationContext _ctx;

        public TicketRepository(ApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public async Task AddTicket(Ticket ticket)
        {
            await _ctx.Tickets.AddAsync(ticket);
        }

        public async Task DeleteTicketAsync(int id)
        {
            var ticket = await _ctx.Tickets.FindAsync(id);
            _ctx.Tickets.Remove(ticket);
        }

        public IEnumerable<Ticket> GetTickets()
        {
            return _ctx.Tickets;
        }

        public List<Ticket> MyTickets(string userId)
        {
            //return _ctx.Tickets.Where(t => t.UserId == userId).ToList();
            return null;
        }

        public async Task SaveChanges()
        {
            await _ctx.SaveChangesAsync();
        }

        public Ticket SearchById(int id)
        {
            return _ctx.Tickets.Find(id);
        }
    }
}
