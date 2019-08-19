using Microsoft.EntityFrameworkCore.Migrations;

namespace tritronAPI.Migrations
{
    public partial class addedcontesttype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContestType",
                table: "Contests",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContestType",
                table: "Contests");
        }
    }
}
