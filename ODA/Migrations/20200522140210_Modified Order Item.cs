using Microsoft.EntityFrameworkCore.Migrations;

namespace ODA.Migrations
{
    public partial class ModifiedOrderItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderRestaurantId",
                table: "OrderItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderRestaurantId",
                table: "OrderItems");
        }
    }
}
