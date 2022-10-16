using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Application.Interfaces;
using ProjectWeb.Domain.Models;
using ProjectWeb.Domain.ViewModels.Order;
using ProjectWeb.Domain.ViewModels.WebProduct;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using GoogleReCaptcha.V3.Interface;
using ZarinpalSandbox;

namespace ProjectWeb.Mvc.Controllers
{
    public class OrderController : BaseController
    {
        #region Ctor

        private readonly IOrderInterface _orderInterface;
        private readonly IWebProductInterface _webProductInterface;
        private readonly IOrderDetailInterface _orderDetailInterface;
        private readonly UserManager<UserApp> _userManager;
        private readonly ICaptchaValidator _captchaValidator;
        public OrderController(IOrderInterface orderInterface, IWebProductInterface webProductInterface, IOrderDetailInterface orderDetailInterface, UserManager<UserApp> userManager, ICaptchaValidator captchaValidator)
        {
            this._orderInterface = orderInterface;
            this._webProductInterface = webProductInterface;
            this._orderDetailInterface = orderDetailInterface;
            _userManager = userManager;
            _captchaValidator = captchaValidator;
        }

        #endregion

        #region Add To Basket

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToBasket(ShowWebProductViewModel model)
        {
            if (!await _captchaValidator.IsCaptchaPassedAsync(model.Captcha))
            {
                TempData[ErrorMessage] = "اعتبار سنجی Captcha موفق نبود. لطفا دوباره تلاش کنید.";
                return RedirectToAction("WebProductInfo", "WebProduct", new{ id = model.WebProductID});
            }

            PersianCalendar calendar = new PersianCalendar();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var order = _orderInterface.IsOrderInUse(userId);
            if (order == null)
            {
                order = new Order()
                {
                    FinalyPay = false,
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
                    TempData[ErrorMessage] = "شما این پروژه را در سبد خرید خود دارید. بعد از پرداخت نهایی دوباره اقدام کنید.";
                    return RedirectToAction("WebProductInfo", "WebProduct", new { id = model.WebProductID });
                }
            }
            _orderInterface.UpdateSum(order.OrderId);
            TempData[SuccessMessage] = "محصول به سبد خرید اضافه شد!";
            return RedirectToAction("WebProductInfo", "WebProduct", new { id = model.WebProductID });
        }

        #endregion

        #region Show Order

        [HttpGet]
        [Authorize]
        public IActionResult ShowOrder()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var order = _orderInterface.IsOrderInUse(userId);
            List<ShowOrderDetailViewModel> list = new List<ShowOrderDetailViewModel>();
            if (order != null)
            {
                var detail = _orderDetailInterface.GetOrderDetails(order.OrderId);
                foreach (var item in detail)
                {
                    var product = _webProductInterface.FindById(item.WebProductId);
                    list.Add(new ShowOrderDetailViewModel()
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
            return View(list);
        }

        #endregion

        #region Remove Order

        public IActionResult RemoveOrder(int id)
        {
            _orderDetailInterface.RemoveOrderDetail(id);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var order = _orderInterface.IsOrderInUse(userId);
            _orderInterface.UpdateSum(order.OrderId);
            TempData[SuccessMessage] = "محصول با موفقیت از سبد خرید حذف شد.";
            return RedirectToAction(nameof(ShowOrder));
        }

        #endregion

        #region Paymanet

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
                if (res.Result.Status == 100)
                {
                    return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
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

        [HttpGet]
        public IActionResult PaymentLeftSum(int orderId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userManager.FindByIdAsync(userId);
            var order = _orderInterface.FindFinalyOrder(orderId);
            if (order != null)
            {
                var payment = new Payment(order.LeftSum);
                var res =
                    payment.PaymentRequest($"پرداخت مبلغ باقی مانده فاکتور {order.OrderId}", "https://localhost:44349/Home/OnlinePaymentLeft/" + order.OrderId,
                        user.Result.Email, user.Result.PhoneNumber);
                if (res.Result.Status == 100)
                {
                    return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
        }

        #endregion

        #region My Orders

        [HttpGet]
        public IActionResult MyOrders(string userId)
        {
            var orders = _orderInterface.MyOrders(userId);
            List<MyOrdersViewModel> list = new List<MyOrdersViewModel>();
            if (orders != null)
            {
                foreach (var item in orders)
                {
                    list.Add(new MyOrdersViewModel()
                    {
                        LeftSum = item.LeftSum,
                        OrderDateTime = item.OrderDateTime,
                        OrderId = item.OrderId,
                        ShouldPaySum = item.ShouldPaySum,
                        Sum = item.Sum,
                        UserId = item.UserId,
                        FinalyPay = item.FinalyPay
                    });
                }
            }
            return View(list);
        }

        #endregion
    }
}