using System.Collections.Generic;

namespace ProjectWeb.Domain.ViewModels.ManageUser
{
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
