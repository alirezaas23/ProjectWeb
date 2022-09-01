using Microsoft.EntityFrameworkCore;
using ProjectWeb.Domain.Models;

namespace ProjectWeb.Infra.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<WebProduct> WebProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
