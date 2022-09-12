using ProjectWeb.Application.Interfaces;
using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Application.Services
{
    public class OrderDetailService : IOrderDetailInterface
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            this._orderDetailRepository = orderDetailRepository;
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailRepository.AddOrderDetail(orderDetail);
        }

        public IEnumerable<OrderDetail> GetOrderDetails(int orderId)
        {
            return _orderDetailRepository.GetOrderDetails(orderId);
        }

        public OrderDetail IsProductInUse(int orderId, int productId)
        {
            return _orderDetailRepository.IsProductInUse(orderId, productId);
        }

        public OrderDetail MyOrderDetails(int orderId)
        {
            return _orderDetailRepository.MyOrderDetails(orderId);
        }

        public void RemoveOrderDetail(int id)
        {
            _orderDetailRepository.RemoveOrderDetail(id);
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailRepository.UpdateOrderDetail(orderDetail);
        }
    }
}
