using Microsoft.EntityFrameworkCore.Migrations;

namespace ODA.DataAccess.Migrations
{
    public partial class ModifiedRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFile",
                table: "Restaurants",
                maxLength: 240,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFile",
                table: "Restaurants");
        }
    }
}
