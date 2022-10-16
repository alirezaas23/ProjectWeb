
namespace ProjectWeb.Domain.ViewModels.Order
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
        public string Description { get; set; }
    }
}
