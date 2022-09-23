using ProjectWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Application.Interfaces
{
    public interface IOrderInterface
    {
        void UpdateSum(int OrderId);
        Order IsOrderInUse(string userId);
        void AddOrder(Order order);
        int FinallyOrders();
        Order FindOrder(int orderId);
        void UpdateOrder(Order order);
        IEnumerable<Order> MyOrders(string userId);
        Order FindFinalyOrder(int orderId);
        List<Order> ShowFinallyOrders();
        int UserPaysSum();
    }
}
