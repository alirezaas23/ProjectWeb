using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Application.ViewModels.OrderViewModels
{
    public class ShowOrderDetailViewModel
    {
        public int OrderDetailId { get; set; }
        public string ImageName { get; set; }
        public string Title { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int Sum { get; set; }
        public int ProductId { get; set; }
        public string WebType { get; set; }
    }
}
