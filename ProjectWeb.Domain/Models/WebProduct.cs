using System.Collections.Generic;
using ProjectWeb.Domain.Models.Common;

namespace ProjectWeb.Domain.Models
{
    public class WebProduct : BaseEntity
    {
        public string WebProductImage { get; set; }
        public string WebProductName { get; set; }
        public long WebProductPrice { get; set; }
        public string WebProductDescription { get; set; }
        public string WebProductDeliverDate { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
