using AirLineBookingSystem_WebApi.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AirLineBookingSystem_WebApi.Entities
{
    public class TicketBooking
    {
        [Key]
        public int Id { get; set; }
        public Ticket? Ticket { get; set; }
        public int TicketId { get; set; }

        [Required]
        [MaxLength(30)]
        public string TicketNumber { get; set; }

        // Seat Information
        [Required]
        public string SeatNumber { get; set; }

        // Travel Information
        [Required]


        public DateTime BookingDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "decimal(18,2)")]


        public string TicketStatus { get; set; } = "Booked";

        // Check-in Information
        public DateTime? CheckInTime { get; set; }

        public DateTime? BoardingTime { get; set; }

        public string? GateNumber { get; set; }

        // Navigation Properties
        public int PassengerId { get; set; }

        [ForeignKey(nameof(PassengerId))]
        public Passenger? Passenger { get; set; }


    }
}

