using Microsoft.EntityFrameworkCore.Migrations;

namespace ODA.Migrations
{
    public partial class AddedMerchantIdToRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MoreInfo",
                table: "Restaurants",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MerchantId",
                table: "Restaurants",
                maxLength: 180,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "Restaurants");

            migrationBuilder.AlterColumn<string>(
                name: "MoreInfo",
                table: "Restaurants",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
