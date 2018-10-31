using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NetHub.Migrations
{
    public partial class AddMPAARating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "rating_id",
                table: "movies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "rating",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_rating", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_movies_rating_id",
                table: "movies",
                column: "rating_id");

            migrationBuilder.AddForeignKey(
                name: "fk_movies_rating_rating_id",
                table: "movies",
                column: "rating_id",
                principalTable: "rating",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_movies_rating_rating_id",
                table: "movies");

            migrationBuilder.DropTable(
                name: "rating");

            migrationBuilder.DropIndex(
                name: "ix_movies_rating_id",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "rating_id",
                table: "movies");
        }
    }
}
