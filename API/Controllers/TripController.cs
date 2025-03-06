using Infrastructure.DTO;
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
        private readonly TripService _tripService;

        public TripController(TripService tripService)
        {
            _tripService = tripService;
        }

        //---------------------------------------------

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllTrips()
        {
            var trips = await _tripService.GetAllTripsAsync();
            return Ok(trips);
        }

        //

        
        [HttpGet("[action]")]
        public async Task <ActionResult> GetTrip(int id) 
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
        public async Task <IActionResult> DeleteTripAsinc(int id)
        {
            var del = await _tripService.DeleteTripAsync(id);
            if (!del) return NotFound();

            return NoContent();

        }

        //

        [HttpPost("[action]")]
        public async Task<IActionResult>UpdateTripAsinc([FromForm] AddUpdateTripDTO UpTrip)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

                var updated = await _tripService.UpdateTripAsync(UpTrip);

            if (!updated) return NotFound("Trip not found or could not be updated.");

            return NoContent();
        }














        //
        [HttpGet("[action]")]
        public async Task<IActionResult> Addddd()
        {


            throw new Exception("لم يتم العثور على العنصر المطلوب حذفه.");

        }



    }
}
