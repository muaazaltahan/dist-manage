using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dist_manage.Migrations
{
    public partial class updatecardtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BlueCardId",
                table: "CardsDB",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FamilyId",
                table: "CardsDB",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FatherStatus",
                table: "CardsDB",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FormId",
                table: "CardsDB",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "HasBlueCard",
                table: "CardsDB",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Verification",
                table: "CardsDB",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlueCardId",
                table: "CardsDB");

            migrationBuilder.DropColumn(
                name: "FamilyId",
                table: "CardsDB");

            migrationBuilder.DropColumn(
                name: "FatherStatus",
                table: "CardsDB");

            migrationBuilder.DropColumn(
                name: "FormId",
                table: "CardsDB");

            migrationBuilder.DropColumn(
                name: "HasBlueCard",
                table: "CardsDB");

            migrationBuilder.DropColumn(
                name: "Verification",
                table: "CardsDB");
        }
    }
}
