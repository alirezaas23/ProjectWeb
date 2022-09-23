using ProjectWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Domain.Interfaces
{
    public interface IOrderRepository
    {
        void UpdateOrder(Order order);
        void UpdateSum(int OrderId);
        Order IsOrderInUse(string userId);
        void AddOrder(Order order);
        Order FindOrder(int orderId);
        int FinallyOrders();
        void SaveChanges();
        IEnumerable<Order> MyOrders(string userId);
        Order FindFinalyOrder(int orderId);
        List<Order> ShowFinallyOrders();
        int UserPaysSum();
    }
}
