using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Formatters;
using ProjectWeb.Application.Extensions;
using ProjectWeb.Application.Interfaces;
using ProjectWeb.Domain.ViewModels.Ticket;
using ProjectWeb.Domain.ViewModels.UserPanel.Account;

namespace ProjectWeb.Mvc.Areas.UserPanel.Controllers
{
    public class AccountController : UserPanelBaseController
    {
        #region Ctor

        private readonly IUserService _userService;
        private readonly IStateService _stateService;
        private readonly ITicketInterface _ticketInterface;

        public AccountController(IUserService userService, IStateService stateService, ITicketInterface ticketInterface)
        {
            _userService = userService;
            _stateService = stateService;
            _ticketInterface = ticketInterface;
        }

        #endregion

        #region Edit Info

        [Authorize]
        [HttpGet("Edit-Account")]
        public async Task<IActionResult> EditInfo()
        {
            ViewData["States"] = await _stateService.GetAllStates();

            var result = await _userService.FillEditUserViewModel(HttpContext.User.GetUserId());

            if (result.CountryId.HasValue)
            {
                ViewData["Cities"] = await _stateService.GetAllStates(result.CountryId);
            }

            return View(result);
        }

        [HttpPost("Edit-Account"), ValidateAntiForgeryToken]
        public async Task<IActionResult> EditInfo(EditUserViewModel model)
        {
            ViewData["States"] = await _stateService.GetAllStates();

            if (model.CountryId.HasValue)
            {
                ViewData["Cities"] = await _stateService.GetAllStates(model.CountryId);
            }

            var result = await _userService.EditUser(HttpContext.User.GetUserId(), model);
            switch (result)
            {
                case EditUserResult.Success:
                    TempData[SuccessMessage] = "اطلاعات با موفقیت ویرایش شد.";
                    return RedirectToAction("EditInfo", "Account", new{area = "UserPanel"});
                case EditUserResult.NotValidDate:
                    TempData[ErrorMessage] = "تاریخ وارد شده معتبر نمی باشد.";
                    break;
            }

            return View(model);
        }

        public async Task<IActionResult> LoadCities(long countryId)
        {
            var result = await _stateService.GetAllStates(countryId);
            return new JsonResult(result);
        }

        #endregion

        #region Change Password

        [HttpGet("Change-Password")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost("Change-Password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            var result = await _userService.ChangePassword(HttpContext.User.GetUserId(), model);
            switch (result)
            {
                case ChangePasswordResult.Success:
                    TempData[SuccessMessage] = "کلمه عبور با موفقیت تغییر کرد. لطفا مجدد وارد شوید.";
                    await HttpContext.SignOutAsync();
                    return RedirectToAction("Login", "Account");
                case ChangePasswordResult.PasswordNotValid:
                    TempData[ErrorMessage] = "کلمه عبور فعلی وارد شده اشتباه است.";
                    break;
            }
            return View(model);
        }

        #endregion

        #region Tickets

        [HttpGet("Send-Ticket")]
        [Authorize]
        public IActionResult SendTicket()
        {
            return View();
        }

        [HttpPost("Send-Ticket")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendTicket(SendTicketViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.UserId = HttpContext.User.GetUserId();
                await _ticketInterface.AddTicket(model);

                TempData[SuccessMessage] = "تیکت شما با موفقیت ارسال شد. پس از بررسی با شما تماس خواهیم گرفت.";
                return RedirectToAction("MyTickets", "Account", new { area = "UserPanel" });
            }

            return View(model);
        }

        [HttpGet("My-Tickets")]
        public async Task<IActionResult> MyTickets()
        {
            var userTickets = await _ticketInterface.UserTickets(HttpContext.User.GetUserId());

            return View(userTickets);
        }

        #endregion
    }
}
