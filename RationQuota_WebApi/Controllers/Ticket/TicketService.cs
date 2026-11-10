using AirLineBookingSystem_WebApi.Controllers.Ticket.Dtos;
using AirLineBookingSystem_WebApi.Controllers.User;
using TicketEntity = AirLineBookingSystem_WebApi.Entities.Ticket;
using AirLineBookingSystem_WebApi.Data;
using Microsoft.EntityFrameworkCore;


namespace AirLineBookingSystem_WebApi.Controllers.Ticket
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext _context;

        public TicketService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TicketResponseDto>> GetAllAsync()
        {
            return await _context.Tickets
                .AsNoTracking()
                .Select(ticket => new TicketResponseDto
                {
                    Id = ticket.Id,
                    FlightId = ticket.FlightId,
                    TicketName = ticket.TicketName,
                    TicketDescription = ticket.TicketDescription,
                    FlightClass = ticket.FlightClass,
                    TicketPrice = ticket.TicketPrice
                })
                .ToListAsync();
        }

        public async Task<TicketResponseDto?> GetByIdAsync(int id)
        {
            return await _context.Tickets
                .AsNoTracking()
                .Where(ticket => ticket.Id == id)
                .Select(ticket => new TicketResponseDto
                {
                    Id = ticket.Id,
                    FlightId = ticket.FlightId,
                    TicketName = ticket.TicketName,
                    TicketDescription = ticket.TicketDescription,
                    FlightClass = ticket.FlightClass,
                    TicketPrice = ticket.TicketPrice
                })
                .FirstOrDefaultAsync();
        }

        public async Task<TicketResponseDto> CreateAsync(
            TicketCreateDto dto)
        {
            var ticket = new TicketEntity
            {
                FlightId = dto.FlightId,
                TicketName = dto.TicketName,
                TicketDescription = dto.TicketDescription,
                FlightClass = dto.FlightClass,
                TicketPrice = dto.TicketPrice
            };

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return MapToResponseDto(ticket);
        }

        public async Task<TicketResponseDto?> UpdateAsync(
            int id, TicketUpdateDto dto)
        {
            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket is null)
            {
                return null;
            }

            ticket.FlightId = dto.FlightId;
            ticket.TicketName = dto.TicketName;
            ticket.TicketDescription = dto.TicketDescription;
            ticket.FlightClass = dto.FlightClass;
            ticket.TicketPrice = dto.TicketPrice;

            await _context.SaveChangesAsync();

            return MapToResponseDto(ticket);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket is null)
            {
                return false;
            }

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();

            return true;
        }

        private static TicketResponseDto MapToResponseDto(
            TicketEntity ticket)
        {
            return new TicketResponseDto
            {
                Id = ticket.Id,
                FlightId = ticket.FlightId,
                TicketName = ticket.TicketName,
                TicketDescription = ticket.TicketDescription,
                FlightClass = ticket.FlightClass,
                TicketPrice = ticket.TicketPrice
            };
        }
    }
}
