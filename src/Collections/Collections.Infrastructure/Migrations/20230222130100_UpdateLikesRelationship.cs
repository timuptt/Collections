using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Collections.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLikesRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likes");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5b8d55ba-7647-4c29-b592-72fbe606bf45", null, "Author", "AUTHOR" },
                    { "79c3f187-5974-48f9-9f83-b8e54481a7e5", null, "Admin", "ADMIN" },
                    { "7b1edaf1-bc3b-480a-9f33-07638528e371", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Likes_ItemId",
                table: "Likes",
                column: "ItemId");
        }
    }
}
