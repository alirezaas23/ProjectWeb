﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Application.Interfaces;
using ProjectWeb.Application.ViewModels;
using ProjectWeb.Application.ViewModels.TicketAnswerViewModels;
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
        private readonly ITicketAnswerInterface _ticketAnswerInterface;
        private readonly ITicketsCollectionInterface _ticketsCollectionInterface;

        public TicketController(ITicketInterface ticketInterface, UserManager<UserApp> userManager, ITicketAnswerInterface ticketAnswerInterface, ITicketsCollectionInterface ticketsCollectionInterface)
        {
            _ticketInterface = ticketInterface;
            _userManager = userManager;
            _ticketAnswerInterface = ticketAnswerInterface;
            _ticketsCollectionInterface = ticketsCollectionInterface;
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
                TempData["Message"] = "تیکت شما با موفقیت ارسال شد.برای دریافت پاسخ به قسمت پیام های من بروید.";
                return RedirectToAction("ShowProfile", "Account", new { id = model.UserId });
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult AllTickets()
        {
            ViewBag.Message = TempData["Message"];
            var tickets = _ticketInterface.GetTickets();
            return View(tickets);
        }

        [HttpGet]
        public IActionResult TicketInfo(int id)
        {
            var ticket = _ticketInterface.SearchById(id);
            var ticketModel = new TicketInfoViewModel()
            {
                TicketDateTime = ticket.TicketDateTime,
                TicketId = ticket.TicketId,
                TicketSubject = ticket.TicketSubject,
                TicketText = ticket.TicketText,
                UserId = ticket.UserId
            };
            return View(ticketModel);
        }

        [HttpGet]
        public IActionResult DeleteTicket(int id)
        {
            var ticket = _ticketInterface.SearchById(id);
            var ticketModel = new TicketInfoViewModel()
            {
                TicketDateTime = ticket.TicketDateTime,
                TicketId = ticket.TicketId,
                TicketSubject = ticket.TicketSubject,
                TicketText = ticket.TicketText,
                UserId = ticket.UserId
            };
            return View(ticketModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult DeleteTicket(TicketInfoViewModel model)
        {
            _ticketInterface.DeleteTicket(model.TicketId);
            TempData["Message"] = "تیکت مورد نظر با موفقیت حذف شد.";
            return RedirectToAction("AllTickets", "Ticket");
        }

        [HttpGet]
        public IActionResult TicketAnswer(int id)
        {
            var ticket = _ticketInterface.SearchById(id);
            if (ticket == null) return NotFound();
            PersianCalendar calendar = new PersianCalendar();
            var ticketModel = new AnswerTicketViewModel()
            {
                TicketAnswerDate = calendar.GetYear(DateTime.Now) + "/" + calendar.GetMonth(DateTime.Now) + "/" + calendar.GetDayOfMonth(DateTime.Now)
                    + ", " + calendar.GetHour(DateTime.Now) + ":" + calendar.GetMinute(DateTime.Now) + ":" + calendar.GetSecond(DateTime.Now),
                Ticket = ticket
            };
            return View(ticketModel);
        }

        [HttpPost]
        public IActionResult TicketAnswer(AnswerTicketViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ticketAnswer = new TicketAnswer();
                ticketAnswer.TicketAnswerDateTime = model.TicketAnswerDate;
                ticketAnswer.TicketAnswerText = model.TicketAnswerText;
                _ticketAnswerInterface.AddTicketAnswer(ticketAnswer);

                var ticket = _ticketInterface.SearchById(model.Ticket.TicketId);

                var ticketsCollection = new TicketsCollection()
                {
                    TicketAnswerId = ticketAnswer.TicketAnswerId,
                    TicketAnswer = ticketAnswer,
                    TicketId = ticket.TicketId,
                    Ticket = ticket
                };
                _ticketsCollectionInterface.AddTicketCollection(ticketsCollection);
                TempData["Message"] = "پاسخ تیکت با موفقیت ارسال شد.";
                return RedirectToAction(nameof(AllTickets));
            }
            return View();
        }
    }
}
