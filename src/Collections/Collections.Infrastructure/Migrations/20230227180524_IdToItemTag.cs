using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Collections.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IdToItemTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTag_Tags_TagsTitle",
                table: "ItemTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemTag",
                table: "ItemTag");

            migrationBuilder.DropIndex(
                name: "IX_ItemTag_TagsTitle",
                table: "ItemTag");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "402ebb7d-20eb-4f2b-882c-e3b2b6284bea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d072443-78ce-40aa-a7cf-bcdaf935cc74");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80344126-f1f9-4f00-a4e9-45247b79ee4b");

            migrationBuilder.DropColumn(
                name: "TagsTitle",
                table: "ItemTag");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Tags",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "Tags",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Tags",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TagsId",
                table: "ItemTag",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemTag",
                table: "ItemTag",
                columns: new[] { "ItemsId", "TagsId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2fadd0b3-7b47-4198-a2f0-a09e91747804", null, "User", "USER" },
                    { "38408f2a-ca1f-48c4-abca-c65039d0d6c3", null, "Author", "AUTHOR" },
                    { "6b79976a-6c4a-4601-9d10-93f97cccb24a", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemTag_TagsId",
                table: "ItemTag",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTag_Tags_TagsId",
                table: "ItemTag",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTag_Tags_TagsId",
                table: "ItemTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemTag",
                table: "ItemTag");

            migrationBuilder.DropIndex(
                name: "IX_ItemTag_TagsId",
                table: "ItemTag");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fadd0b3-7b47-4198-a2f0-a09e91747804");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38408f2a-ca1f-48c4-abca-c65039d0d6c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b79976a-6c4a-4601-9d10-93f97cccb24a");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "TagsId",
                table: "ItemTag");

            migrationBuilder.AddColumn<string>(
                name: "TagsTitle",
                table: "ItemTag",
                type: "character varying(40)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Title");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemTag",
                table: "ItemTag",
                columns: new[] { "ItemsId", "TagsTitle" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "402ebb7d-20eb-4f2b-882c-e3b2b6284bea", null, "User", "USER" },
                    { "6d072443-78ce-40aa-a7cf-bcdaf935cc74", null, "Admin", "ADMIN" },
                    { "80344126-f1f9-4f00-a4e9-45247b79ee4b", null, "Author", "AUTHOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemTag_TagsTitle",
                table: "ItemTag",
                column: "TagsTitle");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTag_Tags_TagsTitle",
                table: "ItemTag",
                column: "TagsTitle",
                principalTable: "Tags",
                principalColumn: "Title",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
