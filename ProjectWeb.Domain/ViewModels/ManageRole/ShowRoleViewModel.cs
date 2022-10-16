using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProjectWeb.Domain.ViewModels.ManageRole
{
    public class ShowRoleViewModel
    {
        public string RoleId { get; set; }

        [Required(ErrorMessage = "نام مقام جدید را وارد کنید")]
        [MaxLength(255)]
        [Remote("IsRoleInUse", "ManageRoles", HttpMethod = "POST", AdditionalFields = "__RequestVerificationToken")]
        public string RoleName { get; set; }
    }
}
