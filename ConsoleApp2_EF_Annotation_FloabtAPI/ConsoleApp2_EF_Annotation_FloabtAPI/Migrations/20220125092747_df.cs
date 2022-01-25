using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp2_EF_Annotation_FloabtAPI.Migrations
{
    public partial class df : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "CarTable",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarsDA",
                columns: table => new
                {
                    MySpecialId = table.Column<int>(type: "int", nullable: false),
                    CompanyId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarsDA", x => x.MySpecialId);
                    table.ForeignKey(
                        name: "FK_CarsDA_CarTable_MySpecialId",
                        column: x => x.MySpecialId,
                        principalTable: "CarTable",
                        principalColumn: "MySpecialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarsDA_Companies_CompanyId1",
                        column: x => x.CompanyId1,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarTable_CompanyId",
                table: "CarTable",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CarsDA_CompanyId1",
                table: "CarsDA",
                column: "CompanyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CarTable_Companies_CompanyId",
                table: "CarTable",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarTable_Companies_CompanyId",
                table: "CarTable");

            migrationBuilder.DropTable(
                name: "CarsDA");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_CarTable_CompanyId",
                table: "CarTable");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "CarTable");
        }
    }
}
