using System.ComponentModel.DataAnnotations.Schema;

namespace AirLineBookingSystem_WebApi.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public int FlightId { get; set; }

        [ForeignKey(nameof(FlightId))]
        public Flight? Flight { get; set; }
        public string TicketName { get; set; }
        public int AvailableCounts { get; set; }
        public string? TicketDescription { get; set; }
        public string FlightClass { get; set; } // Economy, Business, First Class
        public decimal TicketPrice { get; set; }
    }
}
