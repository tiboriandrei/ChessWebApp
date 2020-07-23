using Microsoft.EntityFrameworkCore.Migrations;

namespace ChessWebApp.Migrations
{
    public partial class ChessContext2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MatchHistory",
                table: "Players",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MatchHistory",
                table: "Players");
        }
    }
}
