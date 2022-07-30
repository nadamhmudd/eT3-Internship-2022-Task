using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShopSystem.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "39a3239d-609a-41a3-8905-ecffdaefc786", null, false, "Cahsier", false, null, null, null, null, null, false, "386b9691-031a-4197-8c39-89e85b97f836", false, null },
                    { "n1aea1a1-6b4a-44db-a057-061cf7aeb8nn", 0, "1c016a3c-f49a-4a99-afec-c18e9645566b", null, false, "Cahsier", false, null, null, null, null, null, false, "67c40a07-39a8-4bac-a272-2dc64afffb10", false, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ExtraLargeCupSize_Price", "LargeCupSize_Price", "MediumCupSize_Price", "Name", "SmallCupSize_Price" },
                values: new object[,]
                {
                    { 1, "2% Milk, Milk Foam, Steamed Hot", 80f, 65f, 50f, "Caffè Misto", 35f },
                    { 2, "2% Milk, Regular Foam, Steamed Hot", 99f, 80f, 65f, "Cappuccinos", 40f },
                    { 3, "2% Milk, Milk Foam, Steamed Hot ", 110f, 85f, 70f, "Cinnamon Dolce Latte", 55f },
                    { 4, "2 Shots Signature Espresso", 90f, 75f, 50f, "Espresso", 25f },
                    { 5, "Whole Milk, Steamed Hot", 85f, 60f, 50f, "Flat White", 35f },
                    { 6, "2% Milk, Milk Foam, Steamed Hot", 75f, 65f, 55f, "Caffè Latte", 45f }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CashierId", "OrderDate", "OrderStatus", "OrderTotal" },
                values: new object[] { 1, "n1aea1a1-6b4a-44db-a057-061cf7aeb8nn", new DateTime(2022, 7, 29, 20, 7, 31, 677, DateTimeKind.Utc).AddTicks(3180), "Processing", 145f });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CashierId", "OrderDate", "OrderStatus", "OrderTotal" },
                values: new object[] { 2, "n1aea1a1-6b4a-44db-a057-061cf7aeb8nn", new DateTime(2022, 7, 29, 20, 7, 31, 677, DateTimeKind.Utc).AddTicks(3611), "Processing", 140f });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "CupSize", "OrderId", "ProductId", "Price", "Quantity" },
                values: new object[,]
                {
                    { "Small", 1, 1, 35f, 2 },
                    { "Large", 1, 4, 75f, 1 },
                    { "Medium", 2, 2, 65f, 1 },
                    { "ExtraLarge", 2, 6, 75f, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumns: new[] { "CupSize", "OrderId", "ProductId" },
                keyValues: new object[] { "Small", 1, 1 });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumns: new[] { "CupSize", "OrderId", "ProductId" },
                keyValues: new object[] { "Large", 1, 4 });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumns: new[] { "CupSize", "OrderId", "ProductId" },
                keyValues: new object[] { "Medium", 2, 2 });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumns: new[] { "CupSize", "OrderId", "ProductId" },
                keyValues: new object[] { "ExtraLarge", 2, 6 });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "n1aea1a1-6b4a-44db-a057-061cf7aeb8nn");
        }
    }
}
