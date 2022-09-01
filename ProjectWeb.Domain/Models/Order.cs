using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Domain.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public string OrderDateTime { get; set; }
        public int Sum { get; set; }
        public bool IsFinally { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
