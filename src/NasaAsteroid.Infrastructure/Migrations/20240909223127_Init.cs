using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NasaAsteroid.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "nasaAsteroids");

            migrationBuilder.CreateTable(
                name: "Asteroids",
                schema: "nasaAsteroids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Mass_Value = table.Column<double>(type: "double precision", nullable: true),
                    Year = table.Column<DateOnly>(type: "date", nullable: false),
                    Coordinates_Longitude = table.Column<decimal>(type: "numeric", nullable: true),
                    Coordinates_Latitude = table.Column<decimal>(type: "numeric", nullable: true),
                    FallStaus = table.Column<int>(type: "integer", nullable: false),
                    NameType = table.Column<int>(type: "integer", nullable: false),
                    ClassType = table.Column<string>(type: "text", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asteroids", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asteroids_ClassType",
                schema: "nasaAsteroids",
                table: "Asteroids",
                column: "ClassType");

            migrationBuilder.CreateIndex(
                name: "IX_Asteroids_Name",
                schema: "nasaAsteroids",
                table: "Asteroids",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Asteroids_Year",
                schema: "nasaAsteroids",
                table: "Asteroids",
                column: "Year");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asteroids",
                schema: "nasaAsteroids");
        }
    }
}
