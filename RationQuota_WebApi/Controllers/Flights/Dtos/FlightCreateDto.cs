using System.ComponentModel.DataAnnotations;

namespace AirLineBookingSystem_WebApi.Controllers.Flights.Dtos;

public class FlightCreateDto
{
    [Required]
    [MaxLength(20)]
    public string FlightNumber { get; set; } = string.Empty;

    [Required]
    public string AirlineName { get; set; } = string.Empty;

    public string? AirlineCode { get; set; }
    public string? AirPlaneModel { get; set; }
    public string? AirPlaneRegistration { get; set; }

    [Required]
    public string DepartureAirport { get; set; } = string.Empty;

    [Required]
    public string ArrivalAirport { get; set; } = string.Empty;

    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public string FlightStatus { get; set; } = "Scheduled";
}
