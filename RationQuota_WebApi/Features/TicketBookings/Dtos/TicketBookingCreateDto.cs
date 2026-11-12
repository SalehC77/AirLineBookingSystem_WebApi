using System.ComponentModel.DataAnnotations;

namespace AirLineBookingSystem_WebApi.Features.TicketBookings.Dtos
{
    public class TicketBookingCreateDto
    {
        [Range(1, int.MaxValue)]
        public int TicketId { get; set; }

        [Range(1, int.MaxValue)]
        public int PassengerId { get; set; }

        [Required]
        [MaxLength(30)]
        public string TicketNumber { get; set; } = string.Empty;

        [Required]
        public string SeatNumber { get; set; } = string.Empty;
    }
}
