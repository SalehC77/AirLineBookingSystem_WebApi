using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AirLineBookingSystem_WebApi.Migrations
{
    /// <inheritdoc />
    public partial class initstate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AirlineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirlineCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AirPlaneModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AirPlaneRegistration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureAirportId = table.Column<int>(type: "int", nullable: false),
                    ArrivalAirportId = table.Column<int>(type: "int", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LandingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlightStatus = table.Column<int>(type: "int", nullable: false),
                    AirportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Airports_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flights_Airports_ArrivalAirportId",
                        column: x => x.ArrivalAirportId,
                        principalTable: "Airports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flights_Airports_DepartureAirportId",
                        column: x => x.DepartureAirportId,
                        principalTable: "Airports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passengers_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    TicketName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableTickets = table.Column<int>(type: "int", nullable: false),
                    TicketDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CheckInTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BoardingTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketBookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    TicketNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SeatNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassengerId = table.Column<int>(type: "int", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketBookings_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TicketBookings_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketBookings_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "City", "Code", "Country", "Name" },
                values: new object[,]
                {
                    { 1001, "الرياض", "RUH", "المملكة العربية السعودية", "مطار الملك خالد الدولي" },
                    { 1002, "جدة", "JED", "المملكة العربية السعودية", "مطار الملك عبدالعزيز الدولي" },
                    { 1003, "الدمام", "DMM", "المملكة العربية السعودية", "مطار الملك فهد الدولي" },
                    { 1004, "المدينة المنورة", "MED", "المملكة العربية السعودية", "مطار الأمير محمد بن عبدالعزيز الدولي" },
                    { 1005, "أبها", "AHB", "المملكة العربية السعودية", "مطار أبها الدولي" },
                    { 1006, "نيوم", "NUM", "المملكة العربية السعودية", "مطار نيوم باي" }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), "user02@gmail.com", "Seed_02#", "مسافر", "مستخدم02" },
                    { 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "user01@gmail.com", "Seed_01#", "مسافر", "مستخدم01" },
                    { 3, new DateTime(2026, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), "user03@gmail.com", "Seed_03#", "مسافر", "مستخدم03" },
                    { 4, new DateTime(2026, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), "user04@gmail.com", "Seed_04#", "مسافر", "مستخدم04" },
                    { 5, new DateTime(2026, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), "user05@gmail.com", "Seed_05#", "مسافر", "مستخدم05" }
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirPlaneModel", "AirPlaneRegistration", "AirlineCode", "AirlineName", "AirportId", "ArrivalAirportId", "DepartureAirportId", "DepartureDate", "DepartureDay", "DepartureTime", "FlightNumber", "FlightStatus", "LandingTime" },
                values: new object[,]
                {
                    { 1, "A320", "SEED-N101", "NSA", "طيران النجم الشمالي", null, 1002, 1001, new DateTime(2027, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "الأحد", new DateTime(2027, 1, 10, 8, 0, 0, 0, DateTimeKind.Utc), "SEED101", 0, new DateTime(2027, 1, 10, 11, 30, 0, 0, DateTimeKind.Utc) },
                    { 2, "B737", "SEED-C202", "CDA", "طيران الأرز", null, 1004, 1003, new DateTime(2027, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "الاثنين", new DateTime(2027, 1, 11, 9, 0, 0, 0, DateTimeKind.Utc), "SEED202", 0, new DateTime(2027, 1, 11, 10, 30, 0, 0, DateTimeKind.Utc) },
                    { 3, "A321", "SEED-B303", "BHA", "طيران الأفق الأزرق", null, 1006, 1005, new DateTime(2027, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "الثلاثاء", new DateTime(2027, 1, 12, 7, 30, 0, 0, DateTimeKind.Utc), "SEED303", 0, new DateTime(2027, 1, 12, 11, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, "B787", "SEED-S404", "SMA", "طيران القمة", null, 1003, 1002, new DateTime(2027, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "الأربعاء", new DateTime(2027, 1, 13, 6, 0, 0, 0, DateTimeKind.Utc), "SEED404", 0, new DateTime(2027, 1, 13, 9, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, "E190", "SEED-C505", "CCC", "طيران الساحل", null, 1004, 1001, new DateTime(2027, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "الخميس", new DateTime(2027, 1, 14, 12, 0, 0, 0, DateTimeKind.Utc), "SEED505", 0, new DateTime(2027, 1, 14, 13, 45, 0, 0, DateTimeKind.Utc) },
                    { 6, "A320", "SEED-A606", "ARA", "الخطوط العربية", null, 1005, 1004, new DateTime(2027, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "الجمعة", new DateTime(2027, 1, 15, 7, 0, 0, 0, DateTimeKind.Utc), "SEED606", 0, new DateTime(2027, 1, 15, 9, 0, 0, 0, DateTimeKind.Utc) },
                    { 7, "B737", "SEED-O707", "OAS", "طيران الواحة", null, 1001, 1006, new DateTime(2027, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "السبت", new DateTime(2027, 1, 16, 10, 0, 0, 0, DateTimeKind.Utc), "SEED707", 0, new DateTime(2027, 1, 16, 12, 15, 0, 0, DateTimeKind.Utc) },
                    { 8, "A321", "SEED-J808", "JZR", "طيران الجزيرة", null, 1005, 1003, new DateTime(2027, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "الأحد", new DateTime(2027, 1, 17, 8, 30, 0, 0, DateTimeKind.Utc), "SEED808", 0, new DateTime(2027, 1, 17, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { 9, "B787", "SEED-D909", "DSR", "طيران الصحراء", null, 1006, 1002, new DateTime(2027, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "الاثنين", new DateTime(2027, 1, 18, 14, 0, 0, 0, DateTimeKind.Utc), "SEED909", 0, new DateTime(2027, 1, 18, 16, 45, 0, 0, DateTimeKind.Utc) },
                    { 10, "E190", "SEED-F010", "FJR", "طيران الفجر", null, 1003, 1005, new DateTime(2027, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "الثلاثاء", new DateTime(2027, 1, 19, 6, 45, 0, 0, DateTimeKind.Utc), "SEED010", 0, new DateTime(2027, 1, 19, 8, 15, 0, 0, DateTimeKind.Utc) },
                    { 11, "A320", "SEED-S011", "SAA", "الخطوط السعودية", null, 1003, 1001, new DateTime(2027, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "الأربعاء", new DateTime(2027, 1, 20, 7, 0, 0, 0, DateTimeKind.Utc), "SEED011", 1, new DateTime(2027, 1, 20, 8, 30, 0, 0, DateTimeKind.Utc) },
                    { 12, "B737", "SEED-N012", "NKB", "طيران النخبة", null, 1004, 1002, new DateTime(2027, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "الخميس", new DateTime(2027, 1, 21, 9, 15, 0, 0, DateTimeKind.Utc), "SEED012", 1, new DateTime(2027, 1, 21, 11, 0, 0, 0, DateTimeKind.Utc) },
                    { 13, "A321", "SEED-M013", "MDA", "طيران المدى", null, 1005, 1003, new DateTime(2027, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "الجمعة", new DateTime(2027, 1, 22, 10, 0, 0, 0, DateTimeKind.Utc), "SEED013", 1, new DateTime(2027, 1, 22, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 14, "B787", "SEED-S014", "SHB", "طيران السحاب", null, 1006, 1004, new DateTime(2027, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "السبت", new DateTime(2027, 1, 23, 12, 30, 0, 0, DateTimeKind.Utc), "SEED014", 1, new DateTime(2027, 1, 23, 14, 45, 0, 0, DateTimeKind.Utc) },
                    { 15, "A320", "SEED-S015", "SLM", "طيران السلام", null, 1001, 1005, new DateTime(2027, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "الأحد", new DateTime(2027, 1, 24, 6, 0, 0, 0, DateTimeKind.Utc), "SEED015", 2, new DateTime(2027, 1, 24, 8, 0, 0, 0, DateTimeKind.Utc) },
                    { 16, "E190", "SEED-M016", "MSH", "طيران المشرق", null, 1002, 1006, new DateTime(2027, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "الاثنين", new DateTime(2027, 1, 25, 8, 45, 0, 0, DateTimeKind.Utc), "SEED016", 2, new DateTime(2027, 1, 25, 11, 15, 0, 0, DateTimeKind.Utc) },
                    { 17, "A321", "SEED-Y017", "YMM", "طيران اليمامة", null, 1004, 1001, new DateTime(2027, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "الثلاثاء", new DateTime(2027, 1, 26, 13, 0, 0, 0, DateTimeKind.Utc), "SEED017", 2, new DateTime(2027, 1, 26, 15, 0, 0, 0, DateTimeKind.Utc) },
                    { 18, "B737", "SEED-M018", "MDR", "طيران المدار", null, 1005, 1002, new DateTime(2027, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "الأربعاء", new DateTime(2027, 1, 27, 16, 0, 0, 0, DateTimeKind.Utc), "SEED018", 2, new DateTime(2027, 1, 27, 18, 15, 0, 0, DateTimeKind.Utc) },
                    { 19, "A320", "SEED-W019", "WAD", "طيران الوعد", null, 1002, 1001, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "الأحد", new DateTime(2024, 12, 1, 7, 0, 0, 0, DateTimeKind.Utc), "SEED019", 3, new DateTime(2024, 12, 1, 9, 0, 0, 0, DateTimeKind.Utc) },
                    { 20, "B737", "SEED-R020", "RWD", "طيران الرواد", null, 1004, 1003, new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "الاثنين", new DateTime(2024, 12, 2, 8, 30, 0, 0, DateTimeKind.Utc), "SEED020", 3, new DateTime(2024, 12, 2, 10, 0, 0, 0, DateTimeKind.Utc) },
                    { 21, "A321", "SEED-S021", "SHR", "طيران الشرق", null, 1006, 1005, new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "الثلاثاء", new DateTime(2024, 12, 3, 10, 15, 0, 0, DateTimeKind.Utc), "SEED021", 3, new DateTime(2024, 12, 3, 12, 45, 0, 0, DateTimeKind.Utc) },
                    { 22, "B787", "SEED-N022", "NHL", "طيران النخيل", null, 1001, 1004, new DateTime(2024, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "الأربعاء", new DateTime(2024, 12, 4, 13, 0, 0, 0, DateTimeKind.Utc), "SEED022", 3, new DateTime(2024, 12, 4, 15, 30, 0, 0, DateTimeKind.Utc) },
                    { 23, "A320", "SEED-A023", "AMN", "طيران الأمان", null, 1003, 1002, new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "الخميس", new DateTime(2024, 12, 5, 6, 30, 0, 0, DateTimeKind.Utc), "SEED023", 4, new DateTime(2024, 12, 5, 8, 0, 0, 0, DateTimeKind.Utc) },
                    { 24, "E190", "SEED-O024", "OAH", "طيران الواحة", null, 1005, 1006, new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "الجمعة", new DateTime(2024, 12, 6, 9, 0, 0, 0, DateTimeKind.Utc), "SEED024", 4, new DateTime(2024, 12, 6, 11, 0, 0, 0, DateTimeKind.Utc) },
                    { 25, "A321", "SEED-J025", "JZR", "طيران الجزيرة", null, 1001, 1003, new DateTime(2024, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "السبت", new DateTime(2024, 12, 7, 12, 15, 0, 0, DateTimeKind.Utc), "SEED025", 4, new DateTime(2024, 12, 7, 14, 15, 0, 0, DateTimeKind.Utc) },
                    { 26, "B737", "SEED-N026", "NOR", "طيران النور", null, 1004, 1005, new DateTime(2024, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "الأحد", new DateTime(2024, 12, 8, 15, 0, 0, 0, DateTimeKind.Utc), "SEED026", 4, new DateTime(2024, 12, 8, 17, 0, 0, 0, DateTimeKind.Utc) },
                    { 27, "A320", "SEED-S027", "SRA", "طيران السارية", null, 1005, 1001, new DateTime(2027, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "الخميس", new DateTime(2027, 1, 28, 7, 30, 0, 0, DateTimeKind.Utc), "SEED027", 0, new DateTime(2027, 1, 28, 9, 30, 0, 0, DateTimeKind.Utc) },
                    { 28, "B737", "SEED-M028", "MSR", "طيران المسار", null, 1006, 1002, new DateTime(2027, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "الجمعة", new DateTime(2027, 1, 29, 9, 45, 0, 0, DateTimeKind.Utc), "SEED028", 0, new DateTime(2027, 1, 29, 12, 30, 0, 0, DateTimeKind.Utc) },
                    { 29, "A321", "SEED-S029", "SMO", "طيران السمو", null, 1004, 1003, new DateTime(2027, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "السبت", new DateTime(2027, 1, 30, 11, 0, 0, 0, DateTimeKind.Utc), "SEED029", 0, new DateTime(2027, 1, 30, 13, 0, 0, 0, DateTimeKind.Utc) },
                    { 30, "E190", "SEED-S030", "SFW", "طيران الصفوة", null, 1002, 1004, new DateTime(2027, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "الأحد", new DateTime(2027, 1, 31, 14, 0, 0, 0, DateTimeKind.Utc), "SEED030", 0, new DateTime(2027, 1, 31, 15, 45, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "Gender", "LastName", "Nationality", "PassportNumber", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "أحمد", "ذكر", "العمري", "المملكة العربية السعودية", "SEED-PASS-001", "555-0101", 1 },
                    { 2, new DateTime(1988, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "فاطمة", "أنثى", "القحطاني", "المملكة العربية السعودية", "SEED-PASS-002", "555-0102", 2 },
                    { 3, new DateTime(1995, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "خالد", "ذكر", "الحربي", "المملكة العربية السعودية", "SEED-PASS-003", "555-0103", 3 },
                    { 4, new DateTime(1992, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "نورة", "أنثى", "العتيبي", "المملكة العربية السعودية", "SEED-PASS-004", "555-0104", 4 },
                    { 5, new DateTime(1985, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "عبدالله", "ذكر", "الشهري", "المملكة العربية السعودية", "SEED-PASS-005", "555-0105", 5 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "AvailableTickets", "BoardingTime", "CheckInTime", "FlightClass", "FlightId", "GateNumber", "TicketDescription", "TicketName", "TicketPrice" },
                values: new object[,]
                {
                    { 1, 100, new DateTime(2027, 1, 10, 7, 15, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 10, 5, 0, 0, 0, DateTimeKind.Utc), "اقتصادية", 1, "A1", "تذكرة تجريبية للرحلة SEED101", "التذكرة SEED101 - الدرجة الاقتصادية", 199.99m },
                    { 2, 80, new DateTime(2027, 1, 11, 8, 15, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 11, 6, 0, 0, 0, DateTimeKind.Utc), "اقتصادية", 2, "B2", "تذكرة تجريبية للرحلة SEED202", "التذكرة SEED202 - الدرجة الاقتصادية", 149.99m },
                    { 3, 40, new DateTime(2027, 1, 12, 6, 45, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 12, 4, 30, 0, 0, DateTimeKind.Utc), "رجال الأعمال", 3, "C3", "تذكرة تجريبية للرحلة SEED303", "التذكرة SEED303 - درجة الأعمال", 499.99m },
                    { 4, 120, new DateTime(2027, 1, 13, 5, 15, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 13, 3, 0, 0, 0, DateTimeKind.Utc), "اقتصادية", 4, "D4", "تذكرة تجريبية للرحلة SEED404", "التذكرة SEED404 - الدرجة الاقتصادية", 229.99m },
                    { 5, 20, new DateTime(2027, 1, 14, 11, 15, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 14, 9, 0, 0, 0, DateTimeKind.Utc), "الدرجة الأولى", 5, "E5", "تذكرة تجريبية للرحلة SEED505", "التذكرة SEED505 - الدرجة الأولى", 899.99m },
                    { 6, 20, new DateTime(2027, 1, 14, 11, 15, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 14, 9, 0, 0, 0, DateTimeKind.Utc), "الدرجة الأولى", 5, "E5", "تذكرة تجريبية للرحلة SEED505", "التذكرة SEED505 - الدرجة الأولى", 899.99m }
                });

            migrationBuilder.InsertData(
                table: "TicketBookings",
                columns: new[] { "Id", "BookingDate", "FlightId", "PassengerId", "SeatNumber", "Status", "TicketId", "TicketNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 12, 1, 10, 0, 0, 0, DateTimeKind.Utc), 1, 1, "10A", "محجوز", 1, "SEED-BOOK-001" },
                    { 2, new DateTime(2026, 12, 2, 10, 0, 0, 0, DateTimeKind.Utc), 2, 2, "11A", "محجوز", 2, "SEED-BOOK-002" },
                    { 3, new DateTime(2026, 12, 3, 10, 0, 0, 0, DateTimeKind.Utc), 3, 3, "12A", "محجوز", 3, "SEED-BOOK-003" },
                    { 4, new DateTime(2026, 12, 4, 10, 0, 0, 0, DateTimeKind.Utc), 4, 4, "13A", "محجوز", 4, "SEED-BOOK-004" },
                    { 5, new DateTime(2026, 12, 5, 10, 0, 0, 0, DateTimeKind.Utc), 5, 5, "14A", "محجوز", 5, "SEED-BOOK-005" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirportId",
                table: "Flights",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_ArrivalAirportId",
                table: "Flights",
                column: "ArrivalAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_DepartureAirportId",
                table: "Flights",
                column: "DepartureAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_UserId",
                table: "Passengers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketBookings_FlightId",
                table: "TicketBookings",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketBookings_PassengerId",
                table: "TicketBookings",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketBookings_TicketId",
                table: "TicketBookings",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FlightId",
                table: "Tickets",
                column: "FlightId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketBookings");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Airports");
        }
    }
}
