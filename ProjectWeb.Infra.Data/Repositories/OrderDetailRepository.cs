using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models;
using ProjectWeb.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectWeb.Infra.Data.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly ApplicationContext _ctx;

        public OrderDetailRepository(ApplicationContext ctx)
        {
            this._ctx = ctx;
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            _ctx.OrderDetails.Add(orderDetail);
            SaveChanges();
        }

        public OrderDetail IsProductInUse(int orderId, int productId)
        {
            return _ctx.OrderDetails.SingleOrDefault(o => o.OrderId == orderId && o.WebProductId == productId);
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            _ctx.OrderDetails.Update(orderDetail);
            SaveChanges();
        }
    }
}
