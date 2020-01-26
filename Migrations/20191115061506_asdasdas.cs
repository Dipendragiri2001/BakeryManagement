using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class asdasdas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "TotalAmount",
                table: "Purchases",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TotalAmount",
                table: "Purchases",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
