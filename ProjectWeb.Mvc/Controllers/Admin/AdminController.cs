using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjectWeb.Mvc.Controllers.Admin
{
    [Authorize(Roles = "ادمین")]
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
