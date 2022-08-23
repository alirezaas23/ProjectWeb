using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectWeb.Infra.Data.Migrations
{
    public partial class TicketAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Ticket_TicketAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    TicketAnswerId = table.Column<int>(type: "int", nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket_TicketAnswers");

            migrationBuilder.DropTable(
                name: "TicketAnswers");
        }
    }
}
