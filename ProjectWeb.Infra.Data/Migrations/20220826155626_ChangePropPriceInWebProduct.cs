using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectWeb.Infra.Data.Migrations
{
    public partial class ChangePropPriceInWebProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "WebProductPrice",
                table: "WebProducts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "WebProductPrice",
                table: "WebProducts",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
