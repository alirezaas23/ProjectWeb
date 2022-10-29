using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Application.Interfaces;
using System.Threading.Tasks;

namespace ProjectWeb.Mvc.ViewComponents
{
    public class OrderDetailViewComponent : ViewComponent
    {
        private readonly IOrderInterface _orderInterface;
        private readonly IWebProductInterface _webProductInterface;
        private readonly IOrderDetailInterface _orderDetailInterface;

        public OrderDetailViewComponent(IOrderInterface orderInterface, IWebProductInterface webProductInterface, IOrderDetailInterface orderDetailInterface)
        {
            _orderInterface = orderInterface;
            _webProductInterface = webProductInterface;
            _orderDetailInterface = orderDetailInterface;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var order = _orderInterface.IsOrderInUse(userId);
            //List<ComponentOrderDetailViewModel> List = new List<ComponentOrderDetailViewModel>();
            //if (order != null)
            //{
            //    var detail = _orderDetailInterface.GetOrderDetails(order.OrderId);
            //    foreach (var item in detail)
            //    {
            //        var product = _webProductInterface.FindById(item.WebProductId);
            //        List.Add(new ComponentOrderDetailViewModel()
            //        {
            //            ProductName = product.WebProductName,
            //            ProductPrice = (int)product.WebProductPrice,
            //            OrderDetailId = item.OrderDetailId,
            //            ProductId = product.WebProductID
            //        });
            //    }
            //}
            return View();
        }
    }
}
