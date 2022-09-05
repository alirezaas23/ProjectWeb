using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectWeb.Domain.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int WebProductId { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public Order Order { get; set; }
        public WebProduct WebProduct { get; set; }
        public string WebType { get; set; }
    }
}
