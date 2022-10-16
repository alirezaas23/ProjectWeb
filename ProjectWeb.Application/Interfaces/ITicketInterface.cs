using ProjectWeb.Domain.Models;
using ProjectWeb.Domain.ViewModels.Ticket;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectWeb.Application.Interfaces
{
    public interface ITicketInterface
    {
        Task AddTicketAsync(SendTicketViewModel ticket);
        IEnumerable<Ticket> GetTickets();
        Ticket SearchById(int id);
        Task DeleteTicketAsync(int id);
        List<Ticket> MyTickets(string userId);
    }
}
