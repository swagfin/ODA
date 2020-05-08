using Microsoft.EntityFrameworkCore.Migrations;

namespace ODA.DataAccess.Migrations
{
    public partial class AddedPlaces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MapPopularPlaces",
                columns: table => new
                {
                    Place = table.Column<string>(nullable: false),
                    PopularityRank = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapPopularPlaces", x => x.Place);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MapPopularPlaces");
        }
    }
}
