using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dist_manage.Migrations
{
    public partial class nullablesectionid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardsDB_SectionsDB_Sectionid",
                table: "CardsDB");

            migrationBuilder.AlterColumn<int>(
                name: "Sectionid",
                table: "CardsDB",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CardsDB_SectionsDB_Sectionid",
                table: "CardsDB",
                column: "Sectionid",
                principalTable: "SectionsDB",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardsDB_SectionsDB_Sectionid",
                table: "CardsDB");

            migrationBuilder.AlterColumn<int>(
                name: "Sectionid",
                table: "CardsDB",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CardsDB_SectionsDB_Sectionid",
                table: "CardsDB",
                column: "Sectionid",
                principalTable: "SectionsDB",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
