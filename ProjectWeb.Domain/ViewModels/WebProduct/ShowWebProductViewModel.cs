using System.ComponentModel.DataAnnotations;

namespace ProjectWeb.Domain.ViewModels.WebProduct
{
    public class ShowWebProductViewModel
    {
        public long WebProductId { get; set; }
        public string WebProductImage { get; set; }
        public string WebProductName { get; set; }
        public long WebProductPrice { get; set; }
        public string WebProductDescription { get; set; }
        public string WebProductDeliverDate { get; set; }

        [Required(ErrorMessage = "لطفا نوع سایت خود را انتخاب کنید")]
        public string WebType { get; set; }

        [Required(ErrorMessage = "لطفا توضیحات را وارد کنید")]
        public string Description { get; set; }
    }

    public enum AddOrderResult
    {
        Success,
        ProductInUse
    }
}
