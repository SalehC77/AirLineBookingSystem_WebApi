using AirLineBookingSystem_WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirLineBookingSystem_WebApi.Data.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasData(
            new Ticket { Id = 1, FlightId = 1, TicketName = "SEED101 Economy", AvailableTickets = 100, TicketDescription = "Seed ticket for flight SEED101", FlightClass = "Economy", TicketPrice = 199.99m, CheckInTime = new DateTime(2027, 1, 10, 5, 0, 0, DateTimeKind.Utc), BoardingTime = new DateTime(2027, 1, 10, 7, 15, 0, DateTimeKind.Utc), GateNumber = "A1" },
            new Ticket { Id = 2, FlightId = 2, TicketName = "SEED202 Economy", AvailableTickets = 80, TicketDescription = "Seed ticket for flight SEED202", FlightClass = "Economy", TicketPrice = 149.99m, CheckInTime = new DateTime(2027, 1, 11, 6, 0, 0, DateTimeKind.Utc), BoardingTime = new DateTime(2027, 1, 11, 8, 15, 0, DateTimeKind.Utc), GateNumber = "B2" },
            new Ticket { Id = 3, FlightId = 3, TicketName = "SEED303 Business", AvailableTickets = 40, TicketDescription = "Seed ticket for flight SEED303", FlightClass = "Business", TicketPrice = 499.99m, CheckInTime = new DateTime(2027, 1, 12, 4, 30, 0, DateTimeKind.Utc), BoardingTime = new DateTime(2027, 1, 12, 6, 45, 0, DateTimeKind.Utc), GateNumber = "C3" },
            new Ticket { Id = 4, FlightId = 4, TicketName = "SEED404 Economy", AvailableTickets = 120, TicketDescription = "Seed ticket for flight SEED404", FlightClass = "Economy", TicketPrice = 229.99m, CheckInTime = new DateTime(2027, 1, 13, 3, 0, 0, DateTimeKind.Utc), BoardingTime = new DateTime(2027, 1, 13, 5, 15, 0, DateTimeKind.Utc), GateNumber = "D4" },
            new Ticket { Id = 5, FlightId = 5, TicketName = "SEED505 First Class", AvailableTickets = 20, TicketDescription = "Seed ticket for flight SEED505", FlightClass = "First Class", TicketPrice = 899.99m, CheckInTime = new DateTime(2027, 1, 14, 9, 0, 0, DateTimeKind.Utc), BoardingTime = new DateTime(2027, 1, 14, 11, 15, 0, DateTimeKind.Utc), GateNumber = "E5" },
            new Ticket { Id = 6, FlightId = 5, TicketName = "SEED505 First Class", AvailableTickets = 20, TicketDescription = "Seed ticket for flight SEED505", FlightClass = "First Class", TicketPrice = 899.99m, CheckInTime = new DateTime(2027, 1, 14, 9, 0, 0, DateTimeKind.Utc), BoardingTime = new DateTime(2027, 1, 14, 11, 15, 0, DateTimeKind.Utc), GateNumber = "E5" });
    }
}
