using ProjectWeb.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectWeb.Domain.Interfaces
{
    public interface ITicketRepository
    {
        Task AddTicketAsync(Ticket ticket);
        Task SaveChangesAsync();
        IEnumerable<Ticket> GetTickets();
        Ticket SearchById(int id);
        Task DeleteTicketAsync(int id);
        List<Ticket> MyTickets(string userId);
    }
}
