using AirLineBookingSystem_WebApi.Features.Users.Dtos;

namespace AirLineBookingSystem_WebApi.Features.Users
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDto>> GetAllAsync();
        Task<UserResponseDto?> GetByIdAsync(int id);
        Task<UserResponseDto> CreateAsync(UserCreateDto dto);
        Task<UserResponseDto?> UpdateAsync(int id, UserUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<UserResponseDto?> LoginAsync(UserLoginDto dto);
    }
}
