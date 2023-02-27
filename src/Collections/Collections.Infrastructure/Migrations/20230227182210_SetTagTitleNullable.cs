using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Collections.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SetTagTitleNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fadd0b3-7b47-4198-a2f0-a09e91747804");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38408f2a-ca1f-48c4-abca-c65039d0d6c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b79976a-6c4a-4601-9d10-93f97cccb24a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46215f67-eb24-425d-b8de-1b2126ec6876", null, "User", "USER" },
                    { "738f5b5d-58ed-4e1e-9fbd-50b0a1361b6d", null, "Admin", "ADMIN" },
                    { "e760b3eb-1fc2-4a24-9c90-57bbd3670d92", null, "Author", "AUTHOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46215f67-eb24-425d-b8de-1b2126ec6876");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "738f5b5d-58ed-4e1e-9fbd-50b0a1361b6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e760b3eb-1fc2-4a24-9c90-57bbd3670d92");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2fadd0b3-7b47-4198-a2f0-a09e91747804", null, "User", "USER" },
                    { "38408f2a-ca1f-48c4-abca-c65039d0d6c3", null, "Author", "AUTHOR" },
                    { "6b79976a-6c4a-4601-9d10-93f97cccb24a", null, "Admin", "ADMIN" }
                });
        }
    }
}
