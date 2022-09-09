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
    }
}
