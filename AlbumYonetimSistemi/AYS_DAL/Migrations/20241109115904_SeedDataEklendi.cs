using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AYS_DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Created", "Deleted", "IsActive", "Modified", "Name", "Password" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 10, 11, 43, 33, 234, DateTimeKind.Local).AddTicks(5286), null, true, null, "mustafa", "DE659F7F95F5C6B909D823DC130BFE95E85B3E4E1F1019299E1D6DEBA318D113" },
                    { 2, new DateTime(2024, 10, 10, 11, 43, 33, 234, DateTimeKind.Local).AddTicks(5286), null, true, null, "yonca", "DE659F7F95F5C6B909D823DC130BFE95E85B3E4E1F1019299E1D6DEBA318D113" },
                    { 3, new DateTime(2024, 10, 10, 11, 43, 33, 234, DateTimeKind.Local).AddTicks(5286), null, true, null, "göksel", "DE659F7F95F5C6B909D823DC130BFE95E85B3E4E1F1019299E1D6DEBA318D113" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "Artist", "Created", "Deleted", "Discount", "IsActive", "Modified", "Name", "Price", "ReleaseDate", "Status" },
                values: new object[,]
                {
                    { 1, "Serdar Ortaç", new DateTime(2024, 10, 10, 11, 43, 33, 234, DateTimeKind.Local).AddTicks(5286), null, 0m, false, null, "Mesafe", 55m, new DateOnly(2006, 1, 5), true },
                    { 2, "Teoman", new DateTime(2024, 10, 10, 11, 43, 33, 234, DateTimeKind.Local).AddTicks(5286), null, 0m, false, null, "Onyedi", 955m, new DateOnly(2000, 4, 28), true },
                    { 3, "Eurythmics", new DateTime(2024, 10, 10, 11, 43, 33, 234, DateTimeKind.Local).AddTicks(5286), null, 0m, false, null, "Touch", 455m, new DateOnly(1983, 1, 1), true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
