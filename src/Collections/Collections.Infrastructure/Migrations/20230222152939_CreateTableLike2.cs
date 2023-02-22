using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Collections.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableLike2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Like_Items_ItemId",
                table: "Like");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_UserProfiles_UserProfileId",
                table: "Like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Like",
                table: "Like");

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

            migrationBuilder.RenameTable(
                name: "Like",
                newName: "Likes");

            migrationBuilder.RenameIndex(
                name: "IX_Like_ItemId",
                table: "Likes",
                newName: "IX_Likes_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                columns: new[] { "UserProfileId", "ItemId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08c6dfa7-3cfc-4d91-ba64-2219fec0a88c", null, "User", "USER" },
                    { "1ff5f03d-5e96-4976-a70b-fd9a2a386a5c", null, "Admin", "ADMIN" },
                    { "65dd2847-9316-4bfa-be81-b49253c1321a", null, "Author", "AUTHOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Items_ItemId",
                table: "Likes",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_UserProfiles_UserProfileId",
                table: "Likes",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Items_ItemId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_UserProfiles_UserProfileId",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

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

            migrationBuilder.RenameTable(
                name: "Likes",
                newName: "Like");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_ItemId",
                table: "Like",
                newName: "IX_Like_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Like",
                table: "Like",
                columns: new[] { "UserProfileId", "ItemId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e4c48fd-1d98-4e8f-872b-98ce978e42ea", null, "Admin", "ADMIN" },
                    { "48947d2c-40b3-4d7d-9910-d2fab5c0d2a1", null, "Author", "AUTHOR" },
                    { "76ea641a-3dad-4093-9e25-8e3d116e6108", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Items_ItemId",
                table: "Like",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_UserProfiles_UserProfileId",
                table: "Like",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
