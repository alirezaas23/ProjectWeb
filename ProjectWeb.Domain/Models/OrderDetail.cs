using System.ComponentModel.DataAnnotations;

namespace ProjectWeb.Domain.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        public long OrderId { get; set; }
        public long WebProductId { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public Order Order { get; set; }
        public WebProduct WebProduct { get; set; }
        public string WebType { get; set; }
        public string Description { get; set; }
    }
}
