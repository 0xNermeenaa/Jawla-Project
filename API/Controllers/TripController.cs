
using Infrastructure.DTO.TripDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Repository.Service;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase

    {
        private readonly ITripService _tripService;
        private readonly ICloudinaryService _cloudinaryService;

        public TripController(ITripService tripService, ICloudinaryService cloudinaryService)
        {
            _tripService = tripService;
            _cloudinaryService = cloudinaryService;
        }

        //---------------------------------------------

        [HttpGet("[action]")]
        public async Task<ActionResult<List<AllTripsDTO>>> GetAllTrips()
        {
            var trips = await _tripService.GetAllTripsAsync();
            return Ok(trips);
        }

        //

        
        [HttpGet("[action]")]
        public async Task <ActionResult<TripDetailsDTO>> GetTrip(int id) 
        {
            var trip = await _tripService.GetTripDetailsAsync(id);

            return Ok(trip);
        }

        //-----------------------------



        [HttpPost("[action]")]
        public async Task <IActionResult> AddTrip([FromForm] AddUpdateTripDTO add)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var addtrip = await _tripService.AddTripِAsync(add);

            return Ok("add successfully");
        }
        //

        [HttpDelete("[action]")]
        public async Task <IActionResult> DeleteTrip(int id)
        {
            var del = await _tripService.DeleteTripAsync(id);
            if (!del) return NotFound();

            return NoContent();

        }

        //

        [HttpPut("[action]")]
        public async Task<IActionResult>UpdateTrip([FromForm] AddUpdateTripDTO UpTrip)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

                var updated = await _tripService.UpdateTripAsync(UpTrip);

            if (!updated) return NotFound("Trip not found or could not be updated.");

            return NoContent();
        }




        //
        

    }
}
