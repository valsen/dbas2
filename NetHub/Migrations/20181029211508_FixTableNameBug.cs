using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NetHub.Migrations
{
    public partial class FixTableNameBug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_movie_history_movies_movie_id",
                table: "movie_history");

            migrationBuilder.DropTable(
                name: "movie_language");

            migrationBuilder.DropPrimaryKey(
                name: "pk_movies_languages",
                table: "movies_languages");

            migrationBuilder.DropPrimaryKey(
                name: "pk_movie_history",
                table: "movie_history");

            migrationBuilder.DropColumn(
                name: "id",
                table: "movies_languages");

            migrationBuilder.DropColumn(
                name: "name",
                table: "movies_languages");

            migrationBuilder.RenameTable(
                name: "movie_history",
                newName: "movie_histories");

            migrationBuilder.RenameIndex(
                name: "ix_movie_history_movie_id",
                table: "movie_histories",
                newName: "ix_movie_histories_movie_id");

            migrationBuilder.AddColumn<int>(
                name: "movie_id",
                table: "movies_languages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "language_id",
                table: "movies_languages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_movies_languages",
                table: "movies_languages",
                columns: new[] { "movie_id", "language_id" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_movie_histories",
                table: "movie_histories",
                column: "id");

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    cust_number = table.Column<string>(nullable: true),
                    join_date = table.Column<DateTime>(nullable: false),
                    pay_status = table.Column<int>(nullable: false),
                    expire_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accounts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_languages", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_movies_languages_language_id",
                table: "movies_languages",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "ix_movie_histories_account_id",
                table: "movie_histories",
                column: "account_id");

            migrationBuilder.AddForeignKey(
                name: "fk_movie_histories_accounts_account_id",
                table: "movie_histories",
                column: "account_id",
                principalTable: "accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_movie_histories_movies_movie_id",
                table: "movie_histories",
                column: "movie_id",
                principalTable: "movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_movies_languages_languages_language_id",
                table: "movies_languages",
                column: "language_id",
                principalTable: "languages",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_movies_languages_movies_movie_id",
                table: "movies_languages",
                column: "movie_id",
                principalTable: "movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_movie_histories_accounts_account_id",
                table: "movie_histories");

            migrationBuilder.DropForeignKey(
                name: "fk_movie_histories_movies_movie_id",
                table: "movie_histories");

            migrationBuilder.DropForeignKey(
                name: "fk_movies_languages_languages_language_id",
                table: "movies_languages");

            migrationBuilder.DropForeignKey(
                name: "fk_movies_languages_movies_movie_id",
                table: "movies_languages");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "languages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movies_languages",
                table: "movies_languages");

            migrationBuilder.DropIndex(
                name: "ix_movies_languages_language_id",
                table: "movies_languages");

            migrationBuilder.DropPrimaryKey(
                name: "pk_movie_histories",
                table: "movie_histories");

            migrationBuilder.DropIndex(
                name: "ix_movie_histories_account_id",
                table: "movie_histories");

            migrationBuilder.DropColumn(
                name: "movie_id",
                table: "movies_languages");

            migrationBuilder.DropColumn(
                name: "language_id",
                table: "movies_languages");

            migrationBuilder.RenameTable(
                name: "movie_histories",
                newName: "movie_history");

            migrationBuilder.RenameIndex(
                name: "ix_movie_histories_movie_id",
                table: "movie_history",
                newName: "ix_movie_history_movie_id");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "movies_languages",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "movies_languages",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "pk_movies_languages",
                table: "movies_languages",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_movie_history",
                table: "movie_history",
                column: "id");

            migrationBuilder.CreateTable(
                name: "movie_language",
                columns: table => new
                {
                    movie_id = table.Column<int>(nullable: false),
                    language_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movie_language", x => new { x.movie_id, x.language_id });
                    table.ForeignKey(
                        name: "fk_movie_language_movies_languages_language_id",
                        column: x => x.language_id,
                        principalTable: "movies_languages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_movie_language_movies_movie_id",
                        column: x => x.movie_id,
                        principalTable: "movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_movie_language_language_id",
                table: "movie_language",
                column: "language_id");

            migrationBuilder.AddForeignKey(
                name: "fk_movie_history_movies_movie_id",
                table: "movie_history",
                column: "movie_id",
                principalTable: "movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
