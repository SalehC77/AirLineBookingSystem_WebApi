using AirLineBookingSystem_WebApi.Features.Flights.Dtos;
using AirLineBookingSystem_WebApi.Features.Airports.Dtos;
using AirLineBookingSystem_WebApi.Features.Tickets.Dtos;
using AirLineBookingSystem_WebApi.Data;
using AirLineBookingSystem_WebApi.Helpers.Enums;
using Microsoft.EntityFrameworkCore;
using FlightEntity = AirLineBookingSystem_WebApi.Entities.Flight;


namespace AirLineBookingSystem_WebApi.Features.Flights;

public class FlightService : IFlightService
{
    private readonly ApplicationDbContext _context;

    public FlightService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<FlightResponseDto>> GetAllAsync(
        int? departureAirportId,
        int? arrivalAirportId,
        FlightStatus? flightStatus,
        DateTime? departureDate)
    {
        var query = _context.Flights.AsNoTracking();

        if (departureAirportId.HasValue)
        {
            query = query.Where(flight => flight.DepartureAirportId == departureAirportId.Value);
        }

        if (arrivalAirportId.HasValue)
        {
            query = query.Where(flight => flight.ArrivalAirportId == arrivalAirportId.Value);
        }

        if (flightStatus.HasValue)
        {
            query = query.Where(flight => flight.FlightStatus == flightStatus.Value);
        }

        if (departureDate.HasValue)
        {
            var startDate = departureDate.Value.Date;
            var endDate = startDate.AddDays(1);
            query = query.Where(flight =>
                flight.DepartureDate >= startDate && flight.DepartureDate < endDate);
        }

        return await query
            .Select(flight => new FlightResponseDto
            {
                Id = flight.Id,
                FlightNumber = flight.FlightNumber,
                AirlineName = flight.AirlineName,
                AirlineCode = flight.AirlineCode,
                AirPlaneModel = flight.AirPlaneModel,
                AirPlaneRegistration = flight.AirPlaneRegistration,
                DepartureAirport = new AirportResponseDto
                {
                    Id = flight.DepartureAirport!.Id,
                    Name = flight.DepartureAirport.Name,
                    Code = flight.DepartureAirport.Code,
                    City = flight.DepartureAirport.City,
                    Country = flight.DepartureAirport.Country
                },
                ArrivalAirport = new AirportResponseDto
                {
                    Id = flight.ArrivalAirport!.Id,
                    Name = flight.ArrivalAirport.Name,
                    Code = flight.ArrivalAirport.Code,
                    City = flight.ArrivalAirport.City,
                    Country = flight.ArrivalAirport.Country
                },
                DepartureDate = flight.DepartureDate,
                DepartureDay = flight.DepartureDay,
                DepartureTime = flight.DepartureTime,
                LandingTime = flight.LandingTime,
                FlightStatus = flight.FlightStatus
            })
            .ToListAsync();
    }

    public async Task<FlightResponseDto?> GetByIdAsync(int id)
    {
        var flight = await _context.Flights
            .AsNoTracking()
            .Where(flight => flight.Id == id)
            .Select(flight => new FlightResponseDto
            {
                Id = flight.Id,
                FlightNumber = flight.FlightNumber,
                AirlineName = flight.AirlineName,
                AirlineCode = flight.AirlineCode,
                AirPlaneModel = flight.AirPlaneModel,
                AirPlaneRegistration = flight.AirPlaneRegistration,
                DepartureAirport = new AirportResponseDto
                {
                    Id = flight.DepartureAirport!.Id,
                    Name = flight.DepartureAirport.Name,
                    Code = flight.DepartureAirport.Code,
                    City = flight.DepartureAirport.City,
                    Country = flight.DepartureAirport.Country
                },
                ArrivalAirport = new AirportResponseDto
                {
                    Id = flight.ArrivalAirport!.Id,
                    Name = flight.ArrivalAirport.Name,
                    Code = flight.ArrivalAirport.Code,
                    City = flight.ArrivalAirport.City,
                    Country = flight.ArrivalAirport.Country
                },
                DepartureDate = flight.DepartureDate,
                DepartureDay = flight.DepartureDay,
                DepartureTime = flight.DepartureTime,
                LandingTime = flight.LandingTime,
                FlightStatus = flight.FlightStatus
            })
            .FirstOrDefaultAsync();

        if (flight is null)
        {
            return null;
        }

        flight.Tickets = await _context.Tickets
            .AsNoTracking()
            .Where(ticket => ticket.FlightId == id)
            .Select(ticket => new TicketResponseDto
            {
                Id = ticket.Id,
                FlightId = ticket.FlightId,
                TicketName = ticket.TicketName,
                TicketDescription = ticket.TicketDescription,
                FlightClass = ticket.FlightClass,
                TicketPrice = ticket.TicketPrice,
                AvailableTickets = ticket.AvailableTickets,
                CheckInTime = ticket.CheckInTime,
                BoardingTime = ticket.BoardingTime,
                GateNumber = ticket.GateNumber
            })
            .ToListAsync();

        return flight;
    }

    public async Task<FlightResponseDto?> CreateAsync(FlightCreateDto dto)
    {
        if (!await AirportIdsExistAsync(dto))
        {
            return null;
        }

        var flight = new FlightEntity();
        ApplyDto(flight, dto);

        _context.Flights.Add(flight);
        await _context.SaveChangesAsync();

        return await GetByIdAsync(flight.Id);
    }

    public async Task<FlightResponseDto?> UpdateAsync(int id, FlightUpdateDto dto)
    {
        var flight = await _context.Flights.FindAsync(id);
        if (flight is null)
        {
            return null;
        }

        if (!await AirportIdsExistAsync(dto))
        {
            return null;
        }

        ApplyDto(flight, dto);
        await _context.SaveChangesAsync();

        return await GetByIdAsync(flight.Id);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var flight = await _context.Flights.FindAsync(id);
        if (flight is null)
        {
            return false;
        }

        _context.Flights.Remove(flight);
        await _context.SaveChangesAsync();
        return true;
    }

    private async Task<bool> AirportIdsExistAsync(FlightCreateDto dto)
    {
        return await _context.Airports.AnyAsync(airport => airport.Id == dto.DepartureAirportId)
            && await _context.Airports.AnyAsync(airport => airport.Id == dto.ArrivalAirportId);
    }

    private static void ApplyDto(FlightEntity flight, FlightCreateDto dto)
    {
        flight.FlightNumber = dto.FlightNumber;
        flight.AirlineName = dto.AirlineName;
        flight.AirlineCode = dto.AirlineCode;
        flight.AirPlaneModel = dto.AirPlaneModel;
        flight.AirPlaneRegistration = dto.AirPlaneRegistration;
        flight.DepartureAirportId = dto.DepartureAirportId;
        flight.ArrivalAirportId = dto.ArrivalAirportId;
        flight.DepartureDate = dto.DepartureDate;
        flight.DepartureDay = dto.DepartureDay;
        flight.DepartureTime = dto.DepartureTime;
        flight.LandingTime = dto.LandingTime;
        flight.FlightStatus = dto.FlightStatus;
    }

}
