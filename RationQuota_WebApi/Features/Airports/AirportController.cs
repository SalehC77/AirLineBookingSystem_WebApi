using AirLineBookingSystem_WebApi.Features.Airports.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AirLineBookingSystem_WebApi.Features.Airports;

[Route("api/[controller]/[action]")]
[ApiController]
[EnableCors("CorsPolicy_AirLineBookingSystem")]
public class AirportController : ControllerBase
{
    private readonly IAirportService _airportService;

    public AirportController(IAirportService airportService)
    {
        _airportService = airportService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AirportResponseDto>>> GetAll()
    {
        return Ok(await _airportService.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<AirportResponseDto>> GetById(int id)
    {
        var airport = await _airportService.GetByIdAsync(id);
        return airport is null ? NotFound("Airport not found.") : Ok(airport);
    }

    [HttpPost]
    public async Task<ActionResult<AirportResponseDto>> Create(AirportCreateDto dto)
    {
        var airport = await _airportService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = airport.Id }, airport);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<AirportResponseDto>> Update(int id, AirportUpdateDto dto)
    {
        var airport = await _airportService.UpdateAsync(id, dto);
        return airport is null ? NotFound("Airport not found.") : Ok(airport);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _airportService.DeleteAsync(id);
        return deleted ? Content("Airport deleted successfully.") : NotFound("Airport not found.");
    }
}
