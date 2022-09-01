using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectWeb.Mvc.Controllers
{
    public class OrderController : Controller
    {
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddToBasket(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View();
        }
    }
}
