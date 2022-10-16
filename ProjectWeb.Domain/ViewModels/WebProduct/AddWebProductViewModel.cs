using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ProjectWeb.Domain.ViewModels.WebProduct
{
    public class AddWebProductViewModel
    {
        [Required(ErrorMessage = "لطفا تصویر را وارد کنید")]
        [Display(Name = "تصویر محصول وب")]
        public IFormFile WebProductImage { get; set; }

        [Required(ErrorMessage = "لطفا نام را وارد کنید")]
        [Display(Name = "نام محصول وب")]
        [MaxLength(255)]
        public string WebProductName { get; set; }

        [Required(ErrorMessage = "لطفا قیمت را وارد کنید")]
        [Display(Name = "قیمت محصول وب")]
        public long WebProductPrice { get; set; }

        [Required(ErrorMessage = "لطفا توضیحات را وارد کنید")]
        [Display(Name = "توضیحات محصول وب")]
        [DataType(DataType.MultilineText)]
        //[AllowHtml]
        public string WebProductDescription { get; set; }

        [Required(ErrorMessage = "لطفا زمان تحویل را وارد کنید")]
        [Display(Name = "زمان تحویل")]
        public string WebProductDeliverDate { get; set; }
    }
}
