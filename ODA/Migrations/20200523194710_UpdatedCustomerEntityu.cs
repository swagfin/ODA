using Microsoft.EntityFrameworkCore.Migrations;

namespace ODA.Migrations
{
    public partial class UpdatedCustomerEntityu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrimaryEmail",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PrimaryMobile",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Customers",
                maxLength: 220,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Customers",
                maxLength: 180,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                maxLength: 120,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 220);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryEmail",
                table: "Customers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryMobile",
                table: "Customers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
