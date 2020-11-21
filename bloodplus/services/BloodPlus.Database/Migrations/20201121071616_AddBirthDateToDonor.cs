using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodPlus.Database.Migrations
{
    public partial class AddBirthDateToDonor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Donors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Donors");
        }
    }
}
