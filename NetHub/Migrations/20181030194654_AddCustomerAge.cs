using Microsoft.EntityFrameworkCore.Migrations;

namespace NetHub.Migrations
{
    public partial class AddCustomerAge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cust_number",
                table: "accounts",
                newName: "cust_name");

            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "accounts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age",
                table: "accounts");

            migrationBuilder.RenameColumn(
                name: "cust_name",
                table: "accounts",
                newName: "cust_number");
        }
    }
}
