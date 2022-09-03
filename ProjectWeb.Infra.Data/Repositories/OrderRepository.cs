using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models;
using ProjectWeb.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectWeb.Infra.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationContext _ctx;
        public OrderRepository(ApplicationContext ctx)
        {
            this._ctx = ctx;
        }

        public void AddOrder(Order order)
        {
            _ctx.Orders.Add(order);
        }

        public Order IsOrderInUse(string userId)
        {
            return _ctx.Orders.SingleOrDefault(o => o.UserId == userId && !o.IsFinally);
        }
    }
}
