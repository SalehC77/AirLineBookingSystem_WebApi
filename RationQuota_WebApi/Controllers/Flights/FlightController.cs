using AirLineBookingSystem_WebApi.Controllers.Flights.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AirLineBookingSystem_WebApi.Controllers.Flights;

[Route("api/[controller]/[action]")]
[ApiController]
[EnableCors("CorsPolicy_AirLineBookingSystem")]
public class FlightController : ControllerBase
{
    private readonly IFlightService _flightService;

    public FlightController(IFlightService flightService)
    {
        _flightService = flightService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FlightResponseDto>>> GetAll()
    {
        return Ok(await _flightService.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<FlightResponseDto>> GetById(int id)
    {
        var flight = await _flightService.GetByIdAsync(id);
        return flight is null ? NotFound("Flight not found.") : Ok(flight);
    }

    [HttpPost]
    public async Task<ActionResult<FlightResponseDto>> Create(FlightCreateDto dto)
    {
        var flight = await _flightService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = flight.Id }, flight);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<FlightResponseDto>> Update(int id, FlightUpdateDto dto)
    {
        var flight = await _flightService.UpdateAsync(id, dto);
        return flight is null ? NotFound("Flight not found.") : Ok(flight);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _flightService.DeleteAsync(id);
        return deleted ? Content("Flight deleted successfully.") : NotFound("Flight not found.");
    }
}
