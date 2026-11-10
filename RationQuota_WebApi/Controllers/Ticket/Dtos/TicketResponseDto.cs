namespace AirLineBookingSystem_WebApi.Controllers.Ticket.Dtos
{
    public class TicketResponseDto
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string TicketName { get; set; } = string.Empty;
        public string? TicketDescription { get; set; }
        public string FlightClass { get; set; } = string.Empty;
        public decimal TicketPrice { get; set; }
    }
}
