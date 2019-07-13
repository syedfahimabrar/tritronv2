using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tritronAPI.Migrations
{
    public partial class multipletestaddedinproblem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InputData",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "OutputData",
                table: "Problems");

            migrationBuilder.CreateTable(
                name: "TestFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProblemId = table.Column<int>(nullable: true),
                    InputData = table.Column<byte[]>(nullable: true),
                    OutputData = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestFile_Problems_ProblemId",
                        column: x => x.ProblemId,
                        principalTable: "Problems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestFile_ProblemId",
                table: "TestFile",
                column: "ProblemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestFile");

            migrationBuilder.AddColumn<byte[]>(
                name: "InputData",
                table: "Problems",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "OutputData",
                table: "Problems",
                nullable: true);
        }
    }
}
