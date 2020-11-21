using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodPlus.Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Donors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    GenderId = table.Column<int>(nullable: false),
                    BloodGroupId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Contact = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookupTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserActivityLogs",
                columns: table => new
                {
                    DeviceId = table.Column<Guid>(nullable: false),
                    ActivityId = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LookupValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: false),
                    LookupTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LookupValues_LookupTypes_LookupTypeId",
                        column: x => x.LookupTypeId,
                        principalTable: "LookupTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DonorCities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonorId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonorCities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonorCities_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DonorCities_Donors_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Donors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DonorCities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "India" });

            migrationBuilder.InsertData(
                table: "LookupTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Gender" },
                    { 2, "BloodGroup" },
                    { 3, "Status" },
                    { 4, "UserActivity" }
                });

            migrationBuilder.InsertData(
                table: "LookupValues",
                columns: new[] { "Id", "LookupTypeId", "Value" },
                values: new object[,]
                {
                    { 22, 4, "Register" },
                    { 1, 1, "M" },
                    { 2, 1, "F" },
                    { 3, 2, "AB+" },
                    { 4, 2, "AB-" },
                    { 5, 2, "A+" },
                    { 6, 2, "A-" },
                    { 7, 2, "B+" },
                    { 9, 2, "O+" },
                    { 10, 2, "O-" },
                    { 8, 2, "B-" },
                    { 12, 3, "Fake" },
                    { 20, 4, "Search" },
                    { 11, 3, "Available" },
                    { 18, 3, "Nine" },
                    { 17, 3, "Not Well" },
                    { 19, 3, "false" },
                    { 15, 3, "Unreachable" },
                    { 14, 3, "More" },
                    { 13, 3, "Inappropriate" },
                    { 16, 3, "Other" },
                    { 21, 4, "Feedback" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 30, 1, "Sikkim" },
                    { 35, 1, "West Bengal" },
                    { 34, 1, "Uttaranchal" },
                    { 33, 1, "Uttar Pradesh" },
                    { 32, 1, "Tripura" },
                    { 31, 1, "Tamil Nadu" },
                    { 29, 1, "Rajasthan" },
                    { 27, 1, "Pondicherry *" },
                    { 2, 1, "Andhra Pradesh" },
                    { 3, 1, "Arunachal Pradesh" },
                    { 4, 1, "Assam" },
                    { 5, 1, "Bihar" },
                    { 6, 1, "Chandigarh *" },
                    { 7, 1, "Chhattisgarh" },
                    { 8, 1, "Dadra & Nagar Haveli" },
                    { 9, 1, "Daman & Diu *" },
                    { 10, 1, "Delhi *" },
                    { 11, 1, "Goa" },
                    { 12, 1, "Gujarat" },
                    { 13, 1, "Haryana" },
                    { 14, 1, "Himachal Pradesh" },
                    { 15, 1, "Jammu & Kashmir" },
                    { 16, 1, "Jharkhand" },
                    { 17, 1, "Karnataka" },
                    { 18, 1, "Kerala" },
                    { 19, 1, "Lakshadweep *" },
                    { 20, 1, "Madhya Pradesh" },
                    { 21, 1, "Maharashtra" },
                    { 22, 1, "Manipur" },
                    { 23, 1, "Meghalaya" },
                    { 24, 1, "Mizoram" },
                    { 25, 1, "Nagaland" },
                    { 26, 1, "Orissa" },
                    { 28, 1, "Punjab" },
                    { 1, 1, "Andaman & Nicobar Is" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId_Name",
                table: "Cities",
                columns: new[] { "StateId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DonorCities_CityId",
                table: "DonorCities",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_DonorCities_StateId",
                table: "DonorCities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_DonorCities_DonorId_CityId",
                table: "DonorCities",
                columns: new[] { "DonorId", "CityId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donors_Contact",
                table: "Donors",
                column: "Contact",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LookupValues_LookupTypeId_Value",
                table: "LookupValues",
                columns: new[] { "LookupTypeId", "Value" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId_Name",
                table: "States",
                columns: new[] { "CountryId", "Name" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonorCities");

            migrationBuilder.DropTable(
                name: "LookupValues");

            migrationBuilder.DropTable(
                name: "UserActivityLogs");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Donors");

            migrationBuilder.DropTable(
                name: "LookupTypes");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
