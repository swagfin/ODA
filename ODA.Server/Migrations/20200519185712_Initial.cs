using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ODA.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 120, nullable: false),
                    LastName = table.Column<string>(maxLength: 120, nullable: true),
                    PrimaryMobile = table.Column<string>(maxLength: 100, nullable: true),
                    PrimaryEmail = table.Column<string>(maxLength: 100, nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PlacedOrders = table.Column<double>(nullable: false),
                    CancelledOrders = table.Column<double>(nullable: false),
                    CompletedOrders = table.Column<double>(nullable: false),
                    TokenKey = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ImageFile = table.Column<string>(nullable: true),
                    MinimumPrice = table.Column<double>(nullable: false),
                    WaitTimeInMin = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategories", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisteredName = table.Column<string>(maxLength: 255, nullable: false),
                    ContactMobile = table.Column<string>(maxLength: 80, nullable: false),
                    ContactEmail = table.Column<string>(maxLength: 95, nullable: false),
                    Location = table.Column<string>(maxLength: 180, nullable: true),
                    ImageFile = table.Column<string>(maxLength: 240, nullable: true),
                    MoreInfo = table.Column<string>(maxLength: 50, nullable: true),
                    PriceEstimate = table.Column<string>(maxLength: 80, nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    OpeningHours = table.Column<int>(nullable: false),
                    ClosingHours = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemBarcode = table.Column<string>(maxLength: 150, nullable: false),
                    ItemName = table.Column<string>(maxLength: 255, nullable: false),
                    Category = table.Column<string>(maxLength: 225, nullable: true),
                    MoreInfo = table.Column<string>(maxLength: 255, nullable: true),
                    WaitTimeInMin = table.Column<double>(nullable: false),
                    OrderedQuantity = table.Column<int>(nullable: false),
                    SellingPrice = table.Column<double>(nullable: false),
                    ImageFile = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    RestaurantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderRef = table.Column<string>(maxLength: 250, nullable: true),
                    TransactionType = table.Column<string>(maxLength: 90, nullable: true),
                    RestaurantId = table.Column<int>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true),
                    CustomerMobile = table.Column<string>(nullable: true),
                    TotalItems = table.Column<int>(nullable: false),
                    SubTotal = table.Column<double>(nullable: false),
                    Tax = table.Column<double>(nullable: false),
                    TaxRate = table.Column<double>(nullable: false),
                    DeliveryCost = table.Column<double>(nullable: false),
                    Discount = table.Column<double>(nullable: false),
                    DueAmount = table.Column<double>(nullable: false),
                    PaidAmount = table.Column<double>(nullable: false),
                    ChangeAmount = table.Column<double>(nullable: false),
                    PayMethod = table.Column<string>(maxLength: 240, nullable: true),
                    PaymentTransactionRef = table.Column<string>(maxLength: 240, nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    BookedTable = table.Column<string>(maxLength: 240, nullable: true),
                    OrderStatus = table.Column<string>(maxLength: 50, nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    TokenKey = table.Column<string>(maxLength: 255, nullable: true),
                    RegisteredDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: true),
                    ItemId = table.Column<int>(nullable: true),
                    ItemName = table.Column<string>(nullable: true),
                    ItemBarcode = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Rate = table.Column<double>(nullable: false),
                    TaxCode = table.Column<string>(maxLength: 10, nullable: true),
                    Tax = table.Column<double>(nullable: false),
                    Discount = table.Column<double>(nullable: false),
                    TotalCost = table.Column<double>(nullable: false),
                    ItemStatus = table.Column<string>(maxLength: 50, nullable: true),
                    ItemNote = table.Column<string>(maxLength: 210, nullable: true),
                    TokenKey = table.Column<string>(maxLength: 250, nullable: true),
                    RegisteredDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_RestaurantId",
                table: "Items",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ItemId",
                table: "OrderItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RestaurantId",
                table: "Orders",
                column: "RestaurantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemCategories");

            migrationBuilder.DropTable(
                name: "MapPopularPlaces");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
