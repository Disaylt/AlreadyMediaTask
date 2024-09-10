using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NasaAsteroid.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeYearColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Asteroids_Year",
                schema: "nasaAsteroids",
                table: "Asteroids");

            migrationBuilder.DropColumn(
                name: "Year",
                schema: "nasaAsteroids",
                table: "Asteroids");

            migrationBuilder.AddColumn<int>(
                name: "Year_Value",
                schema: "nasaAsteroids",
                table: "Asteroids",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year_Value",
                schema: "nasaAsteroids",
                table: "Asteroids");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Year",
                schema: "nasaAsteroids",
                table: "Asteroids",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateIndex(
                name: "IX_Asteroids_Year",
                schema: "nasaAsteroids",
                table: "Asteroids",
                column: "Year");
        }
    }
}
