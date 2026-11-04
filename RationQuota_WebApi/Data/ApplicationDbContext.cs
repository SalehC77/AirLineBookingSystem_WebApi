using AirLineBookingSystem_WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirLineBookingSystem_WebApi.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public virtual DbSet<AppUser>  AppUsers { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<TicketBooking> TicketBookings { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);





        }
    }
}
