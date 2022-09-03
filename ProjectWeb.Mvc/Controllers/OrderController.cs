using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Application.Interfaces;
using ProjectWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectWeb.Mvc.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderInterface _orderInterface;
        public OrderController(IOrderInterface orderInterface)
        {
            this._orderInterface = orderInterface;
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddToBasket(int id)
        {
            PersianCalendar calendar = new PersianCalendar();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var order = _orderInterface.IsOrderInUse(userId);
            if (order == null)
            {
                order = new Order()
                {
                    IsFinally = false,
                    OrderDateTime = calendar.GetYear(DateTime.Now) + "/" + calendar.GetMonth(DateTime.Now) + "/" + calendar.GetDayOfMonth(DateTime.Now)
                    + ", " + calendar.GetHour(DateTime.Now) + ":" + calendar.GetMinute(DateTime.Now) + ":" + calendar.GetSecond(DateTime.Now),
                    Sum = 0,
                    UserId = userId,
                };
                _orderInterface.AddOrder(order);

            }
            return View();
        }
    }
}
