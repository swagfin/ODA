using Microsoft.EntityFrameworkCore.Migrations;

namespace ODA.Migrations
{
    public partial class ModifiedCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "LoyaltyWalletBalance",
                table: "Customers",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoyaltyWalletBalance",
                table: "Customers");
        }
    }
}
