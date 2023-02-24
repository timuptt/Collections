using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Collections.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddImageNameToCollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "UserCollections",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4203e807-e6e5-45b1-bfee-ba73aa565e76", null, "Admin", "ADMIN" },
                    { "74e75fbc-6453-43f3-b953-d5c5b3168bd0", null, "Author", "AUTHOR" },
                    { "800e6edd-a509-4b11-8969-3e15ecb0ad29", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4203e807-e6e5-45b1-bfee-ba73aa565e76");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74e75fbc-6453-43f3-b953-d5c5b3168bd0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "800e6edd-a509-4b11-8969-3e15ecb0ad29");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "UserCollections");

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
    }
}
