using ProjectWeb.Application.Interfaces;
using ProjectWeb.Application.Security;
using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models;
using ProjectWeb.Domain.ViewModels.Ticket;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectWeb.Application.Services
{
    public class TicketService : ITicketInterface
    {
        #region Ctor

        private readonly ITicketRepository _ticketRepository;
        private readonly IEmailService _emailService;

        public TicketService(ITicketRepository ticketRepository, IEmailService emailService)
        {
            _ticketRepository = ticketRepository;
            _emailService = emailService;
        }

        #endregion

        public async Task AddTicket(SendTicketViewModel ticket)
        {
            var newTicket = new Ticket()
            {
                UserId = ticket.UserId,
                TicketContent = ticket.TicketContent.SanitizeText(),
                TicketSubject = ticket.TicketSubject.SanitizeText()
            };

            await _ticketRepository.AddTicket(newTicket);
            await _ticketRepository.SaveChanges();

            #region Send Email

            var body = @"
                <div style='direction: rtl;'>
                    <h3>تیکت جدید ثبت شد.</h3>
                    <p>یک تیکت جدید ثبت شد. لطفا در سایت بررسی کنید.</p>
                </div>";

            await _emailService.SendEmail("alirezaasgari683@gmail.com", "تیکت جدید", body);

            #endregion
        }

        public async Task DeleteTicketAsync(int id)
        {
            await _ticketRepository.DeleteTicketAsync(id);
            await _ticketRepository.SaveChanges();
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
