using ProjectWeb.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectWeb.Domain.Interfaces
{
    public interface ITicketRepository
    {
        Task AddTicket(Ticket ticket);
        Task SaveChanges();
        IEnumerable<Ticket> GetTickets();
        Ticket SearchById(int id);
        Task DeleteTicketAsync(int id);
        Task<List<Ticket>> GetUserTickets(long userId);
    }
}
