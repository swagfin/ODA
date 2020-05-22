using Microsoft.EntityFrameworkCore.Migrations;

namespace ODA.Migrations
{
    public partial class AddedWaitingTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "WaitTimeInMin",
                table: "OrderItems",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WaitTimeInMin",
                table: "OrderItems");
        }
    }
}
