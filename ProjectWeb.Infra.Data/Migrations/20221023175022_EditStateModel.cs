using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectWeb.Infra.Data.Migrations
{
    public partial class EditStateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParnetId",
                table: "States");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ParnetId",
                table: "States",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
