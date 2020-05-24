using Microsoft.EntityFrameworkCore.Migrations;

namespace ODA.Migrations
{
    public partial class ModifiedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedOrders",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "RestaurantName",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RestaurantName",
                table: "Orders");

            migrationBuilder.AddColumn<double>(
                name: "CompletedOrders",
                table: "Customers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
