namespace AirLineBookingSystem_WebApi.Features.TicketBookings.Dtos
{
    public class TicketBookingResponseDto
    {
        public int Id { get; set; }

        public int TicketId { get; set; }

        public int PassengerId { get; set; }

        public string TicketNumber { get; set; } = string.Empty;

        public string SeatNumber { get; set; } = string.Empty;

        public DateTime BookingDate { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}
