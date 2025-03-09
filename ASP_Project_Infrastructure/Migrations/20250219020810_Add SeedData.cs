using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASP_Project_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Classifications",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "سوبرماركت" },
                    { 2, "مطعم" },
                    { 3, "منزل" }
                });

            migrationBuilder.InsertData(
                table: "Goverments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "القاهرة" },
                    { 2, "الإسكندرية" }
                });

            migrationBuilder.InsertData(
                table: "MainGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "الأغذية" },
                    { 2, "الإلكترونيات" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "علبة" },
                    { 2, "قطعة" },
                    { 3, "كيلو" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Gov_Id", "Name" },
                values: new object[,]
                {
                    { 1, 1, "مدينة نصر" },
                    { 2, 1, "المعادي" },
                    { 3, 2, "سموحة" }
                });

            migrationBuilder.InsertData(
                table: "SubGroups",
                columns: new[] { "Id", "MG_Id", "Name" },
                values: new object[,]
                {
                    { 1, 1, "الحليب والمنتجات" },
                    { 2, 2, "الهواتف" }
                });

            migrationBuilder.InsertData(
                table: "Zones",
                columns: new[] { "Id", "City_Id", "Gov_Id", "Name" },
                values: new object[,]
                {
                    { 1, 1, 1, "الحي الأول" },
                    { 2, 2, 1, "الحي الثاني" },
                    { 3, 3, 2, "حي المعمورة" }
                });

            migrationBuilder.InsertData(
                table: "subGroups2",
                columns: new[] { "Id", "MG_Id", "Name", "Sub_Id" },
                values: new object[,]
                {
                    { 1, 1, "حليب كامل الدسم", 1 },
                    { 2, 2, "هواتف ذكية", 2 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "MG_Id", "Name", "Price", "Sub2_Id", "Sub_Id" },
                values: new object[,]
                {
                    { 1, "حليب عالي الجودة", 1, "حليب كامل الدسم", 20.0, 1, 1 },
                    { 2, "هاتف ذكي عالي الجودة", 2, "آيفون 13", 15000.0, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "City_Id", "Gov_Id", "Name", "Zone_Id" },
                values: new object[,]
                {
                    { 1, 1, 1, "سوبرماركت الزمالك", 1 },
                    { 2, 3, 2, "متجر الإسكندرية", 3 }
                });

            migrationBuilder.InsertData(
                table: "ItemsUnits",
                columns: new[] { "Item_Id", "Unit_Id", "Factor" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "invItemStores",
                columns: new[] { "Item_Id", "Store_Id", "Balance", "Factor", "LastUpdated", "ReservedQuantity" },
                values: new object[,]
                {
                    { 1, 1, 100.0, 1, new DateTime(2025, 2, 18, 18, 8, 10, 184, DateTimeKind.Local).AddTicks(5590), 0.0 },
                    { 2, 2, 50.0, 1, new DateTime(2025, 2, 18, 18, 8, 10, 184, DateTimeKind.Local).AddTicks(5647), 0.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ItemsUnits",
                keyColumns: new[] { "Item_Id", "Unit_Id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ItemsUnits",
                keyColumns: new[] { "Item_Id", "Unit_Id" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Zones",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "invItemStores",
                keyColumns: new[] { "Item_Id", "Store_Id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "invItemStores",
                keyColumns: new[] { "Item_Id", "Store_Id" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Zones",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Zones",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "subGroups2",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "subGroups2",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SubGroups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubGroups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Goverments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Goverments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MainGroups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MainGroups",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
