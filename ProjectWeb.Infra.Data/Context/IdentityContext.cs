using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectWeb.Domain.Models;

namespace ProjectWeb.Infra.Data.Context
{
    public class IdentityContext : IdentityDbContext<UserApp>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options) { }
    }
}
