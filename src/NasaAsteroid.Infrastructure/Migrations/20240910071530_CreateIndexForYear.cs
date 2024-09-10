using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NasaAsteroid.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateIndexForYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Asteroids_Year_Value",
                schema: "nasaAsteroids",
                table: "Asteroids",
                column: "Year_Value");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Asteroids_Year_Value",
                schema: "nasaAsteroids",
                table: "Asteroids");
        }
    }
}
