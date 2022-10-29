using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Application.Interfaces;

namespace ProjectWeb.Mvc.Controllers.Admin
{
    public class AdminController : Controller
    {
        private readonly IOrderInterface _orderInterface;

        public AdminController(IOrderInterface orderInterface)
        {
            _orderInterface = orderInterface;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public IActionResult Orders()
        //{
        //    var orders = _orderInterface.ShowFinallyOrders();
        //    List<AllOrdersViewModel> ordersList = new List<AllOrdersViewModel>();
        //    foreach (var order in orders)
        //    {
        //        ordersList.Add(new AllOrdersViewModel()
        //        {
        //            FinalyPay = order.FinalyPay,
        //            IsFinally = order.IsFinally,
        //            LeftSum = order.LeftSum,
        //            OrderDateTime = order.OrderDateTime,
        //            OrderId = order.OrderId,
        //            ShouldPaySum = order.ShouldPaySum,
        //            Sum = order.Sum,
        //            UserId = order.UserId
        //        });
        //    }
        //    return View(ordersList);
        //}
    }
}
