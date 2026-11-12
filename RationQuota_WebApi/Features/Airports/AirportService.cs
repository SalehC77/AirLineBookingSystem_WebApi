using AirLineBookingSystem_WebApi.Features.Airports.Dtos;
using AirLineBookingSystem_WebApi.Data;
using Microsoft.EntityFrameworkCore;
using AirportEntity = AirLineBookingSystem_WebApi.Entities.Airport;

namespace AirLineBookingSystem_WebApi.Features.Airports;

public class AirportService : IAirportService
{
    private readonly ApplicationDbContext _context;

    public AirportService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AirportResponseDto>> GetAllAsync()
    {
        return await _context.Airports
            .AsNoTracking()
            .Select(airport => new AirportResponseDto
            {
                Id = airport.Id,
                Name = airport.Name,
                Code = airport.Code,
                City = airport.City,
                Country = airport.Country
            })
            .ToListAsync();
    }

    public async Task<AirportResponseDto?> GetByIdAsync(int id)
    {
        return await _context.Airports
            .AsNoTracking()
            .Where(airport => airport.Id == id)
            .Select(airport => new AirportResponseDto
            {
                Id = airport.Id,
                Name = airport.Name,
                Code = airport.Code,
                City = airport.City,
                Country = airport.Country
            })
            .FirstOrDefaultAsync();
    }

    public async Task<AirportResponseDto> CreateAsync(AirportCreateDto dto)
    {
        var airport = new AirportEntity
        {
            Name = dto.Name,
            Code = dto.Code,
            City = dto.City,
            Country = dto.Country
        };

        _context.Airports.Add(airport);
        await _context.SaveChangesAsync();

        return MapToResponseDto(airport);
    }

    public async Task<AirportResponseDto?> UpdateAsync(int id, AirportUpdateDto dto)
    {
        var airport = await _context.Airports.FindAsync(id);
        if (airport is null)
        {
            return null;
        }

        airport.Name = dto.Name;
        airport.Code = dto.Code;
        airport.City = dto.City;
        airport.Country = dto.Country;

        await _context.SaveChangesAsync();
        return MapToResponseDto(airport);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var airport = await _context.Airports.FindAsync(id);
        if (airport is null)
        {
            return false;
        }

        _context.Airports.Remove(airport);
        await _context.SaveChangesAsync();
        return true;
    }

    private static AirportResponseDto MapToResponseDto(AirportEntity airport)
    {
        return new AirportResponseDto
        {
            Id = airport.Id,
            Name = airport.Name,
            Code = airport.Code,
            City = airport.City,
            Country = airport.Country
        };
    }
}
