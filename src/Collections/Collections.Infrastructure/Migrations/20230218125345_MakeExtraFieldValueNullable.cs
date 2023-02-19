using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Collections.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeExtraFieldValueNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2327c143-7b18-404d-8710-01dad7a2290a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5e9cd90-5144-47a1-8254-64125df20d45");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0e2b89f-b6dc-4629-9d1e-671b4ed840ec");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "35267ab6-1f9f-4268-9fe5-3a60d6b3fcad", null, "Admin", "ADMIN" },
                    { "6084cbf7-0cbc-4a6e-bc5c-2d7005d3d3c4", null, "Author", "AUTHOR" },
                    { "c9018bf1-d7bf-4e75-adb2-f3ec650b5f7e", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35267ab6-1f9f-4268-9fe5-3a60d6b3fcad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6084cbf7-0cbc-4a6e-bc5c-2d7005d3d3c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9018bf1-d7bf-4e75-adb2-f3ec650b5f7e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2327c143-7b18-404d-8710-01dad7a2290a", null, "Author", "AUTHOR" },
                    { "a5e9cd90-5144-47a1-8254-64125df20d45", null, "User", "USER" },
                    { "d0e2b89f-b6dc-4629-9d1e-671b4ed840ec", null, "Admin", "ADMIN" }
                });
        }
    }
}
