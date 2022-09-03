using ProjectWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Application.Interfaces
{
    public interface IOrderDetailInterface
    {
        void AddOrderDetail(OrderDetail orderDetail);
        OrderDetail IsProductInUse(int orderId, int productId);
        void UpdateOrderDetail(OrderDetail orderDetail);
    }
}
