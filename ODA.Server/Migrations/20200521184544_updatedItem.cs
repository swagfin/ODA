using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ODA.Server.Migrations
{
    public partial class updatedItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateRegistered",
                table: "Items",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsFeaturd",
                table: "Items",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateRegistered",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IsFeaturd",
                table: "Items");
        }
    }
}
