using ProjectWeb.Application.Interfaces;
using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectWeb.Application.Services
{
    public class OrderDetailService : IOrderDetailInterface
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            this._orderDetailRepository = orderDetailRepository;
        }

        public async Task<OrderDetail> IsProductInUse(long orderId, long productId)
        {
            return await _orderDetailRepository.IsProductInUse(orderId, productId);
        }

        public async Task AddOrderDetail(OrderDetail orderDetail)
        {
            await _orderDetailRepository.AddOrderDetail(orderDetail);
        }

        public IEnumerable<OrderDetail> GetOrderDetails(int orderId)
        {
            return _orderDetailRepository.GetOrderDetails(orderId);
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
