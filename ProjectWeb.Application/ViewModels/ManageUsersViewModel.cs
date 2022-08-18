using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectWeb.Application.ViewModels
{
    public class ShowUsersViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class ShowUserViewModel
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "لطفا نام کاربری جدید را وارد کنید")]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "نام کاربری باید حداقل 5 کاراکتر باشد")]
        [Remote("IsUserNameInUse", "Account", HttpMethod = "POST", AdditionalFields = "__RequestVerificationToken")]
        public string UserName { get; set; }
        public string UserEmail { get; set; }
    }

    public class AddUserToRoleViewModel
    {
        public AddUserToRoleViewModel()
        {
            UserRoles = new List<UserRolesViewModel>();
        }
        public string UserId { get; set; }
        public List<UserRolesViewModel> UserRoles { get; set; }

    }

    public class UserRolesViewModel
    {
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }
    }
}
