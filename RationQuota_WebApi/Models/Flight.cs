using AirLineBookingSystem_WebApi.Models;
using System.ComponentModel.DataAnnotations;

public class Flight
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(20)]
    public string FlightNumber { get; set; }

    // Airline Information
    [Required]
    public string AirlineName { get; set; }

    public string? AirlineCode { get; set; }

    // Aircraft Information
    public string? AirPlaneModel { get; set; }

    public string? AirPlaneRegistration { get; set; }

    // Airport Information
    [Required]
    public string DepartureAirport { get; set; }

    [Required]
    public string ArrivalAirport { get; set; }

    // Flight Schedule
    public DateTime DepartureTime { get; set; }

    public DateTime ArrivalTime { get; set; }

    public string FlightStatus { get; set; } = "Scheduled";

    // Available Seats
    public int EconomySeatsAvailable { get; set; }

    public int BusinessSeatsAvailable { get; set; }

    // Navigation Property
    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}