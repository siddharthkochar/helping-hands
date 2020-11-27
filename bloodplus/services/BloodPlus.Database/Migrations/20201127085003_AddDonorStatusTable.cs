using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodPlus.Database.Migrations
{
    public partial class AddDonorStatusTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LookupTypes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DonorStatusId",
                table: "Donors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DonorStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UnavailableForDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonorStatus", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DonorStatus",
                columns: new[] { "Id", "Status", "UnavailableForDays" },
                values: new object[,]
                {
                    { 1, "Available", 0 },
                    { 2, "Verification needed", 36500 },
                    { 3, "Unreachable", 1 },
                    { 4, "Unwell", 7 },
                    { 5, "Donated", 120 },
                    { 6, "Out of station", 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LookupTypes_Name",
                table: "LookupTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donors_DonorStatusId",
                table: "Donors",
                column: "DonorStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DonorStatus_Status",
                table: "DonorStatus",
                column: "Status",
                unique: true,
                filter: "[Status] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_DonorStatus_DonorStatusId",
                table: "Donors",
                column: "DonorStatusId",
                principalTable: "DonorStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donors_DonorStatus_DonorStatusId",
                table: "Donors");

            migrationBuilder.DropTable(
                name: "DonorStatus");

            migrationBuilder.DropIndex(
                name: "IX_LookupTypes_Name",
                table: "LookupTypes");

            migrationBuilder.DropIndex(
                name: "IX_Donors_DonorStatusId",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "DonorStatusId",
                table: "Donors");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LookupTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
