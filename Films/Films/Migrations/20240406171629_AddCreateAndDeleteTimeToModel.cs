using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Films.Migrations
{
    /// <inheritdoc />
    public partial class AddCreateAndDeleteTimeToModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Films",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteTime",
                table: "Films",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Film_categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteTime",
                table: "Film_categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteTime",
                table: "Categories",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "DeleteTime",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Film_categories");

            migrationBuilder.DropColumn(
                name: "DeleteTime",
                table: "Film_categories");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeleteTime",
                table: "Categories");
        }
    }
}
