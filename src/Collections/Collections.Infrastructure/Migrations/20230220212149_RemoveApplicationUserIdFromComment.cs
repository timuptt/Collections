using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Collections.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveApplicationUserIdFromComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "ExtraFields",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5b8d55ba-7647-4c29-b592-72fbe606bf45", null, "Author", "AUTHOR" },
                    { "79c3f187-5974-48f9-9f83-b8e54481a7e5", null, "Admin", "ADMIN" },
                    { "7b1edaf1-bc3b-480a-9f33-07638528e371", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b8d55ba-7647-4c29-b592-72fbe606bf45");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79c3f187-5974-48f9-9f83-b8e54481a7e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b1edaf1-bc3b-480a-9f33-07638528e371");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "ExtraFields",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Comments",
                type: "text",
                nullable: false,
                defaultValue: "");

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
    }
}
