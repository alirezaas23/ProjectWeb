using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ProjectWeb.Domain.ViewModels.UserPanel.Account
{
    public class EditUserViewModel
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} باشد.")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} باشد.")]
        public string LastName { get; set; }

        [Display(Name = "شماره تماس")]
        public string PhoneNumber { get; set; }

        [Display(Name = "تاریخ تولد")]
        [RegularExpression(@"^\d{4}/((0\d)|(1[012]))/(([012]\d)|3[01])$", ErrorMessage = "تاریخ وارد شده معتبر نمی باشد.")]
        public string BirthDate { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "شهر")]
        public long? CountryId { get; set; }

        [Display(Name = "استان")]
        public long? CityId { get; set; }
    }

    public enum EditUserResult
    {
        Success,
        NotValidDate
    }
}
