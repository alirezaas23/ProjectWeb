using Microsoft.EntityFrameworkCore;
using ProjectWeb.Domain.Models;

namespace ProjectWeb.Infra.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketAnswer> TicketAnswers { get; set; }
        public DbSet<TicketsCollection> TicketsCollections { get; set; }
    }
}
