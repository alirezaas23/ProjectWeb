using ProjectWeb.Domain.Models;
using ProjectWeb.Domain.ViewModels.Ticket;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectWeb.Application.Interfaces
{
    public interface ITicketInterface
    {
        Task AddTicket(SendTicketViewModel ticket);
        IEnumerable<Ticket> GetTickets();
        Ticket SearchById(int id);
        Task DeleteTicketAsync(int id);
        Task<List<MyTicketsViewModel>> UserTickets(long userId);
    }
}
