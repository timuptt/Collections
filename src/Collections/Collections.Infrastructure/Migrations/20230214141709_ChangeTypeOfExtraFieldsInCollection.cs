using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Collections.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTypeOfExtraFieldsInCollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80de99e0-03c4-496d-81fa-3b7ef5039be0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4d75b20-8b87-47fb-a511-2e5e937e979b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee3edda6-2400-49bc-820d-680c1f3ad389");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "37c04691-4343-4717-821b-64a68c5cb6ac", null, "Author", "AUTHOR" },
                    { "4320cedf-aa90-4773-bc75-704d80871987", null, "Admin", "ADMIN" },
                    { "540e95d2-3f78-45ea-a47e-c75a6cc95461", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37c04691-4343-4717-821b-64a68c5cb6ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4320cedf-aa90-4773-bc75-704d80871987");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "540e95d2-3f78-45ea-a47e-c75a6cc95461");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "80de99e0-03c4-496d-81fa-3b7ef5039be0", null, "Admin", "ADMIN" },
                    { "e4d75b20-8b87-47fb-a511-2e5e937e979b", null, "User", "USER" },
                    { "ee3edda6-2400-49bc-820d-680c1f3ad389", null, "Author", "AUTHOR" }
                });
        }
    }
}
