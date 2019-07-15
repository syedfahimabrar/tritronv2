using Microsoft.EntityFrameworkCore.Migrations;

namespace tritronAPI.Migrations
{
    public partial class foreignkeyaddedinmodelbuilder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contest_ProgrammingLanguage_Name",
                table: "Contest");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammingLanguage_Contest_ContestId",
                table: "ProgrammingLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammingLanguage_Contest_ContestId1",
                table: "ProgrammingLanguage");

            migrationBuilder.DropIndex(
                name: "IX_ProgrammingLanguage_ContestId",
                table: "ProgrammingLanguage");

            migrationBuilder.DropIndex(
                name: "IX_ProgrammingLanguage_ContestId1",
                table: "ProgrammingLanguage");

            migrationBuilder.DropIndex(
                name: "IX_Contest_Name",
                table: "Contest");

            migrationBuilder.DropColumn(
                name: "ContestId",
                table: "ProgrammingLanguage");

            migrationBuilder.DropColumn(
                name: "ContestId1",
                table: "ProgrammingLanguage");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Contest",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ContestProgrammingLanguage",
                columns: table => new
                {
                    Contest_id = table.Column<int>(nullable: false),
                    ProgrammingLanguage_Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestProgrammingLanguage", x => new { x.Contest_id, x.ProgrammingLanguage_Id });
                    table.ForeignKey(
                        name: "FK_ContestProgrammingLanguage_Contest_Contest_id",
                        column: x => x.Contest_id,
                        principalTable: "Contest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContestProgrammingLanguage_ProgrammingLanguage_ProgrammingLanguage_Id",
                        column: x => x.ProgrammingLanguage_Id,
                        principalTable: "ProgrammingLanguage",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContestProgrammingLanguage_ProgrammingLanguage_Id",
                table: "ContestProgrammingLanguage",
                column: "ProgrammingLanguage_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContestProgrammingLanguage");

            migrationBuilder.AddColumn<int>(
                name: "ContestId",
                table: "ProgrammingLanguage",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContestId1",
                table: "ProgrammingLanguage",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Contest",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammingLanguage_ContestId",
                table: "ProgrammingLanguage",
                column: "ContestId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammingLanguage_ContestId1",
                table: "ProgrammingLanguage",
                column: "ContestId1");

            migrationBuilder.CreateIndex(
                name: "IX_Contest_Name",
                table: "Contest",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Contest_ProgrammingLanguage_Name",
                table: "Contest",
                column: "Name",
                principalTable: "ProgrammingLanguage",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammingLanguage_Contest_ContestId",
                table: "ProgrammingLanguage",
                column: "ContestId",
                principalTable: "Contest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammingLanguage_Contest_ContestId1",
                table: "ProgrammingLanguage",
                column: "ContestId1",
                principalTable: "Contest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
