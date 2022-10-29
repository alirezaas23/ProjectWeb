using ProjectWeb.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectWeb.Application.Interfaces
{
    public interface IOrderDetailInterface
    {
        void UpdateOrderDetail(OrderDetail orderDetail);
        Task<OrderDetail> IsProductInUse(long orderId, long productId);
        Task AddOrderDetail(OrderDetail orderDetail);
        IEnumerable<OrderDetail> GetOrderDetails(int orderId);
        void RemoveOrderDetail(int id);
    }
}
