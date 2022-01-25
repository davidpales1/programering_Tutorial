using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp2_EF_Annotation_FloabtAPI.Migrations
{
    public partial class j : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModelDA",
                table: "CarTable",
                newName: "ModelFluent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModelFluent",
                table: "CarTable",
                newName: "ModelDA");
        }
    }
}
