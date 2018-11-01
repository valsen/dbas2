using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NetHub.Migrations
{
    public partial class LowerCaseTitleColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Movies",
                newName: "title");

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
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MovieID = table.Column<int>(nullable: false),
                    LanguageID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieLanguage", x => x.ID);
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

            migrationBuilder.CreateIndex(
                name: "IX_MovieLanguage_MovieID",
                table: "MovieLanguage",
                column: "MovieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieHistory");

            migrationBuilder.DropTable(
                name: "MovieLanguage");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Movies",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Movies",
                nullable: true);
        }
    }
}
