﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.Application.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "لطفا نام کاربری را وارد کنید")]
        [Display(Name = "نام کاربری")]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "نام کاربری باید حداقل 5 کاراکتر باشد")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "لطفا ایمیل خود را وارد کنید")]
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "لطفا ایمیل معتبری وارد کنید")]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفا کلمه عبور را وارد کنید")]
        [Display(Name = "کلمه عبور")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "کلمه عبور باید حداقل 6 کاراکتر باشد")]
        [MaxLength(255)]
        public string Password { get; set; }

        [Required(ErrorMessage = "لطفا تکرار کلمه عبور را وارد کنید")]
        [Display(Name = "تکرار کلمه عبور")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "کلمه عبور و تکرارش یکسان نیست")]
        [MaxLength(255)]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "لطفا نام کاربری را وارد کنید")]
        [Display(Name = "نام کاربری")]
        [MaxLength(255)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "لطفا کلمه عبور را وارد کنید")]
        [Display(Name = "کلمه عبور")]
        [DataType(DataType.Password)]
        [MaxLength(255)]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
