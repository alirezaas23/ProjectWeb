using ProjectWeb.Application.Interfaces;
using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectWeb.Application.Security;
using ProjectWeb.Domain.ViewModels.WebProduct;

namespace ProjectWeb.Application.Services
{
    public class OrderService : IOrderInterface
    {
        #region Ctor

        private readonly IOrderRepository _orderRepository;
        private readonly IWebProductInterface _webProductInterface;
        private readonly IOrderDetailInterface _orderDetailInterface;

        public OrderService(IOrderRepository orderRepository, IWebProductInterface webProductInterface,
            IOrderDetailInterface orderDetailInterface)
        {
            _orderRepository = orderRepository;
            _webProductInterface = webProductInterface;
            _orderDetailInterface = orderDetailInterface;
        }

        #endregion

        #region Add To Basket

        public async Task<AddOrderResult> AddOrderToBasket(ShowWebProductViewModel model, long userId)
        {
            var product = await _webProductInterface.FindById(model.WebProductId);
            var order = await _orderRepository.IsOrderInUse(userId);
            if (order == null)
            {
                order = new Order()
                {
                    FinalyPay = false,
                    IsFinally = false,
                    Sum = 0,
                    UserId = userId
                };

                await _orderRepository.AddNewOrder(order);

                var orderDetail = new OrderDetail()
                {
                    Count = 1,
                    Order = order,
                    OrderId = order.Id,
                    WebProduct = product,
                    Price = (int)product.WebProductPrice,
                    Description = model.Description.SanitizeText(),
                    WebType = model.WebType.SanitizeText(),
                    WebProductId = product.Id
                };

                await _orderDetailInterface.AddOrderDetail(orderDetail);
                await _orderRepository.SaveChanges();
            }

            else
            {
                var detail = await _orderDetailInterface.IsProductInUse(order.Id, model.WebProductId);
                if (detail == null)
                {
                    var orderDetail = new OrderDetail()
                    {
                        Count = 1,
                        Order = order,
                        OrderId = order.Id,
                        WebProduct = product,
                        Price = (int)product.WebProductPrice,
                        Description = model.Description.SanitizeText(),
                        WebType = model.WebType.SanitizeText(),
                        WebProductId = product.Id
                    };

                    await _orderDetailInterface.AddOrderDetail(orderDetail);
                    await _orderRepository.SaveChanges();
                }

                else
                {
                    return AddOrderResult.ProductInUse;
                }
            }

            await UpdateOrder(order.Id);

            return AddOrderResult.Success;
        }

        public async Task UpdateOrder(long orderId)
        {
            var order = await _orderRepository.GetOrderById(orderId);
            order.Sum = order.OrderDetails.Where(o => o.OrderId.Equals(orderId))
                .Select(o => o.Price * o.Count).Sum();

            order.ShouldPaySum = order.Sum / 2;
            order.LeftSum = order.Sum - order.ShouldPaySum;

            await _orderRepository.UpdateOrder(order);
            await _orderRepository.SaveChanges();
        }

        #endregion

        public int FinallyOrders()
        {
            return _orderRepository.FinallyOrders();
        }

        public Order FindFinalyOrder(int orderId)
        {
            // return _orderRepository.FindFinalyOrder(orderId);
            return null;
        }

        public Order IsOrderInUse(string userId)
        {
            //return _orderRepository.IsOrderInUse(userId);
            return null;
        }

        public IEnumerable<Order> MyOrders(string userId)
        {
            //return _orderRepository.MyOrders(userId);
            return null;
        }

        public List<Order> ShowFinallyOrders()
        {
            return _orderRepository.ShowFinallyOrders();
        }

        public void UpdateOrder(Order order)
        {
            //_orderRepository.UpdateOrder(order);
        }

        public int UserPaysSum()
        {
            return _orderRepository.UserPaysSum();
        }
    }
}