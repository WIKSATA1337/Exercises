using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rent_a_Car.Data.Migrations
{
    public partial class FixedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalData_Cars_CarId",
                table: "RentalData");

            migrationBuilder.DropIndex(
                name: "IX_RentalData_CarId",
                table: "RentalData");

            migrationBuilder.AlterColumn<string>(
                name: "CarId",
                table: "RentalData",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CarId",
                table: "RentalData",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_RentalData_CarId",
                table: "RentalData",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalData_Cars_CarId",
                table: "RentalData",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
