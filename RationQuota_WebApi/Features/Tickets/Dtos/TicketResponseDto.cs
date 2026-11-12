namespace AirLineBookingSystem_WebApi.Features.Tickets.Dtos
{
    public class TicketResponseDto
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string TicketName { get; set; } = string.Empty;
        public string? TicketDescription { get; set; }
        public string FlightClass { get; set; } = string.Empty;
        public decimal TicketPrice { get; set; }
        public int AvailableTickets { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? BoardingTime { get; set; }
        public string? GateNumber { get; set; }
    }
}
