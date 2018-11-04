using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NetHub.Migrations
{
    public partial class NewSchemas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_movies_actors_movies_movie_id",
                table: "movies_actors");

            migrationBuilder.DropForeignKey(
                name: "fk_movies_captions_movies_movie_id",
                table: "movies_captions");

            migrationBuilder.DropForeignKey(
                name: "fk_movies_genres_movies_movie_id",
                table: "movies_genres");

            migrationBuilder.DropForeignKey(
                name: "fk_movies_languages_movies_movie_id",
                table: "movies_languages");

            migrationBuilder.DropForeignKey(
                name: "fk_movies_prodcompanies_movies_movie_id",
                table: "movies_prodcompanies");

            migrationBuilder.DropTable(
                name: "movie_histories");

            migrationBuilder.DropTable(
                name: "movies_directors");

            migrationBuilder.DropPrimaryKey(
                name: "pk_movies",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "id",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "description",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "title",
                table: "movies");

            migrationBuilder.RenameColumn(
                name: "runtime",
                table: "movies",
                newName: "movie_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_movies",
                table: "movies",
                column: "movie_id");

            migrationBuilder.CreateTable(
                name: "medium",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    title = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    runtime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_medium", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "series",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    title = table.Column<string>(nullable: true),
                    year = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    img_path = table.Column<string>(nullable: true),
                    rating_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_series", x => x.id);
                    table.ForeignKey(
                        name: "fk_series_ratings_rating_id",
                        column: x => x.rating_id,
                        principalTable: "ratings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "history",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    account_id = table.Column<int>(nullable: false),
                    medium_id = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_history", x => x.id);
                    table.ForeignKey(
                        name: "fk_history_accounts_account_id",
                        column: x => x.account_id,
                        principalTable: "accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_history_medium_medium_id",
                        column: x => x.medium_id,
                        principalTable: "medium",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "media_directors",
                columns: table => new
                {
                    director_id = table.Column<int>(nullable: false),
                    media_id = table.Column<int>(nullable: false),
                    medium_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_media_directors", x => new { x.media_id, x.director_id });
                    table.ForeignKey(
                        name: "fk_media_directors_directors_director_id",
                        column: x => x.director_id,
                        principalTable: "directors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_media_directors_medium_medium_id",
                        column: x => x.medium_id,
                        principalTable: "medium",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "seasons",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    series_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_seasons", x => x.id);
                    table.ForeignKey(
                        name: "fk_seasons_series_series_id",
                        column: x => x.series_id,
                        principalTable: "series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "series_actors",
                columns: table => new
                {
                    actor_id = table.Column<int>(nullable: false),
                    series_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_series_actors", x => new { x.series_id, x.actor_id });
                    table.ForeignKey(
                        name: "fk_series_actors_actors_actor_id",
                        column: x => x.actor_id,
                        principalTable: "actors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_series_actors_series_series_id",
                        column: x => x.series_id,
                        principalTable: "series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "series_captions",
                columns: table => new
                {
                    series_id = table.Column<int>(nullable: false),
                    language_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_series_captions", x => new { x.series_id, x.language_id });
                    table.ForeignKey(
                        name: "fk_series_captions_languages_language_id",
                        column: x => x.language_id,
                        principalTable: "languages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_series_captions_series_series_id",
                        column: x => x.series_id,
                        principalTable: "series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "series_genres",
                columns: table => new
                {
                    genre_id = table.Column<int>(nullable: false),
                    series_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_series_genres", x => new { x.series_id, x.genre_id });
                    table.ForeignKey(
                        name: "fk_series_genres_genres_genre_id",
                        column: x => x.genre_id,
                        principalTable: "genres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_series_genres_series_series_id",
                        column: x => x.series_id,
                        principalTable: "series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "series_languages",
                columns: table => new
                {
                    series_id = table.Column<int>(nullable: false),
                    language_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_series_languages", x => new { x.series_id, x.language_id });
                    table.ForeignKey(
                        name: "fk_series_languages_languages_language_id",
                        column: x => x.language_id,
                        principalTable: "languages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_series_languages_series_series_id",
                        column: x => x.series_id,
                        principalTable: "series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "series_prodcompanies",
                columns: table => new
                {
                    prod_company_id = table.Column<int>(nullable: false),
                    series_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_series_prodcompanies", x => new { x.series_id, x.prod_company_id });
                    table.ForeignKey(
                        name: "fk_series_prodcompanies_prod_companies_prod_company_id",
                        column: x => x.prod_company_id,
                        principalTable: "prod_companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_series_prodcompanies_series_series_id",
                        column: x => x.series_id,
                        principalTable: "series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "episodes",
                columns: table => new
                {
                    episode_id = table.Column<int>(nullable: false),
                    episode_num = table.Column<int>(nullable: false),
                    season_id = table.Column<int>(nullable: false),
                    series_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_episodes", x => x.episode_id);
                    table.ForeignKey(
                        name: "fk_episodes_medium_episode_id",
                        column: x => x.episode_id,
                        principalTable: "medium",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_episodes_seasons_season_id",
                        column: x => x.season_id,
                        principalTable: "seasons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_episodes_series_series_id",
                        column: x => x.series_id,
                        principalTable: "series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_episodes_season_id",
                table: "episodes",
                column: "season_id");

            migrationBuilder.CreateIndex(
                name: "ix_episodes_series_id",
                table: "episodes",
                column: "series_id");

            migrationBuilder.CreateIndex(
                name: "ix_history_account_id",
                table: "history",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "ix_history_medium_id",
                table: "history",
                column: "medium_id");

            migrationBuilder.CreateIndex(
                name: "ix_media_directors_director_id",
                table: "media_directors",
                column: "director_id");

            migrationBuilder.CreateIndex(
                name: "ix_media_directors_medium_id",
                table: "media_directors",
                column: "medium_id");

            migrationBuilder.CreateIndex(
                name: "ix_seasons_series_id",
                table: "seasons",
                column: "series_id");

            migrationBuilder.CreateIndex(
                name: "ix_series_rating_id",
                table: "series",
                column: "rating_id");

            migrationBuilder.CreateIndex(
                name: "ix_series_actors_actor_id",
                table: "series_actors",
                column: "actor_id");

            migrationBuilder.CreateIndex(
                name: "ix_series_captions_language_id",
                table: "series_captions",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "ix_series_genres_genre_id",
                table: "series_genres",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "ix_series_languages_language_id",
                table: "series_languages",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "ix_series_prodcompanies_prod_company_id",
                table: "series_prodcompanies",
                column: "prod_company_id");

            migrationBuilder.AddForeignKey(
                name: "fk_movies_medium_movie_id",
                table: "movies",
                column: "movie_id",
                principalTable: "medium",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_movies_actors_movies_movie_id",
                table: "movies_actors",
                column: "movie_id",
                principalTable: "movies",
                principalColumn: "movie_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_movies_captions_movies_movie_id",
                table: "movies_captions",
                column: "movie_id",
                principalTable: "movies",
                principalColumn: "movie_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_movies_genres_movies_movie_id",
                table: "movies_genres",
                column: "movie_id",
                principalTable: "movies",
                principalColumn: "movie_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_movies_languages_movies_movie_id",
                table: "movies_languages",
                column: "movie_id",
                principalTable: "movies",
                principalColumn: "movie_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_movies_prodcompanies_movies_movie_id",
                table: "movies_prodcompanies",
                column: "movie_id",
                principalTable: "movies",
                principalColumn: "movie_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_movies_medium_movie_id",
                table: "movies");

            migrationBuilder.DropForeignKey(
                name: "fk_movies_actors_movies_movie_id",
                table: "movies_actors");

            migrationBuilder.DropForeignKey(
                name: "fk_movies_captions_movies_movie_id",
                table: "movies_captions");

            migrationBuilder.DropForeignKey(
                name: "fk_movies_genres_movies_movie_id",
                table: "movies_genres");

            migrationBuilder.DropForeignKey(
                name: "fk_movies_languages_movies_movie_id",
                table: "movies_languages");

            migrationBuilder.DropForeignKey(
                name: "fk_movies_prodcompanies_movies_movie_id",
                table: "movies_prodcompanies");

            migrationBuilder.DropTable(
                name: "episodes");

            migrationBuilder.DropTable(
                name: "history");

            migrationBuilder.DropTable(
                name: "media_directors");

            migrationBuilder.DropTable(
                name: "series_actors");

            migrationBuilder.DropTable(
                name: "series_captions");

            migrationBuilder.DropTable(
                name: "series_genres");

            migrationBuilder.DropTable(
                name: "series_languages");

            migrationBuilder.DropTable(
                name: "series_prodcompanies");

            migrationBuilder.DropTable(
                name: "seasons");

            migrationBuilder.DropTable(
                name: "medium");

            migrationBuilder.DropTable(
                name: "series");

            migrationBuilder.DropPrimaryKey(
                name: "pk_movies",
                table: "movies");

            migrationBuilder.RenameColumn(
                name: "movie_id",
                table: "movies",
                newName: "runtime");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "movies",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "movies",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_movies",
                table: "movies",
                column: "id");

            migrationBuilder.CreateTable(
                name: "movie_histories",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    account_id = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    movie_id = table.Column<int>(nullable: false),
                    rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_movie_histories", x => x.id);
                    table.ForeignKey(
                        name: "fk_movie_histories_accounts_account_id",
                        column: x => x.account_id,
                        principalTable: "accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_movie_histories_movies_movie_id",
                        column: x => x.movie_id,
                        principalTable: "movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "movies_directors",
                columns: table => new
                {
                    movie_id = table.Column<int>(nullable: false),
                    director_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies_directors", x => new { x.movie_id, x.director_id });
                    table.ForeignKey(
                        name: "fk_movies_directors_directors_director_id",
                        column: x => x.director_id,
                        principalTable: "directors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_movies_directors_movies_movie_id",
                        column: x => x.movie_id,
                        principalTable: "movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_movie_histories_account_id",
                table: "movie_histories",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "ix_movie_histories_movie_id",
                table: "movie_histories",
                column: "movie_id");

            migrationBuilder.CreateIndex(
                name: "ix_movies_directors_director_id",
                table: "movies_directors",
                column: "director_id");

            migrationBuilder.AddForeignKey(
                name: "fk_movies_actors_movies_movie_id",
                table: "movies_actors",
                column: "movie_id",
                principalTable: "movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_movies_captions_movies_movie_id",
                table: "movies_captions",
                column: "movie_id",
                principalTable: "movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_movies_genres_movies_movie_id",
                table: "movies_genres",
                column: "movie_id",
                principalTable: "movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_movies_languages_movies_movie_id",
                table: "movies_languages",
                column: "movie_id",
                principalTable: "movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_movies_prodcompanies_movies_movie_id",
                table: "movies_prodcompanies",
                column: "movie_id",
                principalTable: "movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
