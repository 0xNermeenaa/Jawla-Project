using Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using Repository.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourguideController : ControllerBase
    {
        private readonly ITourguideService _tourguideService;

        public TourguideController(ITourguideService tourguideService)
        {
            _tourguideService = tourguideService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TourguideDTO>>> GetAllTourguides()
        {
            var tourguides = await _tourguideService.GetAllTourguidesAsync();
            return Ok(tourguides);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TourguideDTO>> GetTourguideById(int id)
        {
            var tourguide = await _tourguideService.GetTourguideByIdAsync(id);
            if (tourguide == null) return NotFound();
            return Ok(tourguide);
        }

        [HttpPost]
        public async Task<ActionResult<TourguideDTO>> AddTourguide([FromBody] TourguideDTO tourguideDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var newTourguide = await _tourguideService.AddTourguideAsync(tourguideDTO);
            return CreatedAtAction(nameof(GetTourguideById), new { id = newTourguide.Id }, newTourguide);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTourguide(int id, [FromBody] TourguideDTO tourguideDTO)
        {
            if (id != tourguideDTO.Id) return BadRequest("ID mismatch");

            var updated = await _tourguideService.UpdateTourguideAsync(tourguideDTO);
            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTourguide(int id)
        {
            var deleted = await _tourguideService.DeleteTourguideAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
