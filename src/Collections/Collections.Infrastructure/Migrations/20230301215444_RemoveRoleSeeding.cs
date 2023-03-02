using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Collections.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRoleSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46215f67-eb24-425d-b8de-1b2126ec6876");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "738f5b5d-58ed-4e1e-9fbd-50b0a1361b6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e760b3eb-1fc2-4a24-9c90-57bbd3670d92");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tags",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldMaxLength: 40);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tags",
                type: "character varying(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46215f67-eb24-425d-b8de-1b2126ec6876", null, "User", "USER" },
                    { "738f5b5d-58ed-4e1e-9fbd-50b0a1361b6d", null, "Admin", "ADMIN" },
                    { "e760b3eb-1fc2-4a24-9c90-57bbd3670d92", null, "Author", "AUTHOR" }
                });
        }
    }
}
