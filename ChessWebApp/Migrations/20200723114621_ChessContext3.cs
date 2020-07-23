using Microsoft.EntityFrameworkCore.Migrations;

namespace ChessWebApp.Migrations
{
    public partial class ChessContext3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spot");

            migrationBuilder.CreateTable(
                name: "ChessSpot",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Piece = table.Column<string>(nullable: true),
                    Occupied = table.Column<bool>(nullable: false),
                    CoordX = table.Column<int>(nullable: false),
                    CoordY = table.Column<int>(nullable: false),
                    ChessTableId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChessSpot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChessSpot_ChessTable_ChessTableId",
                        column: x => x.ChessTableId,
                        principalTable: "ChessTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChessSpot_ChessTableId",
                table: "ChessSpot",
                column: "ChessTableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChessSpot");

            migrationBuilder.CreateTable(
                name: "Spot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChessTableId = table.Column<int>(type: "int", nullable: true),
                    CoordX = table.Column<int>(type: "int", nullable: false),
                    CoordY = table.Column<int>(type: "int", nullable: false),
                    Occupied = table.Column<bool>(type: "bit", nullable: false),
                    Piece = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spot_ChessTable_ChessTableId",
                        column: x => x.ChessTableId,
                        principalTable: "ChessTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spot_ChessTableId",
                table: "Spot",
                column: "ChessTableId");
        }
    }
}
