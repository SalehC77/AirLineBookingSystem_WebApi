using AirLineBookingSystem_WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirLineBookingSystem_WebApi.Data.Configurations;

public class FlightConfiguration : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> builder)
    {
        builder.HasData(
            new Flight { Id = 1, FlightNumber = "SEED101", AirlineName = "Northstar Air", AirlineCode = "NSA", AirPlaneModel = "A320", AirPlaneRegistration = "SEED-N101", DepartureAirport = "JFK", ArrivalAirport = "LAX", DepartureTime = new DateTime(2027, 1, 10, 8, 0, 0, DateTimeKind.Utc), ArrivalTime = new DateTime(2027, 1, 10, 11, 30, 0, DateTimeKind.Utc), FlightStatus = "Scheduled" },
            new Flight { Id = 2, FlightNumber = "SEED202", AirlineName = "Cedar Airways", AirlineCode = "CDA", AirPlaneModel = "B737", AirPlaneRegistration = "SEED-C202", DepartureAirport = "LAX", ArrivalAirport = "SFO", DepartureTime = new DateTime(2027, 1, 11, 9, 0, 0, DateTimeKind.Utc), ArrivalTime = new DateTime(2027, 1, 11, 10, 30, 0, DateTimeKind.Utc), FlightStatus = "Scheduled" },
            new Flight { Id = 3, FlightNumber = "SEED303", AirlineName = "Blue Horizon Air", AirlineCode = "BHA", AirPlaneModel = "A321", AirPlaneRegistration = "SEED-B303", DepartureAirport = "ORD", ArrivalAirport = "MIA", DepartureTime = new DateTime(2027, 1, 12, 7, 30, 0, DateTimeKind.Utc), ArrivalTime = new DateTime(2027, 1, 12, 11, 0, 0, DateTimeKind.Utc), FlightStatus = "Scheduled" },
            new Flight { Id = 4, FlightNumber = "SEED404", AirlineName = "Summit Airlines", AirlineCode = "SMA", AirPlaneModel = "B787", AirPlaneRegistration = "SEED-S404", DepartureAirport = "SEA", ArrivalAirport = "DEN", DepartureTime = new DateTime(2027, 1, 13, 6, 0, 0, DateTimeKind.Utc), ArrivalTime = new DateTime(2027, 1, 13, 9, 0, 0, DateTimeKind.Utc), FlightStatus = "Scheduled" },
            new Flight { Id = 5, FlightNumber = "SEED505", AirlineName = "Coastal Connect", AirlineCode = "CCC", AirPlaneModel = "E190", AirPlaneRegistration = "SEED-C505", DepartureAirport = "BOS", ArrivalAirport = "IAD", DepartureTime = new DateTime(2027, 1, 14, 12, 0, 0, DateTimeKind.Utc), ArrivalTime = new DateTime(2027, 1, 14, 13, 45, 0, DateTimeKind.Utc), FlightStatus = "Scheduled" });
    }
}
