using ProjectWeb.Application.Interfaces;
using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models;
using System.Collections.Generic;

namespace ProjectWeb.Application.Services
{
    public class TicketService : ITicketInterface
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public void AddTicket(Ticket ticket)
        {
            _ticketRepository.AddTicket(ticket);
        }

        public IEnumerable<Ticket> GetTickets()
        {
            return _ticketRepository.GetTickets();
        }

        public Ticket SearchById(int id)
        {
            return _ticketRepository.SearchById(id);
        }
    }
}
