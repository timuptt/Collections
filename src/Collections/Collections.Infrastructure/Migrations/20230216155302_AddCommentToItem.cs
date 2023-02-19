using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Collections.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCommentToItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Comments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2327c143-7b18-404d-8710-01dad7a2290a", null, "Author", "AUTHOR" },
                    { "a5e9cd90-5144-47a1-8254-64125df20d45", null, "User", "USER" },
                    { "d0e2b89f-b6dc-4629-9d1e-671b4ed840ec", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ItemId",
                table: "Comments",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Items_ItemId",
                table: "Comments",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Items_ItemId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ItemId",
                table: "Comments");

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

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Comments");

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
    }
}
