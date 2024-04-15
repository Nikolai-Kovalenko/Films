using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Films.Migrations
{
    /// <inheritdoc />
    public partial class changeFK_inFilmCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmCategories_Films_UsFilmIderId",
                table: "FilmCategories");

            migrationBuilder.DropIndex(
                name: "IX_FilmCategories_UsFilmIderId",
                table: "FilmCategories");

            migrationBuilder.DropColumn(
                name: "UsFilmIderId",
                table: "FilmCategories");

            migrationBuilder.CreateIndex(
                name: "IX_FilmCategories_FilmId",
                table: "FilmCategories",
                column: "FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmCategories_Films_FilmId",
                table: "FilmCategories",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmCategories_Films_FilmId",
                table: "FilmCategories");

            migrationBuilder.DropIndex(
                name: "IX_FilmCategories_FilmId",
                table: "FilmCategories");

            migrationBuilder.AddColumn<int>(
                name: "UsFilmIderId",
                table: "FilmCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FilmCategories_UsFilmIderId",
                table: "FilmCategories",
                column: "UsFilmIderId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmCategories_Films_UsFilmIderId",
                table: "FilmCategories",
                column: "UsFilmIderId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
