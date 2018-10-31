using Microsoft.EntityFrameworkCore.Migrations;

namespace NetHub.Migrations
{
    public partial class RenameRatingToRatings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_movies_rating_rating_id",
                table: "movies");

            migrationBuilder.DropPrimaryKey(
                name: "pk_rating",
                table: "rating");

            migrationBuilder.RenameTable(
                name: "rating",
                newName: "ratings");

            migrationBuilder.AddPrimaryKey(
                name: "pk_ratings",
                table: "ratings",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_movies_ratings_rating_id",
                table: "movies",
                column: "rating_id",
                principalTable: "ratings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_movies_ratings_rating_id",
                table: "movies");

            migrationBuilder.DropPrimaryKey(
                name: "pk_ratings",
                table: "ratings");

            migrationBuilder.RenameTable(
                name: "ratings",
                newName: "rating");

            migrationBuilder.AddPrimaryKey(
                name: "pk_rating",
                table: "rating",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_movies_rating_rating_id",
                table: "movies",
                column: "rating_id",
                principalTable: "rating",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
