using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class changeforeignkeypropofsubmission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submission_Problems_ProblemId",
                table: "Submission");

            migrationBuilder.DropIndex(
                name: "IX_Submission_ProblemId",
                table: "Submission");

            migrationBuilder.DropColumn(
                name: "ProblemId",
                table: "Submission");

            migrationBuilder.CreateIndex(
                name: "IX_Submission_Problem_Id",
                table: "Submission",
                column: "Problem_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Submission_Problems_Problem_Id",
                table: "Submission",
                column: "Problem_Id",
                principalTable: "Problems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submission_Problems_Problem_Id",
                table: "Submission");

            migrationBuilder.DropIndex(
                name: "IX_Submission_Problem_Id",
                table: "Submission");

            migrationBuilder.AddColumn<int>(
                name: "ProblemId",
                table: "Submission",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Submission_ProblemId",
                table: "Submission",
                column: "ProblemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Submission_Problems_ProblemId",
                table: "Submission",
                column: "ProblemId",
                principalTable: "Problems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
