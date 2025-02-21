using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dist_manage.Migrations
{
    public partial class initialdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgramsDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramsDB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SectionsDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionsDB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardsDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sectionid = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Members = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardsDB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardsDB_SectionsDB_Sectionid",
                        column: x => x.Sectionid,
                        principalTable: "SectionsDB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Link_Prog_UserDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    ProgramsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link_Prog_UserDB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Link_Prog_UserDB_ProgramsDB_ProgramsId",
                        column: x => x.ProgramsId,
                        principalTable: "ProgramsDB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Link_Prog_UserDB_UsersDB_UsersId",
                        column: x => x.UsersId,
                        principalTable: "UsersDB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectionUsersDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    SectionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionUsersDB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionUsersDB_SectionsDB_SectionsId",
                        column: x => x.SectionsId,
                        principalTable: "SectionsDB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionUsersDB_UsersDB_UsersId",
                        column: x => x.UsersId,
                        principalTable: "UsersDB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Link_Prog_CardDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramsId = table.Column<int>(type: "int", nullable: false),
                    CardsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link_Prog_CardDB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Link_Prog_CardDB_CardsDB_CardsId",
                        column: x => x.CardsId,
                        principalTable: "CardsDB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Link_Prog_CardDB_ProgramsDB_ProgramsId",
                        column: x => x.ProgramsId,
                        principalTable: "ProgramsDB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogsDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link_Prog_CardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogsDB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogsDB_Link_Prog_CardDB_Link_Prog_CardId",
                        column: x => x.Link_Prog_CardId,
                        principalTable: "Link_Prog_CardDB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LogsDB_UsersDB_UsersId",
                        column: x => x.UsersId,
                        principalTable: "UsersDB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    Result = table.Column<bool>(type: "bit", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Link_Prog_CardId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestDB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestDB_Link_Prog_CardDB_Link_Prog_CardId",
                        column: x => x.Link_Prog_CardId,
                        principalTable: "Link_Prog_CardDB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RequestDB_UsersDB_AdminId",
                        column: x => x.AdminId,
                        principalTable: "UsersDB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RequestDB_UsersDB_UsersId",
                        column: x => x.UsersId,
                        principalTable: "UsersDB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardsDB_Sectionid",
                table: "CardsDB",
                column: "Sectionid");

            migrationBuilder.CreateIndex(
                name: "IX_Link_Prog_CardDB_CardsId",
                table: "Link_Prog_CardDB",
                column: "CardsId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_Prog_CardDB_ProgramsId",
                table: "Link_Prog_CardDB",
                column: "ProgramsId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_Prog_UserDB_ProgramsId",
                table: "Link_Prog_UserDB",
                column: "ProgramsId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_Prog_UserDB_UsersId",
                table: "Link_Prog_UserDB",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_LogsDB_Link_Prog_CardId",
                table: "LogsDB",
                column: "Link_Prog_CardId");

            migrationBuilder.CreateIndex(
                name: "IX_LogsDB_UsersId",
                table: "LogsDB",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestDB_AdminId",
                table: "RequestDB",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestDB_Link_Prog_CardId",
                table: "RequestDB",
                column: "Link_Prog_CardId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestDB_UsersId",
                table: "RequestDB",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionUsersDB_SectionsId",
                table: "SectionUsersDB",
                column: "SectionsId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionUsersDB_UsersId",
                table: "SectionUsersDB",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Link_Prog_UserDB");

            migrationBuilder.DropTable(
                name: "LogsDB");

            migrationBuilder.DropTable(
                name: "RequestDB");

            migrationBuilder.DropTable(
                name: "SectionUsersDB");

            migrationBuilder.DropTable(
                name: "Link_Prog_CardDB");

            migrationBuilder.DropTable(
                name: "UsersDB");

            migrationBuilder.DropTable(
                name: "CardsDB");

            migrationBuilder.DropTable(
                name: "ProgramsDB");

            migrationBuilder.DropTable(
                name: "SectionsDB");
        }
    }
}
