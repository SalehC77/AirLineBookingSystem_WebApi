using AirLineBookingSystem_WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirLineBookingSystem_WebApi.Data.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasData(
            new Ticket { Id = 1, FlightId = 1, TicketName = "التذكرة SEED101 - الدرجة الاقتصادية", AvailableTickets = 100, TicketDescription = "تذكرة تجريبية للرحلة SEED101", FlightClass = "اقتصادية", TicketPrice = 199.99m, CheckInTime = new DateTime(2027, 1, 10, 5, 0, 0, DateTimeKind.Utc), BoardingTime = new DateTime(2027, 1, 10, 7, 15, 0, DateTimeKind.Utc), GateNumber = "A1" },
            new Ticket { Id = 2, FlightId = 2, TicketName = "التذكرة SEED202 - الدرجة الاقتصادية", AvailableTickets = 80, TicketDescription = "تذكرة تجريبية للرحلة SEED202", FlightClass = "اقتصادية", TicketPrice = 149.99m, CheckInTime = new DateTime(2027, 1, 11, 6, 0, 0, DateTimeKind.Utc), BoardingTime = new DateTime(2027, 1, 11, 8, 15, 0, DateTimeKind.Utc), GateNumber = "B2" },
            new Ticket { Id = 3, FlightId = 3, TicketName = "التذكرة SEED303 - درجة الأعمال", AvailableTickets = 40, TicketDescription = "تذكرة تجريبية للرحلة SEED303", FlightClass = "رجال الأعمال", TicketPrice = 499.99m, CheckInTime = new DateTime(2027, 1, 12, 4, 30, 0, DateTimeKind.Utc), BoardingTime = new DateTime(2027, 1, 12, 6, 45, 0, DateTimeKind.Utc), GateNumber = "C3" },
            new Ticket { Id = 4, FlightId = 4, TicketName = "التذكرة SEED404 - الدرجة الاقتصادية", AvailableTickets = 120, TicketDescription = "تذكرة تجريبية للرحلة SEED404", FlightClass = "اقتصادية", TicketPrice = 229.99m, CheckInTime = new DateTime(2027, 1, 13, 3, 0, 0, DateTimeKind.Utc), BoardingTime = new DateTime(2027, 1, 13, 5, 15, 0, DateTimeKind.Utc), GateNumber = "D4" },
            new Ticket { Id = 5, FlightId = 5, TicketName = "التذكرة SEED505 - الدرجة الأولى", AvailableTickets = 20, TicketDescription = "تذكرة تجريبية للرحلة SEED505", FlightClass = "الدرجة الأولى", TicketPrice = 899.99m, CheckInTime = new DateTime(2027, 1, 14, 9, 0, 0, DateTimeKind.Utc), BoardingTime = new DateTime(2027, 1, 14, 11, 15, 0, DateTimeKind.Utc), GateNumber = "E5" },
            new Ticket { Id = 6, FlightId = 5, TicketName = "التذكرة SEED505 - الدرجة الأولى", AvailableTickets = 20, TicketDescription = "تذكرة تجريبية للرحلة SEED505", FlightClass = "الدرجة الأولى", TicketPrice = 899.99m, CheckInTime = new DateTime(2027, 1, 14, 9, 0, 0, DateTimeKind.Utc), BoardingTime = new DateTime(2027, 1, 14, 11, 15, 0, DateTimeKind.Utc), GateNumber = "E5" });
    }
}
