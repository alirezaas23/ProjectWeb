using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Application.Interfaces;
using ProjectWeb.Application.ViewModels.OrderViewModels;
using ProjectWeb.Application.ViewModels.WebDeisgnViewModels;
using ProjectWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ZarinpalSandbox;

namespace ProjectWeb.Mvc.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderInterface _orderInterface;
        private readonly IWebProductInterface _webProductInterface;
        private readonly IOrderDetailInterface _orderDetailInterface;
        private readonly UserManager<UserApp> _userManager;
        public OrderController(IOrderInterface orderInterface, IWebProductInterface webProductInterface, IOrderDetailInterface orderDetailInterface, UserManager<UserApp> userManager)
        {
            this._orderInterface = orderInterface;
            this._webProductInterface = webProductInterface;
            this._orderDetailInterface = orderDetailInterface;
            _userManager = userManager;
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddToBasket(ShowWebProductViewModel model)
        {
            PersianCalendar calendar = new PersianCalendar();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var order = _orderInterface.IsOrderInUse(userId);
            if (order == null)
            {
                order = new Order()
                {
                    IsFinally = false,
                    Sum = 0,
                    OrderDateTime = calendar.GetYear(DateTime.Now) + "/" + calendar.GetMonth(DateTime.Now) + "/" + calendar.GetDayOfMonth(DateTime.Now)
                    + ", " + calendar.GetHour(DateTime.Now) + ":" + calendar.GetMinute(DateTime.Now) + ":" + calendar.GetSecond(DateTime.Now),
                    UserId = userId,
                };
                _orderInterface.AddOrder(order);
                var orderDetail = new OrderDetail()
                {
                    Count = 1,
                    OrderId = order.OrderId,
                    Price = ((int)_webProductInterface.FindById(model.WebProductID).WebProductPrice),
                    WebProductId = model.WebProductID,
                    Order = order,
                    WebType = model.WebType,
                    Description = model.Description
                };
                _orderDetailInterface.AddOrderDetail(orderDetail);
            }
            else
            {
                var detail = _orderDetailInterface.IsProductInUse(order.OrderId, model.WebProductID);
                if (detail == null)
                {
                    var orderDetail = new OrderDetail()
                    {
                        Count = 1,
                        OrderId = order.OrderId,
                        Price = ((int)_webProductInterface.FindById(model.WebProductID).WebProductPrice),
                        WebProductId = model.WebProductID,
                        Order = order,
                        WebType = model.WebType,
                        Description = model.Description
                    };
                    _orderDetailInterface.AddOrderDetail(orderDetail);
                }
                else
                {
                    TempData["Message"] = "شما این پروژه را در سبد خرید خود دارید. بعد از پرداخت نهایی دوباره اقدام کنید.";
                    return RedirectToAction("WebProductInfo", "WebProduct", new { id = model.WebProductID });
                }
            }
            _orderInterface.UpdateSum(order.OrderId);
            TempData["Message"] = "محصول به سبد خرید اضافه شد!";
            return RedirectToAction("WebProductInfo", "WebProduct", new { id = model.WebProductID });
        }

        [HttpGet]
        [Authorize]
        public IActionResult ShowOrder()
        {
            ViewBag.Message = TempData["Message"];
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var order = _orderInterface.IsOrderInUse(userId);
            List<ShowOrderDetailViewModel> List = new List<ShowOrderDetailViewModel>();
            if (order != null)
            {
                var detail = _orderDetailInterface.GetOrderDetails(order.OrderId);
                foreach (var item in detail)
                {
                    var product = _webProductInterface.FindById(item.WebProductId);
                    List.Add(new ShowOrderDetailViewModel()
                    {
                        Count = item.Count,
                        ImageName = product.WebProductImage,
                        Price = item.Price,
                        Title = product.WebProductName,
                        Sum = item.Price * item.Count,
                        OrderDetailId = item.OrderDetailId,
                        ProductId = product.WebProductID,
                        WebType = item.WebType,
                        Description = item.Description
                    });
                }
            }
            return View(List);
        }

        public IActionResult RemoveOrder(int id)
        {
            _orderDetailInterface.RemoveOrderDetail(id);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var order = _orderInterface.IsOrderInUse(userId);
            _orderInterface.UpdateSum(order.OrderId);
            TempData["Message"] = "محصول با موفقیت از سبد خرید حذف شد.";
            return RedirectToAction(nameof(ShowOrder));
        }

        public IActionResult Payment()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userManager.FindByIdAsync(userId);
            var order = _orderInterface.IsOrderInUse(userId);
            if (order == null)
            {
                return NotFound();
            }
            else
            {
                var payment = new Payment(order.ShouldPaySum);
                var res =
                    payment.PaymentRequest($"پرداخت فاکتور شماره {order.OrderId}", "https://localhost:44349/Home/OnlinePayment/" + order.OrderId,
                    user.Result.Email, user.Result.PhoneNumber);
                if(res.Result.Status == 100)
                {
                    return Redirect("https://zarinpal.com/pg/StartPay/" + res.Result.Authority);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpGet]
        public IActionResult PaymentError()
        {
            return View();
        }
    }
}