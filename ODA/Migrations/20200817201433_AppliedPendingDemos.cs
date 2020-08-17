using Microsoft.EntityFrameworkCore.Migrations;

namespace ODA.Migrations
{
    public partial class AppliedPendingDemos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Add Demo Categories
            migrationBuilder.Sql(@"
            SET IDENTITY_INSERT [oda].[ItemCategories] ON
            INSERT INTO [oda].[ItemCategories] ([Id], [Name], [ImageFile], [MinimumPrice], [WaitTimeInMin]) VALUES (1, N'Fast Food', N'fast-foods.jpg', 0, 10)
            INSERT INTO [oda].[ItemCategories] ([Id], [Name], [ImageFile], [MinimumPrice], [WaitTimeInMin]) VALUES (2, N'Chicken', N'chicken.jpg', 0, 0)
            INSERT INTO [oda].[ItemCategories] ([Id], [Name], [ImageFile], [MinimumPrice], [WaitTimeInMin]) VALUES (3, N'Pizza', N'pizza.jpg', 0, 10)
            INSERT INTO [oda].[ItemCategories] ([Id], [Name], [ImageFile], [MinimumPrice], [WaitTimeInMin]) VALUES (4, N'Burgers', N'burger.jpg', 5, 10)
            INSERT INTO [oda].[ItemCategories] ([Id], [Name], [ImageFile], [MinimumPrice], [WaitTimeInMin]) VALUES (5, N'Barberque', N'barberque.jpg', 5, 10)
            INSERT INTO [oda].[ItemCategories] ([Id], [Name], [ImageFile], [MinimumPrice], [WaitTimeInMin]) VALUES (6, N'Sandwiches', N'sandwiches.jpg', 2, 5)
            INSERT INTO [oda].[ItemCategories] ([Id], [Name], [ImageFile], [MinimumPrice], [WaitTimeInMin]) VALUES (7, N'Swahili Dishes', N'swahilidishes.jpg', 5, 4)
            INSERT INTO [oda].[ItemCategories] ([Id], [Name], [ImageFile], [MinimumPrice], [WaitTimeInMin]) VALUES (8, N'African Foods', N'african-foods.jpg', 7, 20)
            INSERT INTO [oda].[ItemCategories] ([Id], [Name], [ImageFile], [MinimumPrice], [WaitTimeInMin]) VALUES (9, N'Chinese Foods', N'chineese.jpg', 8, 20)
            INSERT INTO [oda].[ItemCategories] ([Id], [Name], [ImageFile], [MinimumPrice], [WaitTimeInMin]) VALUES (12, N'Chips', N'chips.jpg', 5, 5)
            SET IDENTITY_INSERT [oda].[ItemCategories] OFF

            ");
            // Demo Places
            migrationBuilder.Sql(@"
            INSERT INTO [oda].[MapPopularPlaces] ([Place], [PopularityRank]) VALUES (N'Eldoret', 5)
            INSERT INTO [oda].[MapPopularPlaces] ([Place], [PopularityRank]) VALUES (N'Kisumu', 4)
            INSERT INTO [oda].[MapPopularPlaces] ([Place], [PopularityRank]) VALUES (N'Nairobi', 8)
            INSERT INTO [oda].[MapPopularPlaces] ([Place], [PopularityRank]) VALUES (N'Naivasha', 7)
            INSERT INTO [oda].[MapPopularPlaces] ([Place], [PopularityRank]) VALUES (N'Nakuru', 10)

            ");
            // Demo Restaurants
            migrationBuilder.Sql(@"
            SET IDENTITY_INSERT [oda].[Restaurants] ON
            INSERT INTO [oda].[Restaurants] ([Id], [RegisteredName], [ContactMobile], [ContactEmail], [Location], [MoreInfo], [PriceEstimate], [ClosingHours], [OpeningHours], [Rating], [ImageFile]) VALUES (1, N'KFC', N'0734666660', N'N/A', N'Nakuru', NULL, NULL, 0, 0, 4.5, N'kfc.jpg')
            INSERT INTO [oda].[Restaurants] ([Id], [RegisteredName], [ContactMobile], [ContactEmail], [Location], [MoreInfo], [PriceEstimate], [ClosingHours], [OpeningHours], [Rating], [ImageFile]) VALUES (2, N'Java House', N'0700000054', N'Nakuru', N'Nakuru', NULL, NULL, 0, 0, 0, N'java-house.jpg')
            INSERT INTO [oda].[Restaurants] ([Id], [RegisteredName], [ContactMobile], [ContactEmail], [Location], [MoreInfo], [PriceEstimate], [ClosingHours], [OpeningHours], [Rating], [ImageFile]) VALUES (3, N'Ipiz Restaurant', N'0754000505', N'ipize@gmail.com', N'Nakuru', N'No Information', N'5', 0, 0, 4, N'ipiz-restaurant.jpg')
            INSERT INTO [oda].[Restaurants] ([Id], [RegisteredName], [ContactMobile], [ContactEmail], [Location], [MoreInfo], [PriceEstimate], [ClosingHours], [OpeningHours], [Rating], [ImageFile]) VALUES (4, N'Jimmy Choma Bite', N'0754846846', N'hom@gmail.com', N'Nakuru', N'No Information', N'1', 0, 0, 0, N'jimmy-choma-bite.jpg')
            INSERT INTO [oda].[Restaurants] ([Id], [RegisteredName], [ContactMobile], [ContactEmail], [Location], [MoreInfo], [PriceEstimate], [ClosingHours], [OpeningHours], [Rating], [ImageFile]) VALUES (5, N'Nakuru Snack Way', N'0445447854', N'snack@gmail.com', N'Nakuru', N'No Information', N'25', 0, 0, 0, N'nakuru-snack-way.jpg')
            INSERT INTO [oda].[Restaurants] ([Id], [RegisteredName], [ContactMobile], [ContactEmail], [Location], [MoreInfo], [PriceEstimate], [ClosingHours], [OpeningHours], [Rating], [ImageFile]) VALUES (6, N'The Loft Bistro', N'05454545584', N'loft@gmail.com', N'Nakuru', N'No Information', N'0', 0, 0, 4, N'the-loft-bistro.jpg')
            INSERT INTO [oda].[Restaurants] ([Id], [RegisteredName], [ContactMobile], [ContactEmail], [Location], [MoreInfo], [PriceEstimate], [ClosingHours], [OpeningHours], [Rating], [ImageFile]) VALUES (7, N'Good Fork Restaurant', N'0545448452', N'goodfork@gmail.com', N'Nakuru', N'No Information', N'1', 1, 1, 1, N'good-fork-restaurant.jpg')
            INSERT INTO [oda].[Restaurants] ([Id], [RegisteredName], [ContactMobile], [ContactEmail], [Location], [MoreInfo], [PriceEstimate], [ClosingHours], [OpeningHours], [Rating], [ImageFile]) VALUES (8, N'Nax Foodiez', N'0754518451', N'naxfoodies@gmail.com', N'Nakuru', N'No Information', NULL, 0, 0, 0, N'nax-foodiez.jpg')
            INSERT INTO [oda].[Restaurants] ([Id], [RegisteredName], [ContactMobile], [ContactEmail], [Location], [MoreInfo], [PriceEstimate], [ClosingHours], [OpeningHours], [Rating], [ImageFile]) VALUES (9, N'Chicken Baristo', N'0451848485', N'nax-foodiez@gmail.com', N'Nakuru', N'No Information', NULL, 0, 0, 0, N'chicken-baristro.jpg')
            INSERT INTO [oda].[Restaurants] ([Id], [RegisteredName], [ContactMobile], [ContactEmail], [Location], [MoreInfo], [PriceEstimate], [ClosingHours], [OpeningHours], [Rating], [ImageFile]) VALUES (10, N'Cafe Micasa Sucasa', N'0745484554', N'cafe-micasa-sucasa', N'Nakuru', N'No Information', NULL, 0, 0, 0, N'cafe-micasa-sucasa.jpg')
            SET IDENTITY_INSERT [oda].[Restaurants] OFF

            ");

            //  Import Demo Items
            migrationBuilder.Sql(@"
            SET IDENTITY_INSERT [oda].[Items] ON
            INSERT INTO [oda].[Items] ([ItemId], [ItemBarcode], [ItemName], [Category], [MoreInfo], [WaitTimeInMin], [OrderedQuantity], [SellingPrice], [ImageFile], [IsActive], [RestaurantId],[IsFeaturd],[DateRegistered]) VALUES (2, N'2154415', N'Bhajiyas', N'Fast Food', NULL, 10, 0, 150, N'bhajiyas.jpg', 1, 1,1,'2020-05-20 21:48:21.0')
            INSERT INTO [oda].[Items] ([ItemId], [ItemBarcode], [ItemName], [Category], [MoreInfo], [WaitTimeInMin], [OrderedQuantity], [SellingPrice], [ImageFile], [IsActive], [RestaurantId],[IsFeaturd],[DateRegistered]) VALUES (3, N'5165415', N'Chappati', N'Fast Food', NULL, 10, 0, 50, N'chapati.jpg', 1, 3,1,'2020-05-20 21:48:21.0')
            INSERT INTO [oda].[Items] ([ItemId], [ItemBarcode], [ItemName], [Category], [MoreInfo], [WaitTimeInMin], [OrderedQuantity], [SellingPrice], [ImageFile], [IsActive], [RestaurantId],[IsFeaturd],[DateRegistered]) VALUES (4, N'5154665', N'Chicken', N'Chicken', NULL, 15, 0, 250, N'chicken.jpg', 1, 1,1,'2020-05-20 21:48:21.0')
            INSERT INTO [oda].[Items] ([ItemId], [ItemBarcode], [ItemName], [Category], [MoreInfo], [WaitTimeInMin], [OrderedQuantity], [SellingPrice], [ImageFile], [IsActive], [RestaurantId],[IsFeaturd],[DateRegistered]) VALUES (5, N'5454234', N'Chips', N'Chips', NULL, 5, 0, 150, N'chips.jpg', 1, 4,1,'2020-05-20 21:48:21.0')
            INSERT INTO [oda].[Items] ([ItemId], [ItemBarcode], [ItemName], [Category], [MoreInfo], [WaitTimeInMin], [OrderedQuantity], [SellingPrice], [ImageFile], [IsActive], [RestaurantId],[IsFeaturd],[DateRegistered]) VALUES (6, N'4415465', N'Choma Bite', N'Barberque', NULL, 45, 0, 450, N'choma-bite.jpg', 1, 5,1,'2020-05-20 21:48:21.0')
            INSERT INTO [oda].[Items] ([ItemId], [ItemBarcode], [ItemName], [Category], [MoreInfo], [WaitTimeInMin], [OrderedQuantity], [SellingPrice], [ImageFile], [IsActive], [RestaurantId],[IsFeaturd],[DateRegistered]) VALUES (7, N'2154155', N'Fish', N'African Foods', NULL, 45, 0, 340, N'fish.jpg', 1, 6,1,'2020-05-20 21:48:21.0')
            INSERT INTO [oda].[Items] ([ItemId], [ItemBarcode], [ItemName], [Category], [MoreInfo], [WaitTimeInMin], [OrderedQuantity], [SellingPrice], [ImageFile], [IsActive], [RestaurantId],[IsFeaturd],[DateRegistered]) VALUES (8, N'4471547', N'Githeri', N'African Foods', NULL, 30, 0, 120, N'githeri.jpg', 1, 4,1,'2020-05-20 21:48:21.0')
            INSERT INTO [oda].[Items] ([ItemId], [ItemBarcode], [ItemName], [Category], [MoreInfo], [WaitTimeInMin], [OrderedQuantity], [SellingPrice], [ImageFile], [IsActive], [RestaurantId],[IsFeaturd],[DateRegistered]) VALUES (10, N'1545452', N'Grilled Chicken', N'Barberque', NULL, 20, 0, 270, N'grilled-chicken.jpg', 1, 6,1,'2020-05-20 21:48:21.0')
            INSERT INTO [oda].[Items] ([ItemId], [ItemBarcode], [ItemName], [Category], [MoreInfo], [WaitTimeInMin], [OrderedQuantity], [SellingPrice], [ImageFile], [IsActive], [RestaurantId],[IsFeaturd],[DateRegistered]) VALUES (11, N'1005052', N'Mandazi', N'Fast Food', NULL, 2, 0, 30, N'mandazi.jpg', 1, 4,1,'2020-05-20 21:48:21.0')
            INSERT INTO [oda].[Items] ([ItemId], [ItemBarcode], [ItemName], [Category], [MoreInfo], [WaitTimeInMin], [OrderedQuantity], [SellingPrice], [ImageFile], [IsActive], [RestaurantId],[IsFeaturd],[DateRegistered]) VALUES (12, N'2000513', N'Mishkaki', N'Barberque', NULL, 5, 0, 70, N'mishkaki.jpg', 1, 3,1,'2020-05-20 21:48:21.0')
            INSERT INTO [oda].[Items] ([ItemId], [ItemBarcode], [ItemName], [Category], [MoreInfo], [WaitTimeInMin], [OrderedQuantity], [SellingPrice], [ImageFile], [IsActive], [RestaurantId],[IsFeaturd],[DateRegistered]) VALUES (13, N'5540795', N'Mukimo', N'African Foods', NULL, 15, 0, 120, N'mukimo.jpg', 1, 5,1,'2020-05-20 21:48:21.0')
            INSERT INTO [oda].[Items] ([ItemId], [ItemBarcode], [ItemName], [Category], [MoreInfo], [WaitTimeInMin], [OrderedQuantity], [SellingPrice], [ImageFile], [IsActive], [RestaurantId],[IsFeaturd],[DateRegistered]) VALUES (14, N'8859908', N'Pilau', N'Swahili Dishes', NULL, 15, 0, 220, N'pilau.jpg', 1, 6,1,'2020-05-20 21:48:21.0')
            INSERT INTO [oda].[Items] ([ItemId], [ItemBarcode], [ItemName], [Category], [MoreInfo], [WaitTimeInMin], [OrderedQuantity], [SellingPrice], [ImageFile], [IsActive], [RestaurantId],[IsFeaturd],[DateRegistered]) VALUES (15, N'4635546', N'Salad', N'Fast Food', NULL, 10, 0, 150, N'salad.jpg', 1, 2,1,'2020-05-20 21:48:21.0')
            INSERT INTO [oda].[Items] ([ItemId], [ItemBarcode], [ItemName], [Category], [MoreInfo], [WaitTimeInMin], [OrderedQuantity], [SellingPrice], [ImageFile], [IsActive], [RestaurantId],[IsFeaturd],[DateRegistered]) VALUES (16, N'3248902', N'Samosa', N'Fast Food', NULL, 5, 0, 60, N'samosas.jpg', 1, 7,1,'2020-05-20 21:48:21.0')
            INSERT INTO [oda].[Items] ([ItemId], [ItemBarcode], [ItemName], [Category], [MoreInfo], [WaitTimeInMin], [OrderedQuantity], [SellingPrice], [ImageFile], [IsActive], [RestaurantId],[IsFeaturd],[DateRegistered]) VALUES (17, N'4548481', N'Tea Masala', N'Fast Food', NULL, 4, 0, 80, N'tea-masala.jpg', 1, 2,1,'2020-05-20 21:48:21.0')
            INSERT INTO [oda].[Items] ([ItemId], [ItemBarcode], [ItemName], [Category], [MoreInfo], [WaitTimeInMin], [OrderedQuantity], [SellingPrice], [ImageFile], [IsActive], [RestaurantId],[IsFeaturd],[DateRegistered]) VALUES (18, N'5545454', N'Ugali Beaf', N'Fast Food', NULL, 10, 0, 180, N'ugali-beaf.jpg', 1, 4,1,'2020-05-20 21:48:21.0')
            INSERT INTO [oda].[Items] ([ItemId], [ItemBarcode], [ItemName], [Category], [MoreInfo], [WaitTimeInMin], [OrderedQuantity], [SellingPrice], [ImageFile], [IsActive], [RestaurantId],[IsFeaturd],[DateRegistered]) VALUES (20, N'1002545', N'Wali wa Nazi', N'Swahili Dishes', NULL, 0, 0, 100, N'wali-wa-nazi.jpg', 1, 2,1,'2020-05-20 21:48:21.0')
            SET IDENTITY_INSERT [oda].[Items] OFF

            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
