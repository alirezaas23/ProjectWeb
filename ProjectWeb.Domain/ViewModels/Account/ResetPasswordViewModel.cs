using ProjectWeb.Domain.ViewModels.Common;
using System.ComponentModel.DataAnnotations;

namespace ProjectWeb.Domain.ViewModels.Account
{
    public class ResetPasswordViewModel : GoogleReCaptchaViewModel
    {
        [Display(Name = "کلمه عبور")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} باشد.")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} باشد.")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "کلمات عبور مغایرت دارند.")]
        public string RePassword { get; set; }

        [Required]
        public string ActivationCode { get; set; }
    }

    public enum ResetPasswordResult
    {
        Success,
        UserNotFound,
        UserIsBan
    }
}
