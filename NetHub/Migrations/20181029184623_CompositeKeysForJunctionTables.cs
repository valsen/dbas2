using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NetHub.Migrations
{
    public partial class CompositeKeysForJunctionTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdCompanyFor",
                table: "ProdCompanyFor");

            migrationBuilder.DropIndex(
                name: "IX_ProdCompanyFor_MovieID",
                table: "ProdCompanyFor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenreOf",
                table: "GenreOf");

            migrationBuilder.DropIndex(
                name: "IX_GenreOf_MovieID",
                table: "GenreOf");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DirectorOf",
                table: "DirectorOf");

            migrationBuilder.DropIndex(
                name: "IX_DirectorOf_MovieID",
                table: "DirectorOf");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActsIn",
                table: "ActsIn");

            migrationBuilder.DropIndex(
                name: "IX_ActsIn_MovieID",
                table: "ActsIn");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "ProdCompanyFor");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "GenreOf");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "DirectorOf");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "ActsIn");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdCompanyFor",
                table: "ProdCompanyFor",
                columns: new[] { "MovieID", "ProdCompanyID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenreOf",
                table: "GenreOf",
                columns: new[] { "MovieID", "GenreID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DirectorOf",
                table: "DirectorOf",
                columns: new[] { "MovieID", "DirectorID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActsIn",
                table: "ActsIn",
                columns: new[] { "MovieID", "ActorID" });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MovieHistory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AccountID = table.Column<int>(nullable: false),
                    MovieID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieHistory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MovieHistory_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieLanguage",
                columns: table => new
                {
                    MovieID = table.Column<int>(nullable: false),
                    LanguageID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieLanguage", x => new { x.MovieID, x.LanguageID });
                    table.ForeignKey(
                        name: "FK_MovieLanguage_Language_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "Language",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieLanguage_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieHistory_MovieID",
                table: "MovieHistory",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieLanguage_LanguageID",
                table: "MovieLanguage",
                column: "LanguageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieHistory");

            migrationBuilder.DropTable(
                name: "MovieLanguage");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdCompanyFor",
                table: "ProdCompanyFor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenreOf",
                table: "GenreOf");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DirectorOf",
                table: "DirectorOf");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActsIn",
                table: "ActsIn");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "ProdCompanyFor",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "GenreOf",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "DirectorOf",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "ActsIn",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdCompanyFor",
                table: "ProdCompanyFor",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenreOf",
                table: "GenreOf",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DirectorOf",
                table: "DirectorOf",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActsIn",
                table: "ActsIn",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_ProdCompanyFor_MovieID",
                table: "ProdCompanyFor",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_GenreOf_MovieID",
                table: "GenreOf",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_DirectorOf_MovieID",
                table: "DirectorOf",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_ActsIn_MovieID",
                table: "ActsIn",
                column: "MovieID");
        }
    }
}
