using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ProjectWeb.Infra.Data.Migrations
{
    public partial class ChangeAllWebProductsMehods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_WebProducts_WebProductId",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WebProducts",
                table: "WebProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_WebProductId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "WebProductID",
                table: "WebProducts");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "WebProducts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                table: "WebProducts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "WebProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "WebProductId1",
                table: "OrderDetails",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WebProducts",
                table: "WebProducts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_WebProductId1",
                table: "OrderDetails",
                column: "WebProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_WebProducts_WebProductId1",
                table: "OrderDetails",
                column: "WebProductId1",
                principalTable: "WebProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_WebProducts_WebProductId1",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WebProducts",
                table: "WebProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_WebProductId1",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "WebProducts");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "WebProducts");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "WebProducts");

            migrationBuilder.DropColumn(
                name: "WebProductId1",
                table: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "WebProductID",
                table: "WebProducts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WebProducts",
                table: "WebProducts",
                column: "WebProductID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_WebProductId",
                table: "OrderDetails",
                column: "WebProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_WebProducts_WebProductId",
                table: "OrderDetails",
                column: "WebProductId",
                principalTable: "WebProducts",
                principalColumn: "WebProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
