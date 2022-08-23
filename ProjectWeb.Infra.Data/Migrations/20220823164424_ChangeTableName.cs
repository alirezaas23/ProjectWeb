using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectWeb.Infra.Data.Migrations
{
    public partial class ChangeTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket_TicketAnswers");

            migrationBuilder.CreateTable(
                name: "TicketsCollections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    TicketAnswerId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_TicketsCollections_TicketAnswerId",
                table: "TicketsCollections",
                column: "TicketAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketsCollections_TicketId",
                table: "TicketsCollections",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketsCollections");

            migrationBuilder.CreateTable(
                name: "Ticket_TicketAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketAnswerId = table.Column<int>(type: "int", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket_TicketAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_TicketAnswers_TicketAnswers_TicketAnswerId",
                        column: x => x.TicketAnswerId,
                        principalTable: "TicketAnswers",
                        principalColumn: "TicketAnswerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_TicketAnswers_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TicketAnswers_TicketAnswerId",
                table: "Ticket_TicketAnswers",
                column: "TicketAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TicketAnswers_TicketId",
                table: "Ticket_TicketAnswers",
                column: "TicketId");
        }
    }
}
