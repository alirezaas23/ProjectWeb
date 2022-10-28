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
using Microsoft.AspNetCore.Authorization;
using ProjectWeb.Application.Extensions;
using MyTicketsViewModel = ProjectWeb.Domain.ViewModels.Ticket.MyTicketsViewModel;

namespace ProjectWeb.Mvc.Controllers
{
    public class TicketController : BaseController
    {
        private readonly ITicketInterface _ticketInterface;

        public TicketController(ITicketInterface ticketInterface)
        {
            _ticketInterface = ticketInterface;
        }

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
    }
}
