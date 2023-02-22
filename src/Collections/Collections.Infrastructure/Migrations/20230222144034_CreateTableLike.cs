using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Collections.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableLike : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemUserProfile");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6cb2294-6a2f-47c7-8666-59f140be738d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3d0f391-ac79-4d73-b0a9-0fb3051f967b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f91c57c4-5cec-45ea-9f20-f98d48bd9278");

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    UserProfileId = table.Column<int>(type: "integer", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => new { x.UserProfileId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_Like_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Like_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e4c48fd-1d98-4e8f-872b-98ce978e42ea", null, "Admin", "ADMIN" },
                    { "48947d2c-40b3-4d7d-9910-d2fab5c0d2a1", null, "Author", "AUTHOR" },
                    { "76ea641a-3dad-4093-9e25-8e3d116e6108", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Like_ItemId",
                table: "Like",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e4c48fd-1d98-4e8f-872b-98ce978e42ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48947d2c-40b3-4d7d-9910-d2fab5c0d2a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76ea641a-3dad-4093-9e25-8e3d116e6108");

            migrationBuilder.CreateTable(
                name: "ItemUserProfile",
                columns: table => new
                {
                    LikedItemsId = table.Column<int>(type: "integer", nullable: false),
                    LikesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemUserProfile", x => new { x.LikedItemsId, x.LikesId });
                    table.ForeignKey(
                        name: "FK_ItemUserProfile_Items_LikedItemsId",
                        column: x => x.LikedItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemUserProfile_UserProfiles_LikesId",
                        column: x => x.LikesId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a6cb2294-6a2f-47c7-8666-59f140be738d", null, "User", "USER" },
                    { "c3d0f391-ac79-4d73-b0a9-0fb3051f967b", null, "Author", "AUTHOR" },
                    { "f91c57c4-5cec-45ea-9f20-f98d48bd9278", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemUserProfile_LikesId",
                table: "ItemUserProfile",
                column: "LikesId");
        }
    }
}
