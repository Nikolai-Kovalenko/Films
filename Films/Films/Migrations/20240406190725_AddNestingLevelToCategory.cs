using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Films.Migrations
{
    /// <inheritdoc />
    public partial class AddNestingLevelToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Categories_CategoryId",
                table: "Films");

            migrationBuilder.DropIndex(
                name: "IX_Films_CategoryId",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Films");

            migrationBuilder.AddColumn<int>(
                name: "NestingLevel",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NestingLevel",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Films",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Films_CategoryId",
                table: "Films",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Categories_CategoryId",
                table: "Films",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
