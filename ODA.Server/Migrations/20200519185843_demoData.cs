using Microsoft.EntityFrameworkCore.Migrations;

namespace ODA.Server.Migrations
{
    public partial class demoData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Add Customers
            migrationBuilder.Sql(@"
SET IDENTITY_INSERT [dbo].[Customers] ON
INSERT INTO [dbo].[Customers] ([Id], [FirstName], [LastName], [PrimaryMobile], [PrimaryEmail], [Address], [PlacedOrders], [CancelledOrders], [CompletedOrders], [TokenKey]) VALUES (1, N'George', N'Wainaina', N'0734666567', N'georgewainaina18@gmail.com', N'Nakuru', 0, 0, 0, N'dsicugshdfnm34lp58u3yghbrjn3!!W2rrd')
SET IDENTITY_INSERT [dbo].[Customers] OFF
");
            //Add Demo Categories
            migrationBuilder.Sql(@"
SET IDENTITY_INSERT [dbo].[ItemCategories] ON
INSERT INTO [dbo].[ItemCategories] ([Id], [Name], [ImageFile], [MinimumPrice], [WaitTimeInMin]) VALUES (1, N'Fast Food', N'fast-foods.jpg', 0, 10)
INSERT INTO [dbo].[ItemCategories] ([Id], [Name], [ImageFile], [MinimumPrice], [WaitTimeInMin]) VALUES (2, N'Chicken', N'chicken.jpg', 0, 0)
INSERT INTO [dbo].[ItemCategories] ([Id], [Name], [ImageFile], [MinimumPrice], [WaitTimeInMin]) VALUES (3, N'Pizza', N'pizza.jpg', 0, 10)
INSERT INTO [dbo].[ItemCategories] ([Id], [Name], [ImageFile], [MinimumPrice], [WaitTimeInMin]) VALUES (4, N'Burgers', N'burger.jpg', 5, 10)
INSERT INTO [dbo].[ItemCategories] ([Id], [Name], [ImageFile], [MinimumPrice], [WaitTimeInMin]) VALUES (5, N'Barberque', N'barberque.jpg', 5, 10)
INSERT INTO [dbo].[ItemCategories] ([Id], [Name], [ImageFile], [MinimumPrice], [WaitTimeInMin]) VALUES (6, N'Sandwiches', N'sandwiches.jpg', 2, 5)
INSERT INTO [dbo].[ItemCategories] ([Id], [Name], [ImageFile], [MinimumPrice], [WaitTimeInMin]) VALUES (7, N'Swahili Dishes', N'swahilidishes.jpg', 5, 4)
INSERT INTO [dbo].[ItemCategories] ([Id], [Name], [ImageFile], [MinimumPrice], [WaitTimeInMin]) VALUES (8, N'African Foods', N'african-foods.jpg', 7, 20)
INSERT INTO [dbo].[ItemCategories] ([Id], [Name], [ImageFile], [MinimumPrice], [WaitTimeInMin]) VALUES (9, N'Chinese Foods', N'chineese.jpg', 8, 20)
INSERT INTO [dbo].[ItemCategories] ([Id], [Name], [ImageFile], [MinimumPrice], [WaitTimeInMin]) VALUES (12, N'Chips', N'chips.jpg', 5, 5)
SET IDENTITY_INSERT [dbo].[ItemCategories] OFF

");
            //Demo Places
            migrationBuilder.Sql(@"
INSERT INTO [dbo].[MapPopularPlaces] ([Place], [PopularityRank]) VALUES (N'Eldoret', 5)
INSERT INTO [dbo].[MapPopularPlaces] ([Place], [PopularityRank]) VALUES (N'Kisumu', 4)
INSERT INTO [dbo].[MapPopularPlaces] ([Place], [PopularityRank]) VALUES (N'Nairobi', 8)
INSERT INTO [dbo].[MapPopularPlaces] ([Place], [PopularityRank]) VALUES (N'Naivasha', 7)
INSERT INTO [dbo].[MapPopularPlaces] ([Place], [PopularityRank]) VALUES (N'Nakuru', 10)

");
            //Demo Restaurants
            migrationBuilder.Sql(@"
SET IDENTITY_INSERT [dbo].[Restaurants] ON
INSERT INTO [dbo].[Restaurants] ([Id], [RegisteredName], [ContactMobile], [ContactEmail], [Location], [MoreInfo], [PriceEstimate], [ClosingHours], [OpeningHours], [Rating], [ImageFile]) VALUES (1, N'KFC', N'0734666660', N'N/A', N'Nakuru', NULL, NULL, 0, 0, 4.5, N'kfc.jpg')
INSERT INTO [dbo].[Restaurants] ([Id], [RegisteredName], [ContactMobile], [ContactEmail], [Location], [MoreInfo], [PriceEstimate], [ClosingHours], [OpeningHours], [Rating], [ImageFile]) VALUES (2, N'Java House', N'0700000054', N'Nakuru', N'Nakuru', NULL, NULL, 0, 0, 0, N'java-house.jpg')
INSERT INTO [dbo].[Restaurants] ([Id], [RegisteredName], [ContactMobile], [ContactEmail], [Location], [MoreInfo], [PriceEstimate], [ClosingHours], [OpeningHours], [Rating], [ImageFile]) VALUES (3, N'Ipiz Restaurant', N'0754000505', N'ipize@gmail.com', N'Nakuru', N'No Information', N'5', 0, 0, 4, N'ipiz-restaurant.jpg')
INSERT INTO [dbo].[Restaurants] ([Id], [RegisteredName], [ContactMobile], [ContactEmail], [Location], [MoreInfo], [PriceEstimate], [ClosingHours], [OpeningHours], [Rating], [ImageFile]) VALUES (4, N'Jimmy Choma Bite', N'0754846846', N'hom@gmail.com', N'Nakuru', N'No Information', N'1', 0, 0, 0, N'jimmy-choma-bite.jpg')
INSERT INTO [dbo].[Restaurants] ([Id], [RegisteredName], [ContactMobile], [ContactEmail], [Location], [MoreInfo], [PriceEstimate], [ClosingHours], [OpeningHours], [Rating], [ImageFile]) VALUES (5, N'Nakuru Snack Way', N'0445447854', N'snack@gmail.com', N'Nakuru', N'No Information', N'25', 0, 0, 0, N'nakuru-snack-way.jpg')
INSERT INTO [dbo].[Restaurants] ([Id], [RegisteredName], [ContactMobile], [ContactEmail], [Location], [MoreInfo], [PriceEstimate], [ClosingHours], [OpeningHours], [Rating], [ImageFile]) VALUES (6, N'The Loft Bistro', N'05454545584', N'loft@gmail.com', N'Nakuru', N'No Information', N'0', 0, 0, 4, N'the-loft-bistro.jpg')
INSERT INTO [dbo].[Restaurants] ([Id], [RegisteredName], [ContactMobile], [ContactEmail], [Location], [MoreInfo], [PriceEstimate], [ClosingHours], [OpeningHours], [Rating], [ImageFile]) VALUES (7, N'Good Fork Restaurant', N'0545448452', N'goodfork@gmail.com', N'Nakuru', N'No Information', N'1', 1, 1, 1, N'good-fork-restaurant.jpg')
INSERT INTO [dbo].[Restaurants] ([Id], [RegisteredName], [ContactMobile], [ContactEmail], [Location], [MoreInfo], [PriceEstimate], [ClosingHours], [OpeningHours], [Rating], [ImageFile]) VALUES (8, N'Nax Foodiez', N'0754518451', N'naxfoodies@gmail.com', N'Nakuru', N'No Information', NULL, 0, 0, 0, N'nax-foodiez.jpg')
INSERT INTO [dbo].[Restaurants] ([Id], [RegisteredName], [ContactMobile], [ContactEmail], [Location], [MoreInfo], [PriceEstimate], [ClosingHours], [OpeningHours], [Rating], [ImageFile]) VALUES (9, N'Chicken Baristo', N'0451848485', N'nax-foodiez@gmail.com', N'Nakuru', N'No Information', NULL, 0, 0, 0, N'chicken-baristro.jpg')
INSERT INTO [dbo].[Restaurants] ([Id], [RegisteredName], [ContactMobile], [ContactEmail], [Location], [MoreInfo], [PriceEstimate], [ClosingHours], [OpeningHours], [Rating], [ImageFile]) VALUES (10, N'Cafe Micasa Sucasa', N'0745484554', N'cafe-micasa-sucasa', N'Nakuru', N'No Information', NULL, 0, 0, 0, N'cafe-micasa-sucasa.jpg')
SET IDENTITY_INSERT [dbo].[Restaurants] OFF

");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
