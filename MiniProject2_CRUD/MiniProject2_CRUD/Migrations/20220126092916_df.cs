using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniProject2_CRUD.Migrations
{
    public partial class df : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_LaptopId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_LaptopId1",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "LaptopId1",
                table: "Products",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "LaptopId",
                table: "Products",
                newName: "Laptop_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_LaptopId1",
                table: "Products",
                newName: "IX_Products_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_LaptopId",
                table: "Products",
                newName: "IX_Products_Laptop_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_Laptop_ProductId",
                table: "Products",
                column: "Laptop_ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_ProductId",
                table: "Products",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_Laptop_ProductId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_ProductId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products",
                newName: "LaptopId1");

            migrationBuilder.RenameColumn(
                name: "Laptop_ProductId",
                table: "Products",
                newName: "LaptopId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductId",
                table: "Products",
                newName: "IX_Products_LaptopId1");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Laptop_ProductId",
                table: "Products",
                newName: "IX_Products_LaptopId");

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
    }
}
