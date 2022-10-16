using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProjectWeb.Domain.ViewModels.ManageRole
{
    public class AddRoleViewModel
    {
        [Required(ErrorMessage = "لطفا نام مقام را وارد کنید")]
        [Display(Name = "نام مقام")]
        [MaxLength(255)]
        [Remote("IsRoleInUse", "ManageRoles", HttpMethod = "POST", AdditionalFields = "__RequestVerificationToken")]
        public string RoleName { get; set; }
    }
}
