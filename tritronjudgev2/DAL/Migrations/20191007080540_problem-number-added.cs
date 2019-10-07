using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class problemnumberadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problems_Contests_ContestId",
                table: "Problems");

            migrationBuilder.DropIndex(
                name: "IX_Problems_ContestId",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "ContestId",
                table: "Problems");

            migrationBuilder.AddColumn<string>(
                name: "ProblemNumber",
                table: "ContestProblem",
                maxLength: 1,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProblemNumber",
                table: "ContestProblem");

            migrationBuilder.AddColumn<int>(
                name: "ContestId",
                table: "Problems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Problems_ContestId",
                table: "Problems",
                column: "ContestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_Contests_ContestId",
                table: "Problems",
                column: "ContestId",
                principalTable: "Contests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
