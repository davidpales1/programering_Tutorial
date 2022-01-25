using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp2_EF_Annotation_FloabtAPI.Migrations
{
    public partial class n : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.RenameTable(
                name: "Cars",
                newName: "CarTable");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "CarTable",
                newName: "ModelDA");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarTable",
                table: "CarTable",
                column: "MySpecialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CarTable",
                table: "CarTable");

            migrationBuilder.RenameTable(
                name: "CarTable",
                newName: "Cars");

            migrationBuilder.RenameColumn(
                name: "ModelDA",
                table: "Cars",
                newName: "Model");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "MySpecialId");
        }
    }
}
