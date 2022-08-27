using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Application.ViewModels.WebDeisgnViewModels
{
    public class ShowWebProductViewModel
    {
        public int WebProductID { get; set; }
        public string WebProductImage { get; set; }
        public string WebProductName { get; set; }
        public long WebProductPrice { get; set; }
        public string WebProductDescription { get; set; }
        public string WebProductDeliverDate { get; set; }
    }
}
