using ProjectWeb.Domain.Models;
using System.Collections.Generic;

namespace ProjectWeb.Application.Interfaces
{
    public interface IOrderDetailInterface
    {
        void UpdateOrderDetail(OrderDetail orderDetail);
        OrderDetail IsProductInUse(int orderId, int productId);
        void AddOrderDetail(OrderDetail orderDetail);
        IEnumerable<OrderDetail> GetOrderDetails(int orderId);
        void RemoveOrderDetail(int id);
    }
}
