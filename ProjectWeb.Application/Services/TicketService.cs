using ProjectWeb.Application.Interfaces;
using ProjectWeb.Application.Security;
using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models;
using ProjectWeb.Domain.ViewModels.Ticket;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ProjectWeb.Application.Extensions;

namespace ProjectWeb.Application.Services
{
    public class TicketService : ITicketInterface
    {
        #region Ctor

        private readonly ITicketRepository _ticketRepository;
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;

        public TicketService(ITicketRepository ticketRepository, IEmailService emailService, IUserService userService)
        {
            _ticketRepository = ticketRepository;
            _emailService = emailService;
            _userService = userService;
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

            #region Send Email To User

            var user = await _userService.GetUserById(newTicket.UserId);

            var userBody = @$"
                    <div style='direction: rtl;font-size:17px;'>
                    <h3>تیکت جدید ثبت شد.</h3>
                    <p>تیکت شما با موفقیت ثبت شد.</p>
                    <div style='margin-top: 15px;'>
                        <p>
                            <span style='font-weight: bold;'>موضوع تیکت :</span> 
                            <span>{newTicket.TicketSubject}</span>
                        </p>
                        <p>
                            <span style='font-weight: bold;'>تاریخ ارسال :</span>  
                            <span>{newTicket.CreateDateTime.ToShamsi()}</span>
                        </p>

                        <hr>

                        <p style='font-weight: bold;'>
                            متن تیکت : 
                        </p>
                        <p>
                            {newTicket.TicketContent}
                        </p>
                    </div>
                </div>";

            await _emailService.SendEmail(user.Email, "تیکت جدید ثبت شد", userBody);

            #endregion

            #endregion
        }

        public async Task DeleteTicketAsync(int id)
        {
            await _ticketRepository.DeleteTicketAsync(id);
            await _ticketRepository.SaveChanges();
        }

        public async Task<List<MyTicketsViewModel>> UserTickets(long userId)
        {
            var userTickets = await _ticketRepository.GetUserTickets(userId);

            return userTickets.Select(u => new MyTicketsViewModel()
            {
                TicketContent = u.TicketContent,
                TicketDateTime = u.CreateDateTime.ToShamsi(),
                TicketSubject = u.TicketSubject,
                TicketId = u.Id
            }).ToList();
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
