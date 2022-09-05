using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectWeb.Infra.Data.Migrations
{
    public partial class AddWebTypeInOrderDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WebType",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WebType",
                table: "OrderDetails");
        }
    }
}
