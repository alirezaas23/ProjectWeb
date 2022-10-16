using ProjectWeb.Application.Interfaces;
using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models;
using System.Collections.Generic;

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

        public Order FindFinalyOrder(int orderId)
        {
            return _orderRepository.FindFinalyOrder(orderId);
        }

        public Order FindOrder(int orderId)
        {
            return _orderRepository.FindOrder(orderId);
        }

        public Order IsOrderInUse(string userId)
        {
            return _orderRepository.IsOrderInUse(userId);
        }

        public IEnumerable<Order> MyOrders(string userId)
        {
            return _orderRepository.MyOrders(userId);
        }

        public List<Order> ShowFinallyOrders()
        {
            return _orderRepository.ShowFinallyOrders();
        }

        public void UpdateOrder(Order order)
        {
            _orderRepository.UpdateOrder(order);
        }

        public void UpdateSum(int OrderId)
        {
            _orderRepository.UpdateSum(OrderId);
        }

        public int UserPaysSum()
        {
            return _orderRepository.UserPaysSum();
        }
    }
}
