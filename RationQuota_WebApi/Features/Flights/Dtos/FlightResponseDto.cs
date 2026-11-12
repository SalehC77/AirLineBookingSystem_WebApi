using AirLineBookingSystem_WebApi.Helpers.Enums;

namespace AirLineBookingSystem_WebApi.Features.Flights.Dtos;

public class FlightResponseDto
{
    public int Id { get; set; }
    public string FlightNumber { get; set; } = string.Empty;
    public string AirlineName { get; set; } = string.Empty;
    public string? AirlineCode { get; set; }
    public string? AirPlaneModel { get; set; }
    public string? AirPlaneRegistration { get; set; }
    public int DepartureAirportId { get; set; }
    public int ArrivalAirportId { get; set; }
    public DateTime DepartureDate { get; set; }
    public string? DepartureDay { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime LandingTime { get; set; }
    public FlightStatus FlightStatus { get; set; }
}
