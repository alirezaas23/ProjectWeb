using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Application.Interfaces;
using ProjectWeb.Application.ViewModels;
using ProjectWeb.Domain.Models;
using System;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectWeb.Mvc.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketInterface _ticketInterface;
        private readonly UserManager<UserApp> _userManager;

        public TicketController(ITicketInterface ticketInterface, UserManager<UserApp> userManager)
        {
            _ticketInterface = ticketInterface;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> SendTicket()
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            PersianCalendar calendar = new PersianCalendar();
            var model = new TicketViewModels()
            {
                UserId = user.Id,
                TicketDateTime = calendar.GetYear(DateTime.Now) + "/" + calendar.GetMonth(DateTime.Now) + "/" + calendar.GetDayOfMonth(DateTime.Now)
                    + ", " + calendar.GetHour(DateTime.Now) + ":" + calendar.GetMinute(DateTime.Now) + ":" + calendar.GetSecond(DateTime.Now),
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendTicket(TicketViewModels model)
        {
            if (ModelState.IsValid)
            {
                Ticket ticket = new Ticket();
                ticket.TicketSubject = model.TicketSubject;
                ticket.TicketText = model.TicketText;
                ticket.TicketDateTime = model.TicketDateTime;
                ticket.UserId = model.UserId;
                _ticketInterface.AddTicket(ticket);
                TempData["Message"] = "تیکت شما با موفقیت ارسال شد.به زودی با شما تماس خواهیم گرفت.";
                return RedirectToAction("ShowProfile", "Account", new { id = model.UserId });
            }
            return View(model);
        }
    }
}
