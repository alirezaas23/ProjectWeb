using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Domain.Models
{
    public class UserApp : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
