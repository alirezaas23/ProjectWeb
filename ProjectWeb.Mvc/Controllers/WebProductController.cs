using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Application.ViewModels.WebDeisgnViewModels;

namespace ProjectWeb.Mvc.Controllers
{
    [Authorize(Roles = "ادمین")]
    public class WebProductController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddWebDesign()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddWebDesign(AddWebProductViewModel model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}
