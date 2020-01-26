using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class dassda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "MaterialStocks");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Purchases",
                newName: "TotalAmount");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Purchases",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<decimal>(
                name: "AmountOfOneQuantity",
                table: "Purchases",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RatePerKg",
                table: "MaterialStocks",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountOfOneQuantity",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "RatePerKg",
                table: "MaterialStocks");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Purchases",
                newName: "Amount");

            migrationBuilder.AlterColumn<string>(
                name: "Quantity",
                table: "Purchases",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "MaterialStocks",
                nullable: false,
                defaultValue: 0);
        }
    }
}
