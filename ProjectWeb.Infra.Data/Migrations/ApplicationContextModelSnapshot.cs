﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectWeb.Infra.Data.Context;

namespace ProjectWeb.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectWeb.Domain.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TicketDateTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TicketSubject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TicketText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TicketId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("ProjectWeb.Domain.Models.WebProduct", b =>
                {
                    b.Property<int>("WebProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("WebProductDeliverDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebProductDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebProductImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("WebProductPrice")
                        .HasColumnType("float");

                    b.HasKey("WebProductID");

                    b.ToTable("WebProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
