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
        IEnumerable<OrderDetail> GetOrderDetails(int orderId);
        void RemoveOrderDetail(int id);
        OrderDetail FindById(int id);

        //Show OrderDetail For My Orders In Profile View
        OrderDetail MyOrderDetails(int orderId);
    }
}
