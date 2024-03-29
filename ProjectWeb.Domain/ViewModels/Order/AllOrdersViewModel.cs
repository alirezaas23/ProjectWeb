﻿namespace ProjectWeb.Domain.ViewModels.Order
{
    public class AllOrdersViewModel
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public string OrderDateTime { get; set; }
        public int Sum { get; set; }
        public int ShouldPaySum { get; set; }
        public int LeftSum { get; set; }
        public bool IsFinally { get; set; }
        public bool FinalyPay { get; set; }
    }
}
