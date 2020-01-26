using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class asdasdasdalkkl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PurchaseName",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchaseName",
                table: "Products");
        }
    }
}
