using ProjectWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Domain.Interfaces
{
    public interface IOrderDetailRepository
    {
        void UpdateOrderDetail(OrderDetail orderDetail);
        OrderDetail IsProductInUse(int orderId, int productId);
        void AddOrderDetail(OrderDetail orderDetail);
        void SaveChanges();
    }
}
