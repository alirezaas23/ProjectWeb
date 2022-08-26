using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectWeb.Infra.Data.Migrations
{
    public partial class AddWebProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WebProducts",
                columns: table => new
                {
                    WebProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebProductImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebProductPrice = table.Column<double>(type: "float", nullable: false),
                    WebProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebProductDeliverDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebProducts", x => x.WebProductID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WebProducts");
        }
    }
}
