using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Application.ViewModels.OrderViewModels
{
    public class ComponentOrderDetailViewModel
    {
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int ProductId { get; set; }
        public int OrderDetailId { get; set; }
    }
}
