using ProjectWeb.Application.Interfaces;
using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectWeb.Application.Security;
using ProjectWeb.Application.ViewModels;

namespace ProjectWeb.Application.Services
{
    public class TicketService : ITicketInterface
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task AddTicketAsync(TicketViewModels ticket)
        {
            var newTicket = new Ticket()
            {
                TicketSubject = ticket.TicketSubject.SanitizeText(),
                TicketText = ticket.TicketText.SanitizeText(),
                UserId = ticket.UserId,
                TicketDateTime = ticket.TicketDateTime.SanitizeText()
            };

            await _ticketRepository.AddTicketAsync(newTicket);
            await _ticketRepository.SaveChangesAsync();
        }

        public async Task DeleteTicketAsync(int id)
        {
            await _ticketRepository.DeleteTicketAsync(id);
            await _ticketRepository.SaveChangesAsync();
        }

        public IEnumerable<Ticket> GetTickets()
        {
            return _ticketRepository.GetTickets();
        }

        public List<Ticket> MyTickets(string userId)
        {
            return _ticketRepository.MyTickets(userId);
        }

        public Ticket SearchById(int id)
        {
            return _ticketRepository.SearchById(id);
        }
    }
}
