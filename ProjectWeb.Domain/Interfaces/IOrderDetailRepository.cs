using ProjectWeb.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectWeb.Domain.Interfaces
{
    public interface IOrderDetailRepository
    {
        void UpdateOrderDetail(OrderDetail orderDetail);
        Task<OrderDetail> IsProductInUse(long orderId, long productId);
        Task AddOrderDetail(OrderDetail orderDetail);
        Task SaveChanges();
        IEnumerable<OrderDetail> GetOrderDetails(int orderId);
        void RemoveOrderDetail(int id);
        OrderDetail FindById(int id);
    }
}
