using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AirLineBookingSystem_WebApi.Migrations
{
    /// <inheritdoc />
    public partial class ApplaySeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), "user02@gmail.com", "Seed_02#", "Passenger", "user02" },
                    { 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "user01@gmail.com", "Seed_01#", "Passenger", "user01" },
                    { 3, new DateTime(2026, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), "user03@gmail.com", "Seed_03#", "Passenger", "user03" },
                    { 4, new DateTime(2026, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), "user04@gmail.com", "Seed_04#", "Passenger", "user04" },
                    { 5, new DateTime(2026, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), "user05@gmail.com", "Seed_05#", "Passenger", "user05" }
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirPlaneModel", "AirPlaneRegistration", "AirlineCode", "AirlineName", "ArrivalAirport", "ArrivalTime", "DepartureAirport", "DepartureTime", "FlightNumber", "FlightStatus" },
                values: new object[,]
                {
                    { 1, "A320", "SEED-N101", "NSA", "Northstar Air", "LAX", new DateTime(2027, 1, 10, 11, 30, 0, 0, DateTimeKind.Utc), "JFK", new DateTime(2027, 1, 10, 8, 0, 0, 0, DateTimeKind.Utc), "SEED101", "Scheduled" },
                    { 2, "B737", "SEED-C202", "CDA", "Cedar Airways", "SFO", new DateTime(2027, 1, 11, 10, 30, 0, 0, DateTimeKind.Utc), "LAX", new DateTime(2027, 1, 11, 9, 0, 0, 0, DateTimeKind.Utc), "SEED202", "Scheduled" },
                    { 3, "A321", "SEED-B303", "BHA", "Blue Horizon Air", "MIA", new DateTime(2027, 1, 12, 11, 0, 0, 0, DateTimeKind.Utc), "ORD", new DateTime(2027, 1, 12, 7, 30, 0, 0, DateTimeKind.Utc), "SEED303", "Scheduled" },
                    { 4, "B787", "SEED-S404", "SMA", "Summit Airlines", "DEN", new DateTime(2027, 1, 13, 9, 0, 0, 0, DateTimeKind.Utc), "SEA", new DateTime(2027, 1, 13, 6, 0, 0, 0, DateTimeKind.Utc), "SEED404", "Scheduled" },
                    { 5, "E190", "SEED-C505", "CCC", "Coastal Connect", "IAD", new DateTime(2027, 1, 14, 13, 45, 0, 0, DateTimeKind.Utc), "BOS", new DateTime(2027, 1, 14, 12, 0, 0, 0, DateTimeKind.Utc), "SEED505", "Scheduled" }
                });

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "Gender", "LastName", "Nationality", "PassportNumber", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "Other", "Morgan", "United States", "SEED-PASS-001", "555-0101", 1 },
                    { 2, new DateTime(1988, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jordan", "Other", "Taylor", "United States", "SEED-PASS-002", "555-0102", 2 },
                    { 3, new DateTime(1995, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Casey", "Other", "Reed", "Canada", "SEED-PASS-003", "555-0103", 3 },
                    { 4, new DateTime(1992, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Riley", "Other", "Parker", "United Kingdom", "SEED-PASS-004", "555-0104", 4 },
                    { 5, new DateTime(1985, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avery", "Other", "Quinn", "Australia", "SEED-PASS-005", "555-0105", 5 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "AvailableTickets", "BoardingTime", "CheckInTime", "FlightClass", "FlightId", "GateNumber", "TicketDescription", "TicketName", "TicketPrice" },
                values: new object[,]
                {
                    { 1, 100, new DateTime(2027, 1, 10, 7, 15, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 10, 5, 0, 0, 0, DateTimeKind.Utc), "Economy", 1, "A1", "Seed ticket for flight SEED101", "SEED101 Economy", 199.99m },
                    { 2, 80, new DateTime(2027, 1, 11, 8, 15, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 11, 6, 0, 0, 0, DateTimeKind.Utc), "Economy", 2, "B2", "Seed ticket for flight SEED202", "SEED202 Economy", 149.99m },
                    { 3, 40, new DateTime(2027, 1, 12, 6, 45, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 12, 4, 30, 0, 0, DateTimeKind.Utc), "Business", 3, "C3", "Seed ticket for flight SEED303", "SEED303 Business", 499.99m },
                    { 4, 120, new DateTime(2027, 1, 13, 5, 15, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 13, 3, 0, 0, 0, DateTimeKind.Utc), "Economy", 4, "D4", "Seed ticket for flight SEED404", "SEED404 Economy", 229.99m },
                    { 5, 20, new DateTime(2027, 1, 14, 11, 15, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 14, 9, 0, 0, 0, DateTimeKind.Utc), "First Class", 5, "E5", "Seed ticket for flight SEED505", "SEED505 First Class", 899.99m },
                    { 6, 20, new DateTime(2027, 1, 14, 11, 15, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 14, 9, 0, 0, 0, DateTimeKind.Utc), "First Class", 5, "E5", "Seed ticket for flight SEED505", "SEED505 First Class", 899.99m }
                });

            migrationBuilder.InsertData(
                table: "TicketBookings",
                columns: new[] { "Id", "BookingDate", "FlightId", "PassengerId", "SeatNumber", "Status", "TicketId", "TicketNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 12, 1, 10, 0, 0, 0, DateTimeKind.Utc), 1, 1, "10A", "Booked", 1, "SEED-BOOK-001" },
                    { 2, new DateTime(2026, 12, 2, 10, 0, 0, 0, DateTimeKind.Utc), 2, 2, "11A", "Booked", 2, "SEED-BOOK-002" },
                    { 3, new DateTime(2026, 12, 3, 10, 0, 0, 0, DateTimeKind.Utc), 3, 3, "12A", "Booked", 3, "SEED-BOOK-003" },
                    { 4, new DateTime(2026, 12, 4, 10, 0, 0, 0, DateTimeKind.Utc), 4, 4, "13A", "Booked", 4, "SEED-BOOK-004" },
                    { 5, new DateTime(2026, 12, 5, 10, 0, 0, 0, DateTimeKind.Utc), 5, 5, "14A", "Booked", 5, "SEED-BOOK-005" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TicketBookings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TicketBookings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TicketBookings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TicketBookings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TicketBookings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
