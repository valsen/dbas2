using Microsoft.EntityFrameworkCore.Migrations;

namespace NetHub.Migrations
{
    public partial class captioning : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movies_captions",
                columns: table => new
                {
                    movie_id = table.Column<int>(nullable: false),
                    language_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies_captions", x => new { x.movie_id, x.language_id });
                    table.ForeignKey(
                        name: "fk_movies_captions_languages_language_id",
                        column: x => x.language_id,
                        principalTable: "languages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_movies_captions_movies_movie_id",
                        column: x => x.movie_id,
                        principalTable: "movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_movies_captions_language_id",
                table: "movies_captions",
                column: "language_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movies_captions");
        }
    }
}
