using Microsoft.EntityFrameworkCore.Migrations;

namespace NetHub.Migrations
{
    public partial class FixMediaDirectorFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_media_directors_media_medium_id",
                table: "media_directors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_media_directors",
                table: "media_directors");

            migrationBuilder.DropIndex(
                name: "ix_media_directors_medium_id",
                table: "media_directors");

            migrationBuilder.DropColumn(
                name: "media_id",
                table: "media_directors");

            migrationBuilder.AlterColumn<int>(
                name: "medium_id",
                table: "media_directors",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_media_directors",
                table: "media_directors",
                columns: new[] { "medium_id", "director_id" });

            migrationBuilder.AddForeignKey(
                name: "fk_media_directors_media_medium_id",
                table: "media_directors",
                column: "medium_id",
                principalTable: "media",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_media_directors_media_medium_id",
                table: "media_directors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_media_directors",
                table: "media_directors");

            migrationBuilder.AlterColumn<int>(
                name: "medium_id",
                table: "media_directors",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "media_id",
                table: "media_directors",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_media_directors",
                table: "media_directors",
                columns: new[] { "media_id", "director_id" });

            migrationBuilder.CreateIndex(
                name: "ix_media_directors_medium_id",
                table: "media_directors",
                column: "medium_id");

            migrationBuilder.AddForeignKey(
                name: "fk_media_directors_media_medium_id",
                table: "media_directors",
                column: "medium_id",
                principalTable: "media",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
