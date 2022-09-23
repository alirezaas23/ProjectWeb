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

        public int FinallyOrders()
        {
            return _ctx.Orders.Where(o => o.IsFinally).Count();
        }

        public Order FindFinalyOrder(int orderId)
        {
            return _ctx.Orders.SingleOrDefault(o => o.OrderId == orderId && o.IsFinally);
        }

        public Order FindOrder(int orderId)
        {
            return _ctx.Orders.Find(orderId);
        }

        public Order IsOrderInUse(string userId)
        {
            return _ctx.Orders.SingleOrDefault(o => o.UserId == userId && !o.IsFinally);
        }

        public IEnumerable<Order> MyOrders(string userId)
        {
            return _ctx.Orders.Where(o => o.UserId == userId && o.IsFinally).ToList();
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }

        public List<Order> ShowFinallyOrders()
        {
            return _ctx.Orders.Where(o => o.IsFinally).ToList();
        }

        public void UpdateOrder(Order order)
        {
            _ctx.Orders.Update(order);
            SaveChanges();
        }

        public void UpdateSum(int OrderId)
        {
            var order = FindOrder(OrderId);
            order.Sum = _ctx.OrderDetails.Where(o => o.OrderId == order.OrderId).Select(o => o.Count * o.Price).Sum();
            order.ShouldPaySum = order.Sum / 2;
            order.LeftSum = order.Sum - order.ShouldPaySum;
            UpdateOrder(order);
            SaveChanges();
        }

        public int UserPaysSum()
        {
            return _ctx.Orders.Where(o => o.IsFinally).Sum(o => o.Sum);
        }
    }
}
