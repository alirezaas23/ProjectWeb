using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectWeb.Infra.Data.Migrations
{
    public partial class Add_Description_In_OrderDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "OrderDetails");
        }
    }
}
