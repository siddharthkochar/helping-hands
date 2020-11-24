using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodPlus.Database.Migrations
{
    public partial class RemoveDonorCitiesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonorCities");

            migrationBuilder.CreateTable(
                name: "CityDonor",
                columns: table => new
                {
                    CitiesId = table.Column<int>(type: "int", nullable: false),
                    DonorsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityDonor", x => new { x.CitiesId, x.DonorsId });
                    table.ForeignKey(
                        name: "FK_CityDonor_Cities_CitiesId",
                        column: x => x.CitiesId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityDonor_Donors_DonorsId",
                        column: x => x.DonorsId,
                        principalTable: "Donors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityDonor_DonorsId",
                table: "CityDonor",
                column: "DonorsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityDonor");

            migrationBuilder.CreateTable(
                name: "DonorCities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    DonorId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonorCities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonorCities_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonorCities_Donors_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Donors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonorCities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonorCities_CityId",
                table: "DonorCities",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_DonorCities_DonorId_CityId",
                table: "DonorCities",
                columns: new[] { "DonorId", "CityId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DonorCities_StateId",
                table: "DonorCities",
                column: "StateId");
        }
    }
}
