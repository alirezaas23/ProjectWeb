using ProjectWeb.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectWeb.Domain.Models.Account;

namespace ProjectWeb.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task UpdateOrder(Order order);
        Task<Order> IsOrderInUse(long userId);
        Task AddNewOrder(Order order);
        Task<Order> GetOrderById(long orderId);
        int FinallyOrders();
        Task SaveChanges();
        //IEnumerable<Order> MyOrders(string userId);
        //Order FindFinalyOrder(int orderId);
        List<Order> ShowFinallyOrders();
        int UserPaysSum();
    }
}
