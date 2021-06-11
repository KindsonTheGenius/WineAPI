using Microsoft.EntityFrameworkCore.Migrations;

namespace WineAPI.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Year = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    CountInCeller = table.Column<int>(nullable: false),
                    Style = table.Column<string>(nullable: true),
                    Taste = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FoodPairing = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
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

            migrationBuilder.InsertData(
                table: "WineMaker",
                columns: new[] { "WineMakerId", "Address", "Name" },
                values: new object[] { 1, "Budapest utca 45", "Kindson Munonye" });

            migrationBuilder.InsertData(
                table: "WineBottle",
                columns: new[] { "WineBottleId", "CountInCeller", "Description", "FoodPairing", "Image", "Link", "Size", "Style", "Taste", "WineMakerId", "Year" },
                values: new object[] { 1, 10, "A very nice wine", "A good meal", "Great", "my link", 34, "Strong", "Good", 1, "2021" });

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
                name: "WineMaker");
        }
    }
}
