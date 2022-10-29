using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models;
using ProjectWeb.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjectWeb.Infra.Data.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        #region Ctor

        private readonly ApplicationContext _ctx;
        public OrderDetailRepository(ApplicationContext ctx)
        {
            this._ctx = ctx;
        }

        #endregion
        
        public OrderDetail FindById(int id)
        {
            return _ctx.OrderDetails.Find(id);
        }

        public async Task SaveChanges()
        {
            await _ctx.SaveChangesAsync();
        }

        public IEnumerable<OrderDetail> GetOrderDetails(int orderId)
        {
            return _ctx.OrderDetails.Where(o => o.OrderId == orderId).ToList();
        }

        public async Task<OrderDetail> IsProductInUse(long orderId, long productId)
        {
            return await _ctx.OrderDetails.FirstOrDefaultAsync(o =>
                o.OrderId.Equals(orderId) && o.WebProductId.Equals(productId));
        }

        public async Task AddOrderDetail(OrderDetail orderDetail)
        {
            await _ctx.OrderDetails.AddAsync(orderDetail);
        }

        public void RemoveOrderDetail(int id)
        {
            var order = FindById(id);
            _ctx.OrderDetails.Remove(order);
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            _ctx.OrderDetails.Update(orderDetail);
        }
    }
}
