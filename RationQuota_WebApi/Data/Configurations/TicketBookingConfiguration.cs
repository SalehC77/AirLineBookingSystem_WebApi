using AirLineBookingSystem_WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirLineBookingSystem_WebApi.Data.Configurations;

public class TicketBookingConfiguration : IEntityTypeConfiguration<TicketBooking>
{
    public void Configure(EntityTypeBuilder<TicketBooking> builder)
    {
        builder.HasData(
            new { Id = 1, TicketId = 1, TicketNumber = "SEED-BOOK-001", SeatNumber = "10A", BookingDate = new DateTime(2026, 12, 1, 10, 0, 0, DateTimeKind.Utc), Status = "محجوز", PassengerId = 1, FlightId = 1 },
            new { Id = 2, TicketId = 2, TicketNumber = "SEED-BOOK-002", SeatNumber = "11A", BookingDate = new DateTime(2026, 12, 2, 10, 0, 0, DateTimeKind.Utc), Status = "محجوز", PassengerId = 2, FlightId = 2 },
            new { Id = 3, TicketId = 3, TicketNumber = "SEED-BOOK-003", SeatNumber = "12A", BookingDate = new DateTime(2026, 12, 3, 10, 0, 0, DateTimeKind.Utc), Status = "محجوز", PassengerId = 3, FlightId = 3 },
            new { Id = 4, TicketId = 4, TicketNumber = "SEED-BOOK-004", SeatNumber = "13A", BookingDate = new DateTime(2026, 12, 4, 10, 0, 0, DateTimeKind.Utc), Status = "محجوز", PassengerId = 4, FlightId = 4 },
            new { Id = 5, TicketId = 5, TicketNumber = "SEED-BOOK-005", SeatNumber = "14A", BookingDate = new DateTime(2026, 12, 5, 10, 0, 0, DateTimeKind.Utc), Status = "محجوز", PassengerId = 5, FlightId = 5 });
    }
}
