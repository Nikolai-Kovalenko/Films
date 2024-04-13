using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Films.Migrations
{
    /// <inheritdoc />
    public partial class renameFilmCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Film_categories");

            migrationBuilder.CreateTable(
                name: "FilmCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsFilmIderId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmCategories_Films_UsFilmIderId",
                        column: x => x.UsFilmIderId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmCategories_CategoryId",
                table: "FilmCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmCategories_UsFilmIderId",
                table: "FilmCategories",
                column: "UsFilmIderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmCategories");

            migrationBuilder.CreateTable(
                name: "Film_categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UsFilmIderId = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FilmId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film_categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Film_categories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Film_categories_Films_UsFilmIderId",
                        column: x => x.UsFilmIderId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Film_categories_CategoryId",
                table: "Film_categories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Film_categories_UsFilmIderId",
                table: "Film_categories",
                column: "UsFilmIderId");
        }
    }
}
