using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class InitTestForecasrDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Country = table.Column<string>(maxLength: 2, nullable: false),
                    Latitude = table.Column<decimal>(nullable: false),
                    Longitude = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrecipitationSpans",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StartPrecip = table.Column<DateTime>(nullable: false),
                    EndPrecip = table.Column<DateTime>(nullable: false),
                    PrecipType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecipitationSpans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Temperature = table.Column<decimal>(nullable: false),
                    Pressure = table.Column<decimal>(nullable: false),
                    CityId = table.Column<long>(nullable: false),
                    PrecipitationSpanId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherForecasts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeatherForecasts_PrecipitationSpans_PrecipitationSpanId",
                        column: x => x.PrecipitationSpanId,
                        principalTable: "PrecipitationSpans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecasts_CityId",
                table: "WeatherForecasts",
                column: "CityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecasts_PrecipitationSpanId",
                table: "WeatherForecasts",
                column: "PrecipitationSpanId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherForecasts");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "PrecipitationSpans");
        }
    }
}
