using System.ComponentModel.DataAnnotations;

namespace AirLineBookingSystem_WebApi.Controllers.Ticket.Dtos
{
    public class TicketCreateDto
    {
        [Required]
        public int FlightId { get; set; }

        [Required]
        public string TicketName { get; set; } = string.Empty;

        public string? TicketDescription { get; set; }

        [Required]
        public string FlightClass { get; set; } = string.Empty;

        [Required]
        public decimal TicketPrice { get; set; }

        [Range(0, int.MaxValue)]
        public int AvailableTickets { get; set; }

        public DateTime? CheckInTime { get; set; }

        public DateTime? BoardingTime { get; set; }

        public string? GateNumber { get; set; }
    }
}
