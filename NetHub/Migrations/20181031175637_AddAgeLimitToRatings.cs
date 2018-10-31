using Microsoft.EntityFrameworkCore.Migrations;

namespace NetHub.Migrations
{
    public partial class AddAgeLimitToRatings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "age_limit",
                table: "ratings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age_limit",
                table: "ratings");
        }
    }
}
