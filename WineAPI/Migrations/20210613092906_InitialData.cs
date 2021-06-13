using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WineAPI.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WineImage",
                columns: table => new
                {
                    WineImageId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WineImageTitle = table.Column<string>(nullable: true),
                    WineImageData = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineImage", x => x.WineImageId);
                });

            migrationBuilder.CreateTable(
                name: "WineMaker",
                columns: table => new
                {
                    WineMakerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineMaker", x => x.WineMakerId);
                });

            migrationBuilder.CreateTable(
                name: "WineBottle",
                columns: table => new
                {
                    WineBottleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Year = table.Column<int>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    CountInCeller = table.Column<int>(nullable: false),
                    Style = table.Column<int>(nullable: false),
                    Taste = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FoodPairing = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    WineImageId = table.Column<int>(nullable: false),
                    WineMakerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineBottle", x => x.WineBottleId);
                    table.ForeignKey(
                        name: "FK_WineBottle_WineMaker_WineMakerId",
                        column: x => x.WineMakerId,
                        principalTable: "WineMaker",
                        principalColumn: "WineMakerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WineBottle_WineMakerId",
                table: "WineBottle",
                column: "WineMakerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WineBottle");

            migrationBuilder.DropTable(
                name: "WineImage");

            migrationBuilder.DropTable(
                name: "WineMaker");
        }
    }
}
