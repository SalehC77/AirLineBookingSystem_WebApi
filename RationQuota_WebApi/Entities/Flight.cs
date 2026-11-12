
using AirLineBookingSystem_WebApi.Helpers.Enums;
using System.ComponentModel.DataAnnotations;
namespace AirLineBookingSystem_WebApi.Entities
{
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
        public int DepartureAirportId { get; set; }
        public virtual Airport? DepartureAirport { get; set; }

        [Required]
        public int ArrivalAirportId { get; set; }
        public virtual Airport? ArrivalAirport { get; set; }
        

        // Flight Schedule
        public DateTime DepartureDate { get; set; }
        public string? DepartureDay { get; set; } 
        public DateTime DepartureTime { get; set; }
        public DateTime LandingTime { get; set; }

        public FlightStatus FlightStatus { get; set; } = FlightStatus.Scheduled;

        // Available Seats
        //public int EconomySeatsAvailable { get; set; }

        //public int BusinessSeatsAvailable { get; set; }

        // Navigation Property
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}

