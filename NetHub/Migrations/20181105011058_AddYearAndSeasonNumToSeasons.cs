using Microsoft.EntityFrameworkCore.Migrations;

namespace NetHub.Migrations
{
    public partial class AddYearAndSeasonNumToSeasons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "year",
                table: "series");

            migrationBuilder.AddColumn<int>(
                name: "season_num",
                table: "seasons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "year",
                table: "seasons",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "season_num",
                table: "seasons");

            migrationBuilder.DropColumn(
                name: "year",
                table: "seasons");

            migrationBuilder.AddColumn<int>(
                name: "year",
                table: "series",
                nullable: false,
                defaultValue: 0);
        }
    }
}
