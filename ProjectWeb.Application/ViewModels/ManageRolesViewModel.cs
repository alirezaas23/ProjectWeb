using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProjectWeb.Application.ViewModels
{
    public class AddRoleViewModel
    {
        [Required(ErrorMessage = "لطفا نام مقام را وارد کنید")]
        [Display(Name = "نام مقام")]
        [MaxLength(255)]
        [Remote("IsRoleInUse", "ManageRoles", HttpMethod = "POST", AdditionalFields = "__RequestVerificationToken")]
        public string RoleName { get; set; }
    }

    public class ShowRoleViewModel
    {
        public string RoleId { get; set; }

        [Required(ErrorMessage = "نام مقام جدید را وارد کنید")]
        [MaxLength(255)]
        [Remote("IsRoleInUse", "ManageRoles", HttpMethod = "POST", AdditionalFields = "__RequestVerificationToken")]
        public string RoleName { get; set; }
    }
}
