using Microsoft.EntityFrameworkCore;
using ProjectWeb.Domain.Models;
using ProjectWeb.Domain.Models.Account;
using ProjectWeb.Domain.Models.Location;
using ProjectWeb.Domain.Models.SiteSetting;
using System;

namespace ProjectWeb.Infra.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }

        #region DbSet

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<WebProduct> WebProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<EmailSetting> EmailSettings { get; set; }
        public DbSet<State> States { get; set; }

        #endregion

        #region Seed Data

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var date = DateTime.MinValue;
            modelBuilder.Entity<EmailSetting>().HasData(new EmailSetting()
            {
                Password = "aocrhtadtphauyjl",
                CreateDateTime = date,
                DisplayName = "WebMaker",
                EnbaleSSL = true,
                From = "alirezaasgari685@gmail.com",
                IsDefault = true,
                IsDelete = false,
                Port = 587,
                SMTP = "smtp.gmail.com",
                Id = 1
            });

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
