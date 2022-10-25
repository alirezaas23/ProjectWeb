using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Application.Interfaces;
using ProjectWeb.Domain.Models;
using ProjectWeb.Domain.ViewModels.Ticket;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using MyTicketsViewModel = ProjectWeb.Domain.ViewModels.Ticket.MyTicketsViewModel;

namespace ProjectWeb.Mvc.Controllers
{
    public class TicketController : BaseController
    {
        private readonly ITicketInterface _ticketInterface;
        private readonly ICaptchaValidator _captchaValidator;

        public TicketController(ITicketInterface ticketInterface, ICaptchaValidator captchaValidator)
        {
            _ticketInterface = ticketInterface;
            _captchaValidator = captchaValidator;
        }

        //[HttpGet]
        //public async Task<IActionResult> SendTicket()
        //{
        //    var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
        //    PersianCalendar calendar = new PersianCalendar();
        //    var model = new SendTicketViewModel()
        //    {
        //        UserId = user.Id,
        //        TicketDateTime = calendar.GetYear(DateTime.Now) + "/" + calendar.GetMonth(DateTime.Now) + "/" + calendar.GetDayOfMonth(DateTime.Now)
        //            + ", " + calendar.GetHour(DateTime.Now) + ":" + calendar.GetMinute(DateTime.Now) + ":" + calendar.GetSecond(DateTime.Now),
        //    };
        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> SendTicket(SendTicketViewModel model)
        //{
        //    if (!await _captchaValidator.IsCaptchaPassedAsync(model.Captcha))
        //    {
        //        TempData[ErrorMessage] = "اعتبار سنجی Captcha موفق نبود. لطفا مجدد تلاش کنید.";
        //        return View(model);
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        Ticket ticket = new Ticket();
        //        ticket.TicketSubject = model.TicketSubject;
        //        ticket.TicketText = model.TicketText;
        //        ticket.TicketDateTime = model.TicketDateTime;
        //        ticket.UserId = model.UserId;
        //        await _ticketInterface.AddTicketAsync(model);
        //        TempData[SuccessMessage] = "تیکت شما با موفقیت ارسال شد.کارشناسان ما بعد از بررسی با شما تماس خواهند گرفت.";
        //        return RedirectToAction("ShowProfile", "Account", new { id = model.UserId });
        //    }
        //    return View(model);
        //}

        [HttpGet]
        public IActionResult AllTickets()
        {
            ViewBag.Message = TempData["Message"];
            var tickets = _ticketInterface.GetTickets();
            return View(tickets);
        }

        //[HttpGet]
        //public IActionResult TicketInfo(int id)
        //{
        //    var ticket = _ticketInterface.SearchById(id);
        //    var ticketModel = new TicketInfoViewModel()
        //    {
        //        TicketDateTime = ticket.TicketDateTime,
        //        TicketId = ticket.TicketId,
        //        TicketSubject = ticket.TicketSubject,
        //        TicketText = ticket.TicketText,
        //        UserId = ticket.UserId
        //    };
        //    return View(ticketModel);
        //}

        //[HttpGet]
        //public IActionResult DeleteTicket(int id)
        //{
        //    var ticket = _ticketInterface.SearchById(id);
        //    var ticketModel = new TicketInfoViewModel()
        //    {
        //        TicketDateTime = ticket.TicketDateTime,
        //        TicketId = ticket.TicketId,
        //        TicketSubject = ticket.TicketSubject,
        //        TicketText = ticket.TicketText,
        //        UserId = ticket.UserId
        //    };
        //    return View(ticketModel);
        //}

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTicket(TicketInfoViewModel model)
        {
            await _ticketInterface.DeleteTicketAsync(model.TicketId);
            TempData["Message"] = "تیکت مورد نظر با موفقیت حذف شد.";
            return RedirectToAction("AllTickets", "Ticket");
        }

        //[HttpGet]
        //public IActionResult MyTickets(string userId)
        //{
        //    var myTickets = _ticketInterface.MyTickets(userId);
        //    List<MyTicketsViewModel> TicketsList = new List<MyTicketsViewModel>();
        //    foreach (var ticket in myTickets)
        //    {
        //        TicketsList.Add(new MyTicketsViewModel()
        //        {
        //            TicketDateTime = ticket.TicketDateTime,
        //            TicketSubject = ticket.TicketSubject,
        //            TicketText = ticket.TicketText,
        //        });
        //    }
        //    return View(TicketsList);
        //}
    }
}
