using Microsoft.EntityFrameworkCore.Migrations;

namespace NetHub.Migrations
{
    public partial class RenameTablesUseSnakeCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieHistory_Movies_MovieID",
                table: "MovieHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieLanguage_Language_LanguageID",
                table: "MovieLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieLanguage_Movies_MovieID",
                table: "MovieLanguage");

            migrationBuilder.DropTable(
                name: "ActsIn");

            migrationBuilder.DropTable(
                name: "DirectorOf");

            migrationBuilder.DropTable(
                name: "GenreOf");

            migrationBuilder.DropTable(
                name: "ProdCompanyFor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Directors",
                table: "Directors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actors",
                table: "Actors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdCompanies",
                table: "ProdCompanies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieLanguage",
                table: "MovieLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieHistory",
                table: "MovieHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Language",
                table: "Language");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "movies");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "genres");

            migrationBuilder.RenameTable(
                name: "Directors",
                newName: "directors");

            migrationBuilder.RenameTable(
                name: "Actors",
                newName: "actors");

            migrationBuilder.RenameTable(
                name: "ProdCompanies",
                newName: "prod_companies");

            migrationBuilder.RenameTable(
                name: "MovieLanguage",
                newName: "movie_language");

            migrationBuilder.RenameTable(
                name: "MovieHistory",
                newName: "movie_history");

            migrationBuilder.RenameTable(
                name: "Language",
                newName: "movies_languages");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "movies",
                newName: "year");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "movies",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Runtime",
                table: "movies",
                newName: "runtime");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "movies",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "movies",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ImgPath",
                table: "movies",
                newName: "img_path");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "genres",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "genres",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Birthdate",
                table: "directors",
                newName: "birthdate");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "directors",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "directors",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "directors",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "Birthdate",
                table: "actors",
                newName: "birthdate");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "actors",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "actors",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "actors",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "prod_companies",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "prod_companies",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "LanguageID",
                table: "movie_language",
                newName: "language_id");

            migrationBuilder.RenameColumn(
                name: "MovieID",
                table: "movie_language",
                newName: "movie_id");

            migrationBuilder.RenameIndex(
                name: "IX_MovieLanguage_LanguageID",
                table: "movie_language",
                newName: "ix_movie_language_language_id");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "movie_history",
                newName: "rating");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "movie_history",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "movie_history",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "MovieID",
                table: "movie_history",
                newName: "movie_id");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                table: "movie_history",
                newName: "account_id");

            migrationBuilder.RenameIndex(
                name: "IX_MovieHistory_MovieID",
                table: "movie_history",
                newName: "ix_movie_history_movie_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "movies_languages",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "movies_languages",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_movies",
                table: "movies",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_genres",
                table: "genres",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_directors",
                table: "directors",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_actors",
                table: "actors",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_prod_companies",
                table: "prod_companies",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movie_language",
                table: "movie_language",
                columns: new[] { "movie_id", "language_id" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_movie_history",
                table: "movie_history",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_movies_languages",
                table: "movies_languages",
                column: "id");

            migrationBuilder.CreateTable(
                name: "movies_actors",
                columns: table => new
                {
                    actor_id = table.Column<int>(nullable: false),
                    movie_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies_actors", x => new { x.movie_id, x.actor_id });
                    table.ForeignKey(
                        name: "fk_movies_actors_actors_actor_id",
                        column: x => x.actor_id,
                        principalTable: "actors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_movies_actors_movies_movie_id",
                        column: x => x.movie_id,
                        principalTable: "movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "movies_directors",
                columns: table => new
                {
                    director_id = table.Column<int>(nullable: false),
                    movie_id = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "movies_genres",
                columns: table => new
                {
                    genre_id = table.Column<int>(nullable: false),
                    movie_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies_genres", x => new { x.movie_id, x.genre_id });
                    table.ForeignKey(
                        name: "fk_movies_genres_genres_genre_id",
                        column: x => x.genre_id,
                        principalTable: "genres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_movies_genres_movies_movie_id",
                        column: x => x.movie_id,
                        principalTable: "movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "movies_prodcompanies",
                columns: table => new
                {
                    prod_company_id = table.Column<int>(nullable: false),
                    movie_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies_prodcompanies", x => new { x.movie_id, x.prod_company_id });
                    table.ForeignKey(
                        name: "fk_movies_prodcompanies_movies_movie_id",
                        column: x => x.movie_id,
                        principalTable: "movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_movies_prodcompanies_prod_companies_prod_company_id",
                        column: x => x.prod_company_id,
                        principalTable: "prod_companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_movies_actors_actor_id",
                table: "movies_actors",
                column: "actor_id");

            migrationBuilder.CreateIndex(
                name: "ix_movies_directors_director_id",
                table: "movies_directors",
                column: "director_id");

            migrationBuilder.CreateIndex(
                name: "ix_movies_genres_genre_id",
                table: "movies_genres",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "ix_movies_prodcompanies_prod_company_id",
                table: "movies_prodcompanies",
                column: "prod_company_id");

            migrationBuilder.AddForeignKey(
                name: "fk_movie_history_movies_movie_id",
                table: "movie_history",
                column: "movie_id",
                principalTable: "movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_movie_language_movies_languages_language_id",
                table: "movie_language",
                column: "language_id",
                principalTable: "movies_languages",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_movie_language_movies_movie_id",
                table: "movie_language",
                column: "movie_id",
                principalTable: "movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_movie_history_movies_movie_id",
                table: "movie_history");

            migrationBuilder.DropForeignKey(
                name: "fk_movie_language_movies_languages_language_id",
                table: "movie_language");

            migrationBuilder.DropForeignKey(
                name: "fk_movie_language_movies_movie_id",
                table: "movie_language");

            migrationBuilder.DropTable(
                name: "movies_actors");

            migrationBuilder.DropTable(
                name: "movies_directors");

            migrationBuilder.DropTable(
                name: "movies_genres");

            migrationBuilder.DropTable(
                name: "movies_prodcompanies");

            migrationBuilder.DropPrimaryKey(
                name: "pk_movies",
                table: "movies");

            migrationBuilder.DropPrimaryKey(
                name: "pk_genres",
                table: "genres");

            migrationBuilder.DropPrimaryKey(
                name: "pk_directors",
                table: "directors");

            migrationBuilder.DropPrimaryKey(
                name: "pk_actors",
                table: "actors");

            migrationBuilder.DropPrimaryKey(
                name: "pk_prod_companies",
                table: "prod_companies");

            migrationBuilder.DropPrimaryKey(
                name: "pk_movies_languages",
                table: "movies_languages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movie_language",
                table: "movie_language");

            migrationBuilder.DropPrimaryKey(
                name: "pk_movie_history",
                table: "movie_history");

            migrationBuilder.RenameTable(
                name: "movies",
                newName: "Movies");

            migrationBuilder.RenameTable(
                name: "genres",
                newName: "Genres");

            migrationBuilder.RenameTable(
                name: "directors",
                newName: "Directors");

            migrationBuilder.RenameTable(
                name: "actors",
                newName: "Actors");

            migrationBuilder.RenameTable(
                name: "prod_companies",
                newName: "ProdCompanies");

            migrationBuilder.RenameTable(
                name: "movies_languages",
                newName: "Language");

            migrationBuilder.RenameTable(
                name: "movie_language",
                newName: "MovieLanguage");

            migrationBuilder.RenameTable(
                name: "movie_history",
                newName: "MovieHistory");

            migrationBuilder.RenameColumn(
                name: "year",
                table: "Movies",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Movies",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "runtime",
                table: "Movies",
                newName: "Runtime");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Movies",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Movies",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "img_path",
                table: "Movies",
                newName: "ImgPath");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Genres",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Genres",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "birthdate",
                table: "Directors",
                newName: "Birthdate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Directors",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Directors",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Directors",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "birthdate",
                table: "Actors",
                newName: "Birthdate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Actors",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Actors",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Actors",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "ProdCompanies",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ProdCompanies",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Language",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Language",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "language_id",
                table: "MovieLanguage",
                newName: "LanguageID");

            migrationBuilder.RenameColumn(
                name: "movie_id",
                table: "MovieLanguage",
                newName: "MovieID");

            migrationBuilder.RenameIndex(
                name: "ix_movie_language_language_id",
                table: "MovieLanguage",
                newName: "IX_MovieLanguage_LanguageID");

            migrationBuilder.RenameColumn(
                name: "rating",
                table: "MovieHistory",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "MovieHistory",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "MovieHistory",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "movie_id",
                table: "MovieHistory",
                newName: "MovieID");

            migrationBuilder.RenameColumn(
                name: "account_id",
                table: "MovieHistory",
                newName: "AccountID");

            migrationBuilder.RenameIndex(
                name: "ix_movie_history_movie_id",
                table: "MovieHistory",
                newName: "IX_MovieHistory_MovieID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Directors",
                table: "Directors",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actors",
                table: "Actors",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdCompanies",
                table: "ProdCompanies",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Language",
                table: "Language",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieLanguage",
                table: "MovieLanguage",
                columns: new[] { "MovieID", "LanguageID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieHistory",
                table: "MovieHistory",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "ActsIn",
                columns: table => new
                {
                    MovieID = table.Column<int>(nullable: false),
                    ActorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActsIn", x => new { x.MovieID, x.ActorID });
                    table.ForeignKey(
                        name: "FK_ActsIn_Actors_ActorID",
                        column: x => x.ActorID,
                        principalTable: "Actors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActsIn_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DirectorOf",
                columns: table => new
                {
                    MovieID = table.Column<int>(nullable: false),
                    DirectorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectorOf", x => new { x.MovieID, x.DirectorID });
                    table.ForeignKey(
                        name: "FK_DirectorOf_Directors_DirectorID",
                        column: x => x.DirectorID,
                        principalTable: "Directors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DirectorOf_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreOf",
                columns: table => new
                {
                    MovieID = table.Column<int>(nullable: false),
                    GenreID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreOf", x => new { x.MovieID, x.GenreID });
                    table.ForeignKey(
                        name: "FK_GenreOf_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreOf_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdCompanyFor",
                columns: table => new
                {
                    MovieID = table.Column<int>(nullable: false),
                    ProdCompanyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdCompanyFor", x => new { x.MovieID, x.ProdCompanyID });
                    table.ForeignKey(
                        name: "FK_ProdCompanyFor_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdCompanyFor_ProdCompanies_ProdCompanyID",
                        column: x => x.ProdCompanyID,
                        principalTable: "ProdCompanies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActsIn_ActorID",
                table: "ActsIn",
                column: "ActorID");

            migrationBuilder.CreateIndex(
                name: "IX_DirectorOf_DirectorID",
                table: "DirectorOf",
                column: "DirectorID");

            migrationBuilder.CreateIndex(
                name: "IX_GenreOf_GenreID",
                table: "GenreOf",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_ProdCompanyFor_ProdCompanyID",
                table: "ProdCompanyFor",
                column: "ProdCompanyID");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieHistory_Movies_MovieID",
                table: "MovieHistory",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieLanguage_Language_LanguageID",
                table: "MovieLanguage",
                column: "LanguageID",
                principalTable: "Language",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieLanguage_Movies_MovieID",
                table: "MovieLanguage",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
