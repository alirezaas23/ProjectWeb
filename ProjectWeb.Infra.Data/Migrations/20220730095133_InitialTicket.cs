using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ProjectWeb.Infra.Data.Migrations
{
    public partial class InitialTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TicketText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
