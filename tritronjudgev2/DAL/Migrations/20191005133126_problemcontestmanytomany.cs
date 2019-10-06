using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class problemcontestmanytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContestProblem",
                columns: table => new
                {
                    ContestId = table.Column<int>(nullable: false),
                    ProblemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestProblem", x => new { x.ContestId, x.ProblemId });
                    table.ForeignKey(
                        name: "FK_ContestProblem_Contests_ContestId",
                        column: x => x.ContestId,
                        principalTable: "Contests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContestProblem_Problems_ProblemId",
                        column: x => x.ProblemId,
                        principalTable: "Problems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContestProblem_ProblemId",
                table: "ContestProblem",
                column: "ProblemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContestProblem");
        }
    }
}
