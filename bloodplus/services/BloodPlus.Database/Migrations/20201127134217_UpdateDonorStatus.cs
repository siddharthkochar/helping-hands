using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodPlus.Database.Migrations
{
    public partial class UpdateDonorStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UnavailableForDays",
                table: "DonorStatus",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "DonorStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "UnavailableForDays",
                value: null);

            migrationBuilder.UpdateData(
                table: "DonorStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "UnavailableForDays",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UnavailableForDays",
                table: "DonorStatus",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "DonorStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "UnavailableForDays",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DonorStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "UnavailableForDays",
                value: 36500);
        }
    }
}
