using Microsoft.AspNetCore.Identity;

namespace ProjectWeb.Domain.Models
{
    public class UserApp : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
