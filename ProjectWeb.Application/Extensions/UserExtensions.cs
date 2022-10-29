using ProjectWeb.Domain.Models.Account;
using System.Linq;
using System.Security.Claims;

namespace ProjectWeb.Application.Extensions
{
    public static class UserExtensions
    {
        public static long GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            var identifier = claimsPrincipal.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (identifier == null) return 0;

            return long.Parse(identifier.Value);
        }

        public static string GetUserDisplayName(this User user)
        {
            if (!string.IsNullOrEmpty(user.FirstName) && !string.IsNullOrEmpty(user.LastName))
            {
                return $"{user.FirstName} {user.LastName}";
            }

            var email = user.Email.Split("@")[0];

            return email;
        }
    }
}
