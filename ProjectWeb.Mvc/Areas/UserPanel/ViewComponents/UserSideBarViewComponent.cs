using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Application.Extensions;
using ProjectWeb.Application.Interfaces;
using System.Threading.Tasks;

namespace ProjectWeb.Mvc.Areas.UserPanel.ViewComponents
{
    public class UserSideBarViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IUserService _userService;

        public UserSideBarViewComponent(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserById(HttpContext.User.GetUserId());
            return View("UserSideBar", user);
        }
    }
}
