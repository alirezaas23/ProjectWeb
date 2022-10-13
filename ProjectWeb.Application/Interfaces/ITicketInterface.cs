using ProjectWeb.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectWeb.Application.ViewModels;

namespace ProjectWeb.Application.Interfaces
{
    public interface ITicketInterface
    {
        Task AddTicketAsync(TicketViewModels ticket);
        IEnumerable<Ticket> GetTickets();
        Ticket SearchById(int id);
        Task DeleteTicketAsync(int id);
        List<Ticket> MyTickets(string userId);
    }
}
