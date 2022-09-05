﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectWeb.Infra.Data.Context;

namespace ProjectWeb.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220905170243_AddWebTypeInOrderDetail")]
    partial class AddWebTypeInOrderDetail
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectWeb.Domain.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsFinally")
                        .HasColumnType("bit");

                    b.Property<string>("OrderDateTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sum")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ProjectWeb.Domain.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("WebProductId")
                        .HasColumnType("int");

                    b.Property<string>("WebType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("WebProductId");

                    b.ToTable("OrderDetails");
                });

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

                    b.Property<long>("WebProductPrice")
                        .HasColumnType("bigint");

                    b.HasKey("WebProductID");

                    b.ToTable("WebProducts");
                });

            modelBuilder.Entity("ProjectWeb.Domain.Models.OrderDetail", b =>
                {
                    b.HasOne("ProjectWeb.Domain.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectWeb.Domain.Models.WebProduct", "WebProduct")
                        .WithMany("OrderDetails")
                        .HasForeignKey("WebProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("WebProduct");
                });

            modelBuilder.Entity("ProjectWeb.Domain.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("ProjectWeb.Domain.Models.WebProduct", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
