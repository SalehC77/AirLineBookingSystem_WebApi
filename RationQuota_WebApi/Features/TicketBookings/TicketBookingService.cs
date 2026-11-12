
using AirLineBookingSystem_WebApi.Features.TicketBookings.Dtos;
using AirLineBookingSystem_WebApi.Data;
using Microsoft.EntityFrameworkCore;
using TicketBookingEntity = AirLineBookingSystem_WebApi.Entities.TicketBooking;

namespace AirLineBookingSystem_WebApi.Features.TicketBookings;

public class TicketBookingService : ITicketBookingService
{
    private readonly ApplicationDbContext _context;

    public TicketBookingService(ApplicationDbContext context)
    {
        _context = context;
    }

    // 1. Get All Bookings
    public async Task<IEnumerable<TicketBookingResponseDto>> GetAllAsync()
    {
        return await _context.TicketBookings
            .AsNoTracking()
            .Select(booking => new TicketBookingResponseDto
            {
                Id = booking.Id,
                TicketId = booking.TicketId,
                PassengerId = booking.PassengerId,
                TicketNumber = booking.TicketNumber,
                SeatNumber = booking.SeatNumber,
                BookingDate = booking.BookingDate,
                Status = booking.Status
            })
            .ToListAsync();
    }

    // 2. Get Booking By ID
    public async Task<TicketBookingResponseDto?> GetByIdAsync(int id)
    {
        return await _context.TicketBookings
            .AsNoTracking()
            .Where(booking => booking.Id == id)
            .Select(booking => new TicketBookingResponseDto
            {
                Id = booking.Id,
                TicketId = booking.TicketId,
                PassengerId = booking.PassengerId,
                TicketNumber = booking.TicketNumber,
                SeatNumber = booking.SeatNumber,
                BookingDate = booking.BookingDate,
                Status = booking.Status
            })
            .FirstOrDefaultAsync();
    }

    // 3. Create Booking
    public async Task<TicketBookingResponseDto?> CreateAsync(
        TicketBookingCreateDto dto)
    {
        var ticket = await _context.Tickets.FindAsync(dto.TicketId);

        if (ticket is null || ticket.AvailableTickets <= 0)
        {
            return null;
        }

        var passengerExists = await _context.Passengers
            .AnyAsync(p => p.Id == dto.PassengerId);

        if (!passengerExists)
        {
            return null;
        }

        var ticketNumberExists = await _context.TicketBookings
            .AnyAsync(b => b.TicketNumber == dto.TicketNumber);

        if (ticketNumberExists)
        {
            return null;
        }

        var seatTaken = await IsSeatTakenAsync(
            ticket.FlightId, dto.SeatNumber, null);

        if (seatTaken)
        {
            return null;
        }

        var booking = new TicketBookingEntity
        {
            TicketId = dto.TicketId,
            PassengerId = dto.PassengerId,
            TicketNumber = dto.TicketNumber,
            SeatNumber = dto.SeatNumber,
            BookingDate = DateTime.UtcNow,
            Status = "محجوز"
        };

        ticket.AvailableTickets--;

        _context.TicketBookings.Add(booking);

        await _context.SaveChangesAsync();

        return MapToResponseDto(booking);
    }

    // 4. Update Booking
    public async Task<TicketBookingResponseDto?> UpdateAsync(
        int id, TicketBookingUpdateDto dto)
    {
        var booking = await _context.TicketBookings.FindAsync(id);

        if (booking is null || booking.Status is not ("محجوز" or "Booked"))
        {
            return null;
        }

        var newTicket = await _context.Tickets.FindAsync(dto.TicketId);

        if (newTicket is null)
        {
            return null;
        }

        var passengerExists = await _context.Passengers
            .AnyAsync(p => p.Id == dto.PassengerId);

        if (!passengerExists)
        {
            return null;
        }

        var isChangingTicket = booking.TicketId != dto.TicketId;

        if (isChangingTicket && newTicket.AvailableTickets <= 0)
        {
            return null;
        }

        var ticketNumberExists = await _context.TicketBookings
            .AnyAsync(b => b.TicketNumber == dto.TicketNumber
                        && b.Id != id);

        if (ticketNumberExists)
        {
            return null;
        }

        var seatTaken = await IsSeatTakenAsync(
            newTicket.FlightId, dto.SeatNumber, id);

        if (seatTaken)
        {
            return null;
        }

        if (isChangingTicket)
        {
            var oldTicket = await _context.Tickets
                .FindAsync(booking.TicketId);

            if (oldTicket is not null)
            {
                oldTicket.AvailableTickets++;
            }

            newTicket.AvailableTickets--;
        }

        booking.TicketId = dto.TicketId;
        booking.PassengerId = dto.PassengerId;
        booking.TicketNumber = dto.TicketNumber;
        booking.SeatNumber = dto.SeatNumber;

        await _context.SaveChangesAsync();

        return MapToResponseDto(booking);
    }

    // 5. Delete (Cancel) Booking
    public async Task<bool> DeleteAsync(int id)
    {
        var booking = await _context.TicketBookings.FindAsync(id);

        if (booking is null || booking.Status is "ملغي" or "Cancelled")
        {
            return false;
        }

        booking.Status = "ملغي";

        var ticket = await _context.Tickets.FindAsync(booking.TicketId);

        if (ticket is not null)
        {
            ticket.AvailableTickets++;
        }

        await _context.SaveChangesAsync();

        return true;
    }

    // Check if seat is already booked on the same flight
    private async Task<bool> IsSeatTakenAsync(
        int flightId, string seatNumber, int? exceptBookingId)
    {
        return await (
            from booking in _context.TicketBookings
            join ticket in _context.Tickets
                on booking.TicketId equals ticket.Id
            where ticket.FlightId == flightId
                  && booking.SeatNumber == seatNumber
                  && booking.Status == "Booked"
                  && (exceptBookingId == null ||
                      booking.Id != exceptBookingId.Value)
            select booking.Id
        ).AnyAsync();
    }

    // Convert Entity to Response DTO
    private static TicketBookingResponseDto MapToResponseDto(
        TicketBookingEntity booking)
    {
        return new TicketBookingResponseDto
        {
            Id = booking.Id,
            TicketId = booking.TicketId,
            PassengerId = booking.PassengerId,
            TicketNumber = booking.TicketNumber,
            SeatNumber = booking.SeatNumber,
            BookingDate = booking.BookingDate,
            Status = booking.Status
        };
    }
}
