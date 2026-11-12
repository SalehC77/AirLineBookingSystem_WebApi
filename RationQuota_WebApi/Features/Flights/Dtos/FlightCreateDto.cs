using System.ComponentModel.DataAnnotations;
using AirLineBookingSystem_WebApi.Helpers.Enums;

namespace AirLineBookingSystem_WebApi.Features.Flights.Dtos;

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

    [Range(1, int.MaxValue)]
    public int DepartureAirportId { get; set; }

    [Range(1, int.MaxValue)]
    public int ArrivalAirportId { get; set; }

    public DateTime DepartureDate { get; set; }
    public string? DepartureDay { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime LandingTime { get; set; }
    public FlightStatus FlightStatus { get; set; } = FlightStatus.Scheduled;
}
