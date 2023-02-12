using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Collections.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAppUserIdFromUserCollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "037718ed-91d1-4874-b9b1-288b398373bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0923bbba-ccf6-4153-b139-5e88b78fdff4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b54d9c1-e723-4bb7-adb0-789a1f621a94");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserCollections");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "231c3e6e-e2a7-49b8-8fea-74efd32b3b53", null, "Admin", "ADMIN" },
                    { "3a579889-fd23-4914-8498-527e8f5d1746", null, "User", "USER" },
                    { "e2b13a8f-a032-4e1f-98ed-71f8c32ecbcf", null, "Author", "AUTHOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "231c3e6e-e2a7-49b8-8fea-74efd32b3b53");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a579889-fd23-4914-8498-527e8f5d1746");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2b13a8f-a032-4e1f-98ed-71f8c32ecbcf");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "UserCollections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "037718ed-91d1-4874-b9b1-288b398373bc", null, "Admin", "ADMIN" },
                    { "0923bbba-ccf6-4153-b139-5e88b78fdff4", null, "Author", "AUTHOR" },
                    { "3b54d9c1-e723-4bb7-adb0-789a1f621a94", null, "User", "USER" }
                });
        }
    }
}
