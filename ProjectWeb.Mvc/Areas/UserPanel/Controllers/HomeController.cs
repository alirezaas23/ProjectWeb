using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Application.Extensions;
using ProjectWeb.Application.Interfaces;
using ProjectWeb.Application.Statics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ProjectWeb.Mvc.Areas.UserPanel.Controllers
{
    public class HomeController : UserPanelBaseController
    {
        #region Ctor

        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion
        public IActionResult Index()
        {
            return View();
        }

        #region Change User Avatar

        public async Task<IActionResult> ChangeUserAvatar(IFormFile userAvatar)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(userAvatar.FileName);
            var validateFormats = new List<string>()
            {
                ".png",
                ".jpg",
                ".jpeg"
            };
            var result = userAvatar.UploadFile(fileName, PathTools.UserAvatarServerPath, validateFormats);

            if (!result)
            {
                return new JsonResult(new { status = "Error" });
            }

            TempData[SuccessMessage] = "عملیات با موفقیت انجام شد.";

            await _userService.ChangeUserAvatar(HttpContext.User.GetUserId(), fileName);

            return new JsonResult(new { status = "Success" });
        }

        #endregion
    }
}
