using ProjectWeb.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectWeb.Domain.ViewModels.WebProduct;

namespace ProjectWeb.Application.Interfaces
{
    public interface IOrderInterface
    {
        #region Add To Basket

        Task<AddOrderResult> AddOrderToBasket(ShowWebProductViewModel model, long userId);

        #endregion
        int FinallyOrders();
        Task UpdateOrder(long orderId);
        IEnumerable<Order> MyOrders(string userId);
        Order FindFinalyOrder(int orderId);
        List<Order> ShowFinallyOrders();
        int UserPaysSum();
    }
}
