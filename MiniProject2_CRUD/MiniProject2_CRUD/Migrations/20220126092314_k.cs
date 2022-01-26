using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniProject2_CRUD.Migrations
{
    public partial class k : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LaptopId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LaptopId1",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_LaptopId",
                table: "Products",
                column: "LaptopId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_LaptopId1",
                table: "Products",
                column: "LaptopId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_LaptopId",
                table: "Products",
                column: "LaptopId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_LaptopId1",
                table: "Products",
                column: "LaptopId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_LaptopId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_LaptopId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_LaptopId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_LaptopId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LaptopId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LaptopId1",
                table: "Products");
        }
    }
}
