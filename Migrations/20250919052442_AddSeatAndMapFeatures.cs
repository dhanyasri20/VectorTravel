using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddSeatAndMapFeatures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seat_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seat_FlightId",
                table: "Seat",
                column: "FlightId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seat");

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
    }
}
