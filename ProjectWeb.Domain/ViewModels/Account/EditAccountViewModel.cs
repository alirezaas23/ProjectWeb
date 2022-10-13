using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectWeb.Domain.ViewModels.Account
{
    public class EditAccountViewModel
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "لطفا نام خود را وارد کنید")]
        [Display(Name = "نام")]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "لطفا نام خانوادگی خود را وارد کنید")]
        [Display(Name = "نام خانوادگی")]
        [StringLength(255)]
        public string LastName { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفا شماره تماس خود را وارد کنید")]
        [Display(Name = "شماره تماس")]
        public string PhoneNumber { get; set; }

        public string UserName { get; set; }
    }
}
