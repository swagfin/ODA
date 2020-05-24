﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ODA.Context;

namespace ODA.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200524121223_ModifiedCustomer")]
    partial class ModifiedCustomer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ODA.Entity.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CancelledOrders")
                        .HasColumnType("float");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(180)")
                        .HasMaxLength(180);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(220)")
                        .HasMaxLength(220);

                    b.Property<bool>("IsAccountConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("LoyaltyWalletBalance")
                        .HasColumnType("float");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(120)")
                        .HasMaxLength(120);

                    b.Property<double>("PlacedOrders")
                        .HasColumnType("float");

                    b.Property<string>("TokenKey")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("VerificationCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ODA.Entity.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(225)")
                        .HasMaxLength(225);

                    b.Property<DateTime>("DateRegistered")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFeaturd")
                        .HasColumnType("bit");

                    b.Property<string>("ItemBarcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("MoreInfo")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("OrderedQuantity")
                        .HasColumnType("int");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<double>("SellingPrice")
                        .HasColumnType("float");

                    b.Property<double>("WaitTimeInMin")
                        .HasColumnType("float");

                    b.HasKey("ItemId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("ODA.Entity.ItemCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MinimumPrice")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WaitTimeInMin")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ItemCategories");
                });

            modelBuilder.Entity("ODA.Entity.MapPopularPlace", b =>
                {
                    b.Property<string>("Place")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("PopularityRank")
                        .HasColumnType("float");

                    b.HasKey("Place");

                    b.ToTable("MapPopularPlaces");
                });

            modelBuilder.Entity("ODA.Entity.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookedTable")
                        .HasColumnType("nvarchar(240)")
                        .HasMaxLength(240);

                    b.Property<double>("ChangeAmount")
                        .HasColumnType("float");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerMobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("DeliveryCost")
                        .HasColumnType("float");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<double>("DueAmount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderRef")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("OrderStatus")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<double>("PaidAmount")
                        .HasColumnType("float");

                    b.Property<string>("PayMethod")
                        .HasColumnType("nvarchar(240)")
                        .HasMaxLength(240);

                    b.Property<string>("PaymentTransactionRef")
                        .HasColumnType("nvarchar(240)")
                        .HasMaxLength(240);

                    b.Property<DateTime>("RegisteredDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<string>("RestaurantName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("SubTotal")
                        .HasColumnType("float");

                    b.Property<double>("Tax")
                        .HasColumnType("float");

                    b.Property<double>("TaxRate")
                        .HasColumnType("float");

                    b.Property<string>("TokenKey")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("TotalItems")
                        .HasColumnType("int");

                    b.Property<string>("TransactionType")
                        .HasColumnType("nvarchar(90)")
                        .HasMaxLength(90);

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ODA.Entity.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<string>("ItemBarcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemNote")
                        .HasColumnType("nvarchar(210)")
                        .HasMaxLength(210);

                    b.Property<string>("ItemStatus")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderRestaurantId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<DateTime>("RegisteredDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Tax")
                        .HasColumnType("float");

                    b.Property<string>("TaxCode")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("TokenKey")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<double>("TotalCost")
                        .HasColumnType("float");

                    b.Property<double>("WaitTimeInMin")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("ODA.Entity.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClosingHours")
                        .HasColumnType("int");

                    b.Property<string>("ContactEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(95)")
                        .HasMaxLength(95);

                    b.Property<string>("ContactMobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("ImageFile")
                        .HasColumnType("nvarchar(240)")
                        .HasMaxLength(240);

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(180)")
                        .HasMaxLength(180);

                    b.Property<string>("MoreInfo")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("OpeningHours")
                        .HasColumnType("int");

                    b.Property<string>("PriceEstimate")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<string>("RegisteredName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("ODA.Entity.Item", b =>
                {
                    b.HasOne("ODA.Entity.Restaurant", "Restaurant")
                        .WithMany("Items")
                        .HasForeignKey("RestaurantId");
                });

            modelBuilder.Entity("ODA.Entity.Order", b =>
                {
                    b.HasOne("ODA.Entity.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("ODA.Entity.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId");
                });

            modelBuilder.Entity("ODA.Entity.OrderItem", b =>
                {
                    b.HasOne("ODA.Entity.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.HasOne("ODA.Entity.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId");
                });
#pragma warning restore 612, 618
        }
    }
}
