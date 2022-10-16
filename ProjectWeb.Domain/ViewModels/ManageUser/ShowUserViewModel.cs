using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProjectWeb.Domain.ViewModels.ManageUser
{
    public class ShowUserViewModel
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "لطفا نام کاربری جدید را وارد کنید")]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "نام کاربری باید حداقل 5 کاراکتر باشد")]
        [Remote("IsUserNameInUse", "Account", HttpMethod = "POST", AdditionalFields = "__RequestVerificationToken")]
        public string UserName { get; set; }
        public string UserEmail { get; set; }
    }
}
