using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "لطفا نوع سایت خود را انتخاب کنید")]
        public string WebType { get; set; }

        [Required(ErrorMessage = "لطفا توضیحات را وارد کنید")]
        public string Description { get; set; }
    }
}
