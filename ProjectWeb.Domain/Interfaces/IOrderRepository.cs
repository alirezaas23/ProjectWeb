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
        void SaveChanges();
    }
}
