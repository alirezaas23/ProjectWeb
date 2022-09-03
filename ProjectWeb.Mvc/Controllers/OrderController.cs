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
        private readonly IWebProductInterface _webProductInterface;
        private readonly IOrderDetailInterface _orderDetailInterface;
        public OrderController(IOrderInterface orderInterface, IWebProductInterface webProductInterface, IOrderDetailInterface orderDetailInterface)
        {
            this._orderInterface = orderInterface;
            this._webProductInterface = webProductInterface;
            this._orderDetailInterface = orderDetailInterface;
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
                var orderDetail = new OrderDetail()
                {
                    Count = 1,
                    OrderId = order.OrderId,
                    Order = order,
                    WebProductId = id,
                    Price = ((int)_webProductInterface.FindById(id).WebProductPrice)
                };
                _orderDetailInterface.AddOrderDetail(orderDetail);
            }
            else
            {
                var detail = _orderDetailInterface.IsProductInUse(order.OrderId, id);
                if (detail == null)
                {
                    var orderDetail = new OrderDetail()
                    {
                        Count = 1,
                        OrderId = order.OrderId,
                        Order = order,
                        WebProductId = id,
                        Price = ((int)_webProductInterface.FindById(id).WebProductPrice)
                    };
                    _orderDetailInterface.AddOrderDetail(orderDetail);
                }
                else
                {
                    detail.Count += 1;
                    _orderDetailInterface.UpdateOrderDetail(detail);
                }
            }
            _orderInterface.UpdateSum(order.OrderId);
            TempData["Message"] = "محصول به سبد خرید اضافه شد!";
            return RedirectToAction("WebProductInfo", "WebProduct", new { id = id });
        }
    }
}
