using AirLineBookingSystem_WebApi.Controllers.User.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AirLineBookingSystem_WebApi.Controllers.User
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("CorsPolicy_AirLineBookingSystem")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<UserResponseDto>> Login(UserLoginDto dto)
        {
            var user = await _userService.LoginAsync(dto);
            return user is null ? Unauthorized("Invalid email or password.") : Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetAll()
        {
            return Ok(await _userService.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserResponseDto>> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            return user is null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserResponseDto>> Create(UserCreateDto dto)
        {
            var user = await _userService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<UserResponseDto>> Update(int id, UserUpdateDto dto)
        {
            var user = await _userService.UpdateAsync(id, dto);
            return user is null ? NotFound() : Ok(user);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _userService.DeleteAsync(id);
            return deleted ? Content("User deleted successfully.") : NotFound();
        }
    }
}
