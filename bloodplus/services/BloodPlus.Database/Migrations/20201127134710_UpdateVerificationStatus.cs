using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodPlus.Database.Migrations
{
    public partial class UpdateVerificationStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DonorStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "UnavailableForDays",
                value: 36500);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DonorStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "UnavailableForDays",
                value: null);
        }
    }
}
