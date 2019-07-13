using Microsoft.EntityFrameworkCore.Migrations;

namespace tritronAPI.Migrations
{
    public partial class nullcolumnforcontestid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problems_Contest_Contest_Id",
                table: "Problems");

            migrationBuilder.AlterColumn<int>(
                name: "Contest_Id",
                table: "Problems",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_Contest_Contest_Id",
                table: "Problems",
                column: "Contest_Id",
                principalTable: "Contest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problems_Contest_Contest_Id",
                table: "Problems");

            migrationBuilder.AlterColumn<int>(
                name: "Contest_Id",
                table: "Problems",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_Contest_Contest_Id",
                table: "Problems",
                column: "Contest_Id",
                principalTable: "Contest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
