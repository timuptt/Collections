using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Collections.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddValueTypesToExtraFieldValueType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsRequired",
                table: "ExtraFields");

            migrationBuilder.DropColumn(
                name: "IsVisible",
                table: "ExtraFields");

            migrationBuilder.AlterColumn<string>(
                name: "ValueType",
                table: "ExtraFieldValueTypes",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldMaxLength: 40);

            migrationBuilder.AddColumn<bool>(
                name: "IsRequired",
                table: "ExtraFieldValueTypes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVisible",
                table: "ExtraFieldValueTypes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ExtraFields",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2b4536a3-cc1a-4793-ae5e-7e35bad2556f", null, "Admin", "ADMIN" },
                    { "7b7bef7b-9bcf-405e-b4f1-72a176700058", null, "User", "USER" },
                    { "d6139685-e207-46c7-ad5e-15aac69a71af", null, "Author", "AUTHOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "IsRequired",
                table: "ExtraFieldValueTypes");

            migrationBuilder.DropColumn(
                name: "IsVisible",
                table: "ExtraFieldValueTypes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ExtraFields");

            migrationBuilder.AlterColumn<string>(
                name: "ValueType",
                table: "ExtraFieldValueTypes",
                type: "character varying(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<bool>(
                name: "IsRequired",
                table: "ExtraFields",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVisible",
                table: "ExtraFields",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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
    }
}
