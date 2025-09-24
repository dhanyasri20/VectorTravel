using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMapFeatureCleanup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivalLatitude",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "ArrivalLongitude",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "DepartureLatitude",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "DepartureLongitude",
                table: "Flights");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ArrivalLatitude",
                table: "Flights",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ArrivalLongitude",
                table: "Flights",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DepartureLatitude",
                table: "Flights",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DepartureLongitude",
                table: "Flights",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
