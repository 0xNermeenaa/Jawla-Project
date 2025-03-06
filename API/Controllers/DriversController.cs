using Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using Repository.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;

        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DriverDTO>>> GetAllDrivers()
        {
            var drivers = await _driverService.GetAllDriversAsync();
            return Ok(drivers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DriverDTO>> GetDriverById(int id)
        {
            var driver = await _driverService.GetDriverByIdAsync(id);
            if (driver == null) return NotFound();
            return Ok(driver);
        }

        [HttpGet("ByCar/{carId}")]
        public async Task<ActionResult<List<DriverDTO>>> GetDriversByCarId(int carId)
        {
            var drivers = await _driverService.GetDriversByCarIdAsync(carId);
            return Ok(drivers);
        }

        [HttpPost]
        public async Task<ActionResult<DriverDTO>> AddDriver([FromBody] DriverDTO driverDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var newDriver = await _driverService.AddDriverAsync(driverDTO);
            return CreatedAtAction(nameof(GetDriverById), new { id = newDriver.Id }, newDriver);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDriver(int id, [FromBody] DriverDTO driverDTO)
        {
            if (id != driverDTO.Id) return BadRequest("ID mismatch");

            var updated = await _driverService.UpdateDriverAsync(driverDTO);
            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            var deleted = await _driverService.DeleteDriverAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
