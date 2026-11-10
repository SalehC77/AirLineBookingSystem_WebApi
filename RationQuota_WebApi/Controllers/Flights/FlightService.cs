using AirLineBookingSystem_WebApi.Controllers.Flights.Dtos;
using AirLineBookingSystem_WebApi.Data;
using AirLineBookingSystem_WebApi.Entities;
using Microsoft.EntityFrameworkCore;


namespace AirLineBookingSystem_WebApi.Controllers.Flights;

public class FlightService : IFlightService
{
    private readonly ApplicationDbContext _context;

    public FlightService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<FlightResponseDto>> GetAllAsync()
    {
        return await _context.Flights
            .AsNoTracking()
            .Select(flight => new FlightResponseDto
            {
                Id = flight.Id,
                FlightNumber = flight.FlightNumber,
                AirlineName = flight.AirlineName,
                AirlineCode = flight.AirlineCode,
                AirPlaneModel = flight.AirPlaneModel,
                AirPlaneRegistration = flight.AirPlaneRegistration,
                DepartureAirport = flight.DepartureAirport,
                ArrivalAirport = flight.ArrivalAirport,
                DepartureTime = flight.DepartureTime,
                ArrivalTime = flight.ArrivalTime,
                FlightStatus = flight.FlightStatus
            })
            .ToListAsync();
    }

    public async Task<FlightResponseDto?> GetByIdAsync(int id)
    {
        return await _context.Flights
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
                DepartureAirport = flight.DepartureAirport,
                ArrivalAirport = flight.ArrivalAirport,
                DepartureTime = flight.DepartureTime,
                ArrivalTime = flight.ArrivalTime,
                FlightStatus = flight.FlightStatus
            })
            .FirstOrDefaultAsync();
    }

    public async Task<FlightResponseDto> CreateAsync(FlightCreateDto dto)
    {
        var flight = new Flight();
        ApplyDto(flight, dto);

        _context.Flights.Add(flight);
        await _context.SaveChangesAsync();

        return MapToResponseDto(flight);
    }

    public async Task<FlightResponseDto?> UpdateAsync(int id, FlightUpdateDto dto)
    {
        var flight = await _context.Flights.FindAsync(id);
        if (flight is null)
        {
            return null;
        }

        ApplyDto(flight, dto);
        await _context.SaveChangesAsync();

        return MapToResponseDto(flight);
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

    private static void ApplyDto(Flight flight, FlightCreateDto dto)
    {
        flight.FlightNumber = dto.FlightNumber;
        flight.AirlineName = dto.AirlineName;
        flight.AirlineCode = dto.AirlineCode;
        flight.AirPlaneModel = dto.AirPlaneModel;
        flight.AirPlaneRegistration = dto.AirPlaneRegistration;
        flight.DepartureAirport = dto.DepartureAirport;
        flight.ArrivalAirport = dto.ArrivalAirport;
        flight.DepartureTime = dto.DepartureTime;
        flight.ArrivalTime = dto.ArrivalTime;
        flight.FlightStatus = string.IsNullOrWhiteSpace(dto.FlightStatus)
            ? "Scheduled"
            : dto.FlightStatus;
    }

    private static FlightResponseDto MapToResponseDto(Flight flight)
    {
        return new FlightResponseDto
        {
            Id = flight.Id,
            FlightNumber = flight.FlightNumber,
            AirlineName = flight.AirlineName,
            AirlineCode = flight.AirlineCode,
            AirPlaneModel = flight.AirPlaneModel,
            AirPlaneRegistration = flight.AirPlaneRegistration,
            DepartureAirport = flight.DepartureAirport,
            ArrivalAirport = flight.ArrivalAirport,
            DepartureTime = flight.DepartureTime,
            ArrivalTime = flight.ArrivalTime,
            FlightStatus = flight.FlightStatus
        };
    }
}
