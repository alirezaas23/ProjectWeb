using ProjectWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Order IsOrderInUse(string userId);
        void UpdateSum(int OrderId);
        void AddOrder(Order order);
    }
}
