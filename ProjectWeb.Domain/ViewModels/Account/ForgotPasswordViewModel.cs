using ProjectWeb.Domain.ViewModels.Common;
using System.ComponentModel.DataAnnotations;

namespace ProjectWeb.Domain.ViewModels.Account
{
    public class ForgotPasswordViewModel : GoogleReCaptchaViewModel
    {
        [Display(Name = "ایمیل")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} باشد.")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معبتر نمی باشد.")]
        public string Email { get; set; }
    }

    public enum ForgotPasswordResult
    {
        Success,
        UserNotFound,
        UserIsBan
    }
}
