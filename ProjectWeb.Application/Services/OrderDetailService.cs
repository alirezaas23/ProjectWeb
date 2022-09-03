﻿using ProjectWeb.Application.Interfaces;
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
    }
}