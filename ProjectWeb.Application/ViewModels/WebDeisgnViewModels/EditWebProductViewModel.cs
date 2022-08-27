using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;

namespace ProjectWeb.Application.ViewModels.WebDeisgnViewModels
{
    public class EditWebProductViewModel
    {
        public int WebProductID { get; set; }

        [Display(Name = "تصویر جدید محصول")]
        public IFormFile WebProductImage { get; set; }

        [Display(Name = "تصویر فعلی محصول")]
        public string ImageUrl { get; set; }

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
        [AllowHtml]
        public string WebProductDescription { get; set; }

        [Required(ErrorMessage = "لطفا زمان تحویل را وارد کنید")]
        [Display(Name = "زمان تحویل")]
        public string WebProductDeliverDate { get; set; }
    }
}
