
using AirLineBookingSystem_WebApi.Controllers.Passenger.Dtos;
using AirLineBookingSystem_WebApi.Data;
using Microsoft.EntityFrameworkCore;
using PassengerEntity = AirLineBookingSystem_WebApi.Entities.Passenger;

namespace AirLineBookingSystem_WebApi.Controllers.Passenger;

public class PassengerService : IPassengerService
{
    private readonly ApplicationDbContext _context;

    public PassengerService(ApplicationDbContext context)
    {
        _context = context;
    }

    // 1. Get All Passengers
    public async Task<IEnumerable<PassengerResponseDto>> GetAllAsync()
    {
        return await _context.Passengers
            .AsNoTracking()
            .Select(passenger => new PassengerResponseDto
            {
                Id = passenger.Id,
                FirstName = passenger.FirstName,
                LastName = passenger.LastName,
                DateOfBirth = passenger.DateOfBirth,
                Gender = passenger.Gender,
                Nationality = passenger.Nationality,
                PassportNumber = passenger.PassportNumber,
                PhoneNumber = passenger.PhoneNumber,
                UserId = passenger.UserId
            })
            .ToListAsync();
    }

    // 2. Get Passenger By ID
    public async Task<PassengerResponseDto?> GetByIdAsync(int id)
    {
        return await _context.Passengers
            .AsNoTracking()
            .Where(passenger => passenger.Id == id)
            .Select(passenger => new PassengerResponseDto
            {
                Id = passenger.Id,
                FirstName = passenger.FirstName,
                LastName = passenger.LastName,
                DateOfBirth = passenger.DateOfBirth,
                Gender = passenger.Gender,
                Nationality = passenger.Nationality,
                PassportNumber = passenger.PassportNumber,
                PhoneNumber = passenger.PhoneNumber,
                UserId = passenger.UserId
            })
            .FirstOrDefaultAsync();
    }

    // 3. Create Passenger
    public async Task<PassengerResponseDto?> CreateAsync(
        PassengerCreateDto dto)
    {
        var userExists = await _context.AppUsers
            .AnyAsync(user => user.Id == dto.UserId);

        if (!userExists)
        {
            return null;
        }

        var passenger = new PassengerEntity
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            DateOfBirth = dto.DateOfBirth,
            Gender = dto.Gender,
            Nationality = dto.Nationality,
            PassportNumber = dto.PassportNumber,
            PhoneNumber = dto.PhoneNumber,
            UserId = dto.UserId
        };

        _context.Passengers.Add(passenger);

        await _context.SaveChangesAsync();

        return MapToResponseDto(passenger);
    }

    // 4. Update Passenger
    public async Task<PassengerResponseDto?> UpdateAsync(
        int id, PassengerUpdateDto dto)
    {
        var passenger = await _context.Passengers.FindAsync(id);

        if (passenger is null)
        {
            return null;
        }

        var userExists = await _context.AppUsers
            .AnyAsync(user => user.Id == dto.UserId);

        if (!userExists)
        {
            return null;
        }

        passenger.FirstName = dto.FirstName;
        passenger.LastName = dto.LastName;
        passenger.DateOfBirth = dto.DateOfBirth;
        passenger.Gender = dto.Gender;
        passenger.Nationality = dto.Nationality;
        passenger.PassportNumber = dto.PassportNumber;
        passenger.PhoneNumber = dto.PhoneNumber;
        passenger.UserId = dto.UserId;

        await _context.SaveChangesAsync();

        return MapToResponseDto(passenger);
    }

    // 5. Delete Passenger
    public async Task<bool> DeleteAsync(int id)
    {
        var passenger = await _context.Passengers.FindAsync(id);

        if (passenger is null)
        {
            return false;
        }

        _context.Passengers.Remove(passenger);

        await _context.SaveChangesAsync();

        return true;
    }

    // Convert Entity to Response DTO
    private static PassengerResponseDto MapToResponseDto(
        PassengerEntity passenger)
    {
        return new PassengerResponseDto
        {
            Id = passenger.Id,
            FirstName = passenger.FirstName,
            LastName = passenger.LastName,
            DateOfBirth = passenger.DateOfBirth,
            Gender = passenger.Gender,
            Nationality = passenger.Nationality,
            PassportNumber = passenger.PassportNumber,
            PhoneNumber = passenger.PhoneNumber,
            UserId = passenger.UserId
        };
    }
}
