using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Collections.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesToAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08c6dfa7-3cfc-4d91-ba64-2219fec0a88c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ff5f03d-5e96-4976-a70b-fd9a2a386a5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65dd2847-9316-4bfa-be81-b49253c1321a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8daf68b9-296c-453a-bd66-f52a8a48695c", null, "Author", "AUTHOR" },
                    { "b9710b0c-ad0c-426a-9caf-43ca83cb4bee", null, "Admin", "ADMIN" },
                    { "e0745088-4b18-427c-841f-e160d0ea3b46", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8daf68b9-296c-453a-bd66-f52a8a48695c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9710b0c-ad0c-426a-9caf-43ca83cb4bee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0745088-4b18-427c-841f-e160d0ea3b46");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08c6dfa7-3cfc-4d91-ba64-2219fec0a88c", null, "User", "USER" },
                    { "1ff5f03d-5e96-4976-a70b-fd9a2a386a5c", null, "Admin", "ADMIN" },
                    { "65dd2847-9316-4bfa-be81-b49253c1321a", null, "Author", "AUTHOR" }
                });
        }
    }
}
