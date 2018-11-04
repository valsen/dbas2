using Microsoft.EntityFrameworkCore.Migrations;

namespace NetHub.Migrations
{
    public partial class MinorFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_episodes_medium_episode_id",
                table: "episodes");

            migrationBuilder.DropForeignKey(
                name: "fk_history_medium_medium_id",
                table: "history");

            migrationBuilder.DropForeignKey(
                name: "fk_media_directors_medium_medium_id",
                table: "media_directors");

            migrationBuilder.DropForeignKey(
                name: "fk_movies_medium_movie_id",
                table: "movies");

            migrationBuilder.DropPrimaryKey(
                name: "pk_medium",
                table: "medium");

            migrationBuilder.RenameTable(
                name: "medium",
                newName: "media");

            migrationBuilder.AddPrimaryKey(
                name: "pk_media",
                table: "media",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_episodes_media_episode_id",
                table: "episodes",
                column: "episode_id",
                principalTable: "media",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_history_media_medium_id",
                table: "history",
                column: "medium_id",
                principalTable: "media",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_media_directors_media_medium_id",
                table: "media_directors",
                column: "medium_id",
                principalTable: "media",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_movies_media_movie_id",
                table: "movies",
                column: "movie_id",
                principalTable: "media",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_episodes_media_episode_id",
                table: "episodes");

            migrationBuilder.DropForeignKey(
                name: "fk_history_media_medium_id",
                table: "history");

            migrationBuilder.DropForeignKey(
                name: "fk_media_directors_media_medium_id",
                table: "media_directors");

            migrationBuilder.DropForeignKey(
                name: "fk_movies_media_movie_id",
                table: "movies");

            migrationBuilder.DropPrimaryKey(
                name: "pk_media",
                table: "media");

            migrationBuilder.RenameTable(
                name: "media",
                newName: "medium");

            migrationBuilder.AddPrimaryKey(
                name: "pk_medium",
                table: "medium",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_episodes_medium_episode_id",
                table: "episodes",
                column: "episode_id",
                principalTable: "medium",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_history_medium_medium_id",
                table: "history",
                column: "medium_id",
                principalTable: "medium",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_media_directors_medium_medium_id",
                table: "media_directors",
                column: "medium_id",
                principalTable: "medium",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_movies_medium_movie_id",
                table: "movies",
                column: "movie_id",
                principalTable: "medium",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
