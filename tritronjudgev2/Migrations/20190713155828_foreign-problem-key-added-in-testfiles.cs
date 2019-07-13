using Microsoft.EntityFrameworkCore.Migrations;

namespace tritronAPI.Migrations
{
    public partial class foreignproblemkeyaddedintestfiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestFile_Problems_ProblemId",
                table: "TestFile");

            migrationBuilder.DropIndex(
                name: "IX_TestFile_ProblemId",
                table: "TestFile");

            migrationBuilder.DropColumn(
                name: "ProblemId",
                table: "TestFile");

            migrationBuilder.AddColumn<int>(
                name: "Problem_Id",
                table: "TestFile",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TestFile_Problem_Id",
                table: "TestFile",
                column: "Problem_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestFile_Problems_Problem_Id",
                table: "TestFile",
                column: "Problem_Id",
                principalTable: "Problems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestFile_Problems_Problem_Id",
                table: "TestFile");

            migrationBuilder.DropIndex(
                name: "IX_TestFile_Problem_Id",
                table: "TestFile");

            migrationBuilder.DropColumn(
                name: "Problem_Id",
                table: "TestFile");

            migrationBuilder.AddColumn<int>(
                name: "ProblemId",
                table: "TestFile",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestFile_ProblemId",
                table: "TestFile",
                column: "ProblemId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestFile_Problems_ProblemId",
                table: "TestFile",
                column: "ProblemId",
                principalTable: "Problems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
