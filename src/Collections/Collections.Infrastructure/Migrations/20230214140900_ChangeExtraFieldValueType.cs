using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Collections.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeExtraFieldValueType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtraFieldValueTypeUserCollection");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b4536a3-cc1a-4793-ae5e-7e35bad2556f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b7bef7b-9bcf-405e-b4f1-72a176700058");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6139685-e207-46c7-ad5e-15aac69a71af");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ExtraFields");

            migrationBuilder.DropColumn(
                name: "ValueTypeId",
                table: "ExtraFields");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ExtraFieldValueTypes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserCollectionId",
                table: "ExtraFieldValueTypes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "80de99e0-03c4-496d-81fa-3b7ef5039be0", null, "Admin", "ADMIN" },
                    { "e4d75b20-8b87-47fb-a511-2e5e937e979b", null, "User", "USER" },
                    { "ee3edda6-2400-49bc-820d-680c1f3ad389", null, "Author", "AUTHOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtraFieldValueTypes_UserCollectionId",
                table: "ExtraFieldValueTypes",
                column: "UserCollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraFieldValueTypes_UserCollections_UserCollectionId",
                table: "ExtraFieldValueTypes",
                column: "UserCollectionId",
                principalTable: "UserCollections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtraFieldValueTypes_UserCollections_UserCollectionId",
                table: "ExtraFieldValueTypes");

            migrationBuilder.DropIndex(
                name: "IX_ExtraFieldValueTypes_UserCollectionId",
                table: "ExtraFieldValueTypes");

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

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ExtraFieldValueTypes");

            migrationBuilder.DropColumn(
                name: "UserCollectionId",
                table: "ExtraFieldValueTypes");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ExtraFields",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ValueTypeId",
                table: "ExtraFields",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ExtraFieldValueTypeUserCollection",
                columns: table => new
                {
                    ExtraFieldValueTypesId = table.Column<int>(type: "integer", nullable: false),
                    UserCollectionsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraFieldValueTypeUserCollection", x => new { x.ExtraFieldValueTypesId, x.UserCollectionsId });
                    table.ForeignKey(
                        name: "FK_ExtraFieldValueTypeUserCollection_ExtraFieldValueTypes_Extr~",
                        column: x => x.ExtraFieldValueTypesId,
                        principalTable: "ExtraFieldValueTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtraFieldValueTypeUserCollection_UserCollections_UserColle~",
                        column: x => x.UserCollectionsId,
                        principalTable: "UserCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2b4536a3-cc1a-4793-ae5e-7e35bad2556f", null, "Admin", "ADMIN" },
                    { "7b7bef7b-9bcf-405e-b4f1-72a176700058", null, "User", "USER" },
                    { "d6139685-e207-46c7-ad5e-15aac69a71af", null, "Author", "AUTHOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtraFieldValueTypeUserCollection_UserCollectionsId",
                table: "ExtraFieldValueTypeUserCollection",
                column: "UserCollectionsId");
        }
    }
}
