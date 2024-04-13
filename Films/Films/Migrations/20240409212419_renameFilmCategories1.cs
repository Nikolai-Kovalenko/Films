using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Films.Migrations
{
    /// <inheritdoc />
    public partial class renameFilmCategories1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmCategories_Categories_CategoryId",
                table: "FilmCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmCategories_Films_UsFilmIderId",
                table: "FilmCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmCategories",
                table: "FilmCategories");

            migrationBuilder.RenameTable(
                name: "FilmCategories",
                newName: "FilmCatasfasfegories");

            migrationBuilder.RenameIndex(
                name: "IX_FilmCategories_UsFilmIderId",
                table: "FilmCatasfasfegories",
                newName: "IX_FilmCatasfasfegories_UsFilmIderId");

            migrationBuilder.RenameIndex(
                name: "IX_FilmCategories_CategoryId",
                table: "FilmCatasfasfegories",
                newName: "IX_FilmCatasfasfegories_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmCatasfasfegories",
                table: "FilmCatasfasfegories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmCatasfasfegories_Categories_CategoryId",
                table: "FilmCatasfasfegories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmCatasfasfegories_Films_UsFilmIderId",
                table: "FilmCatasfasfegories",
                column: "UsFilmIderId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmCatasfasfegories_Categories_CategoryId",
                table: "FilmCatasfasfegories");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmCatasfasfegories_Films_UsFilmIderId",
                table: "FilmCatasfasfegories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmCatasfasfegories",
                table: "FilmCatasfasfegories");

            migrationBuilder.RenameTable(
                name: "FilmCatasfasfegories",
                newName: "FilmCategories");

            migrationBuilder.RenameIndex(
                name: "IX_FilmCatasfasfegories_UsFilmIderId",
                table: "FilmCategories",
                newName: "IX_FilmCategories_UsFilmIderId");

            migrationBuilder.RenameIndex(
                name: "IX_FilmCatasfasfegories_CategoryId",
                table: "FilmCategories",
                newName: "IX_FilmCategories_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmCategories",
                table: "FilmCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmCategories_Categories_CategoryId",
                table: "FilmCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
