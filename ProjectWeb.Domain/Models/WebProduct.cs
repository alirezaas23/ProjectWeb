using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Domain.Models
{
    public class WebProduct
    {
        public int WebProductID { get; set; }
        public string WebProductImage { get; set; }
        public string WebProductName { get; set; }
        public double WebProductPrice { get; set; }
        public string WebProductDescription { get; set; }
        public string WebProductDeliverDate { get; set; }
    }
}
