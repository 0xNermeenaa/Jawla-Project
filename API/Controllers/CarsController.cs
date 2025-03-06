using Infrastructure.DTO;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepositories;
using Repository.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CarDTO>>> GetAllCars()
        {
            var cars = await _carService.GetAllCarsAsync();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarDTO>> GetCarById(int id)
        {
            var car = await _carService.GetCarByIdAsync(id);
            if (car == null) return NotFound();
            return Ok(car);
        }

        [HttpGet("available")]
        public async Task<ActionResult<List<CarDTO>>> GetAvailableCars()
        {
            var cars = await _carService.GetAvailableCarsAsync();
            return Ok(cars);
        }

        [HttpPost]
        public async Task<ActionResult<CarDTO>> AddCar([FromBody] CarDTO carDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var newCar = await _carService.AddCarAsync(carDTO);
            return CreatedAtAction(nameof(GetCarById), new { id = newCar.Id }, newCar);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, [FromBody] CarDTO carDTO)
        {
            if (id != carDTO.Id) return BadRequest("ID mismatch");

            var updated = await _carService.UpdateCarAsync(carDTO);
            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var deleted = await _carService.DeleteCarAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
