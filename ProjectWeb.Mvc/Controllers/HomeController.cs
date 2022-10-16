using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectWeb.Application.Interfaces;
using ZarinpalSandbox;

namespace ProjectWeb.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrderInterface _orderInterface;

        public HomeController(ILogger<HomeController> logger, IOrderInterface orderInterface)
        {
            _logger = logger;
            _orderInterface = orderInterface;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult OnlinePayment(int id)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" &&
                HttpContext.Request.Query["Authority"] != "")
            {
                var authority = HttpContext.Request.Query["Authority"].ToString();
                var order = _orderInterface.FindOrder(id);
                var payment = new Payment(order.ShouldPaySum);
                var res = payment.Verification(authority).Result;
                if (res.Status == 100)
                {
                    order.IsFinally = true;
                    _orderInterface.UpdateOrder(order);
                    ViewBag.Code = res.RefId;
                    return View();
                }
            }
            return RedirectToAction("PaymentError", "Order");
        }

        public IActionResult OnlinePaymentLeft(int id)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" &&
                HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"].ToString();
                var order = _orderInterface.FindOrder(id);
                var payment = new Payment(order.LeftSum);
                var res = payment.Verification(authority).Result;
                if (res.Status == 100)
                {
                    order.FinalyPay = true;
                    order.LeftSum = 0;
                    order.ShouldPaySum = order.Sum;
                    _orderInterface.UpdateOrder(order);
                    ViewBag.Code = res.RefId;
                    return View();
                }
            }
            return RedirectToAction("PaymentError", "Order");
        }
    }
}