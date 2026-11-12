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

        public string Status { get; set; } = "محجوز";

        // Navigation Properties
        public int PassengerId { get; set; }

        [ForeignKey(nameof(PassengerId))]
        public Passenger? Passenger { get; set; }


    }
}

