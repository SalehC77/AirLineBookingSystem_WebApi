using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirLineBookingSystem_WebApi.Migrations
{
    /// <inheritdoc />
    public partial class modifyFlight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketBookings_Flights_FlightId",
                table: "TicketBookings");

            migrationBuilder.DropIndex(
                name: "IX_TicketBookings_FlightId",
                table: "TicketBookings");

            migrationBuilder.DropColumn(
                name: "FlightId",
                table: "TicketBookings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlightId",
                table: "TicketBookings",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TicketBookings",
                keyColumn: "Id",
                keyValue: 1,
                column: "FlightId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TicketBookings",
                keyColumn: "Id",
                keyValue: 2,
                column: "FlightId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TicketBookings",
                keyColumn: "Id",
                keyValue: 3,
                column: "FlightId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TicketBookings",
                keyColumn: "Id",
                keyValue: 4,
                column: "FlightId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "TicketBookings",
                keyColumn: "Id",
                keyValue: 5,
                column: "FlightId",
                value: 5);

            migrationBuilder.CreateIndex(
                name: "IX_TicketBookings_FlightId",
                table: "TicketBookings",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketBookings_Flights_FlightId",
                table: "TicketBookings",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id");
        }
    }
}
