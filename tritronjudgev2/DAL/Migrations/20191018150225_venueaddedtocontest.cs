using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class venueaddedtocontest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Contests",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BackgroundImage",
                table: "Contests",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Venue",
                table: "Contests",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Venue",
                table: "Contests");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Contests",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "BackgroundImage",
                table: "Contests",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
