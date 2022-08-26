using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjectWeb.Mvc.Controllers
{
    [Authorize(Roles = "ادمین")]
    public class WebDesignController : Controller
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
    }
}
