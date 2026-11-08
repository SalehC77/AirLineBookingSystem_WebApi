using AirLineBookingSystem_WebApi.Controllers.User.Dtos;
using AirLineBookingSystem_WebApi.Data;
using AirLineBookingSystem_WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirLineBookingSystem_WebApi.Controllers.User
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserResponseDto>> GetAllAsync()
        {
            return await _context.AppUsers
                .AsNoTracking()
                .Select(user => new UserResponseDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    Role = user.Role,
                    CreatedAt = user.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<UserResponseDto?> GetByIdAsync(int id)
        {
            return await _context.AppUsers
                .AsNoTracking()
                .Where(user => user.Id == id)
                .Select(user => new UserResponseDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    Role = user.Role,
                    CreatedAt = user.CreatedAt
                })
                .FirstOrDefaultAsync();
        }

        public async Task<UserResponseDto> CreateAsync(UserCreateDto dto)
        {
            var user = new AppUser
            {
                Username = dto.Username,
                Email = dto.Email,
                Password = dto.Password,
                Role = string.IsNullOrWhiteSpace(dto.Role) ? "Passenger" : dto.Role
            };

            _context.AppUsers.Add(user);
            await _context.SaveChangesAsync();

            return MapToResponseDto(user);
        }

        public async Task<UserResponseDto?> UpdateAsync(int id, UserUpdateDto dto)
        {
            var user = await _context.AppUsers.FindAsync(id);
            if (user is null)
            {
                return null;
            }

            user.Username = dto.Username;
            user.Email = dto.Email;
            user.Password = dto.Password;
            user.Role = string.IsNullOrWhiteSpace(dto.Role) ? "Passenger" : dto.Role;

            await _context.SaveChangesAsync();
            return MapToResponseDto(user);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.AppUsers.FindAsync(id);
            if (user is null)
            {
                return false;
            }

            _context.AppUsers.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UserResponseDto?> LoginAsync(UserLoginDto dto)
        {
            var user = await _context.AppUsers
                .AsNoTracking()
                .FirstOrDefaultAsync(user =>
                    user.Email == dto.Email && user.Password == dto.Password);

            return user is null ? null : MapToResponseDto(user);
        }

        private static UserResponseDto MapToResponseDto(AppUser user)
        {
            return new UserResponseDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role,
                CreatedAt = user.CreatedAt
            };
        }
    }
}
