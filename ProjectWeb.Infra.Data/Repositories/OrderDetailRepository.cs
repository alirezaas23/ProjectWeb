using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models;
using ProjectWeb.Infra.Data.Context;
using System;
using System.Collections.Generic;
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

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }
    }
}
