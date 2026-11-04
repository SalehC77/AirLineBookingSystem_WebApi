using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Ticket
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    public string TicketNumber { get; set; }

    // Seat Information
    [Required]
    public string SeatNumber { get; set; }

    // Travel Information
    [Required]
    public string FlightClass { get; set; } // Economy, Business, First Class

    public DateTime BookingDate { get; set; } = DateTime.UtcNow;

    [Column(TypeName = "decimal(18,2)")]
    public decimal TicketPrice { get; set; }

    public string TicketStatus { get; set; } = "Booked";

    // Check-in Information
    public DateTime? CheckInTime { get; set; }

    public DateTime? BoardingTime { get; set; }

    public string? GateNumber { get; set; }

    // Navigation Properties
    public int PassengerId { get; set; }

    [ForeignKey(nameof(PassengerId))]
    public Passenger? Passenger { get; set; }

    public int FlightId { get; set; }

    [ForeignKey(nameof(FlightId))]
    public Flight? Flight { get; set; }
}