using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models;
using ProjectWeb.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectWeb.Domain.Models.Account;

namespace ProjectWeb.Infra.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        #region Ctor

        private readonly ApplicationContext _ctx;

        public OrderRepository(ApplicationContext ctx)
        {
            this._ctx = ctx;
        }

        #endregion

        public Task UpdateOrder(Order order)
        {
            _ctx.Update(order);
            return Task.CompletedTask;
        }

        public async Task<Order> IsOrderInUse(long userId)
        {
            return await _ctx.Orders.FirstOrDefaultAsync(o => o.UserId.Equals(userId) && !o.IsFinally);
        }

        public async Task AddNewOrder(Order order)
        {
            await _ctx.Orders.AddAsync(order);
        }

        public async Task<Order> GetOrderById(long orderId)
        {
            return await _ctx.Orders.SingleOrDefaultAsync(o => !o.IsDelete && o.Id.Equals(orderId));
        }

        public int FinallyOrders()
        {
            return _ctx.Orders.Where(o => o.IsFinally).Count();
        }

        // public Order FindFinalyOrder(int orderId)
        // {
        //     return _ctx.Orders.SingleOrDefault(o => o.OrderId == orderId && o.IsFinally);
        // }

        // public IEnumerable<Order> MyOrders(string userId)
        // {
        //     return _ctx.Orders.Where(o => o.UserId == userId && o.IsFinally).ToList();
        // }

        public async Task SaveChanges()
        {
            await _ctx.SaveChangesAsync();
        }

        public List<Order> ShowFinallyOrders()
        {
            return _ctx.Orders.Where(o => o.IsFinally).ToList();
        }

        public int UserPaysSum()
        {
            return _ctx.Orders.Where(o => o.IsFinally).Sum(o => o.Sum);
        }
    }
}