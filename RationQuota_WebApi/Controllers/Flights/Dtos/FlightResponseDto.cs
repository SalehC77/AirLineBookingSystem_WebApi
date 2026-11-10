namespace AirLineBookingSystem_WebApi.Controllers.Flights.Dtos;

public class FlightResponseDto
{
    public int Id { get; set; }
    public string FlightNumber { get; set; } = string.Empty;
    public string AirlineName { get; set; } = string.Empty;
    public string? AirlineCode { get; set; }
    public string? AirPlaneModel { get; set; }
    public string? AirPlaneRegistration { get; set; }
    public string DepartureAirport { get; set; } = string.Empty;
    public string ArrivalAirport { get; set; } = string.Empty;
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public string FlightStatus { get; set; } = string.Empty;
}
