using Microsoft.EntityFrameworkCore.Migrations;

namespace tritronAPI.Migrations
{
    public partial class languageaddedtoproblem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContestLanguages");

            migrationBuilder.CreateTable(
                name: "ProblemLanguages",
                columns: table => new
                {
                    ProblemId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    LanguageId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemLanguages", x => new { x.ProblemId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_ProblemLanguages_Languages_LanguageId1",
                        column: x => x.LanguageId1,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProblemLanguages_Problems_ProblemId",
                        column: x => x.ProblemId,
                        principalTable: "Problems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProblemLanguages_LanguageId1",
                table: "ProblemLanguages",
                column: "LanguageId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProblemLanguages");

            migrationBuilder.CreateTable(
                name: "ContestLanguages",
                columns: table => new
                {
                    ContestId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestLanguages", x => new { x.ContestId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_ContestLanguages_Contests_ContestId",
                        column: x => x.ContestId,
                        principalTable: "Contests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContestLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContestLanguages_LanguageId",
                table: "ContestLanguages",
                column: "LanguageId");
        }
    }
}
