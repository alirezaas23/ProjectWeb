using ProjectWeb.Application.Interfaces;
using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Application.Services
{
    public class OrderService : IOrderInterface
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        public void AddOrder(Order order)
        {
            _orderRepository.AddOrder(order);
        }

        public int FinallyOrders()
        {
            return _orderRepository.FinallyOrders();
        }

        public Order IsOrderInUse(string userId)
        {
            return _orderRepository.IsOrderInUse(userId);
        }

        public void UpdateSum(int OrderId)
        {
            _orderRepository.UpdateSum(OrderId);
        }
    }
}
