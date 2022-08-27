using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ProjectWeb.Infra.Data.Migrations
{
    public partial class DeleteSomeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketsCollections");

            migrationBuilder.DropTable(
                name: "UserTicketCollections");

            migrationBuilder.DropTable(
                name: "TicketAnswers");

            migrationBuilder.DropTable(
                name: "UserApp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicketAnswers",
                columns: table => new
                {
                    TicketAnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketAnswerDateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketAnswerText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketAnswers", x => x.TicketAnswerId);
                });

            migrationBuilder.CreateTable(
                name: "UserApp",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserApp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketsCollections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketAnswerId = table.Column<int>(type: "int", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketsCollections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketsCollections_TicketAnswers_TicketAnswerId",
                        column: x => x.TicketAnswerId,
                        principalTable: "TicketAnswers",
                        principalColumn: "TicketAnswerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketsCollections_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTicketCollections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    UserAppId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTicketCollections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTicketCollections_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTicketCollections_UserApp_UserAppId",
                        column: x => x.UserAppId,
                        principalTable: "UserApp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketsCollections_TicketAnswerId",
                table: "TicketsCollections",
                column: "TicketAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketsCollections_TicketId",
                table: "TicketsCollections",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTicketCollections_TicketId",
                table: "UserTicketCollections",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTicketCollections_UserAppId",
                table: "UserTicketCollections",
                column: "UserAppId");
        }
    }
}
