
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
            if(trips!=null)
            return Ok(trips);
            return BadRequest();
        }

        //

        
        [HttpGet("{id}")]
        public async Task <ActionResult<TripDetailsDTO>> GetTrip(int id) 
        {
            var trip = await _tripService.GetTripDetailsAsync(id);
            if (trip == null) { return BadRequest($"Trip {id} not found"); }
            return Ok(trip);
        }

        //-----------------------------



        [HttpPost("[action]")]
        public async Task <IActionResult> AddTrip([FromForm] AddUpdateTripDTO add)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (add.Stste != "Active") return BadRequest("State must be Active");

            var addtrip = await _tripService.AddTripِAsync(add);
            if (addtrip != null) 
            return Ok(addtrip);
            return BadRequest();
        }
        //

        [HttpDelete("{id}")]
        public async Task <IActionResult> DeleteTrip(int id)
        {
            var del = await _tripService.DeleteTripAsync(id);
            if (!del) return BadRequest();

            return Ok("Trip Deleted");

        }

        //

        [HttpPut("[action]")]
        public async Task<IActionResult>UpdateTrip([FromForm] AddUpdateTripDTO UpTrip)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

                var updated = await _tripService.UpdateTripAsync(UpTrip);

            if (updated==false) return BadRequest("Trip not found or could not be updated.");

            return Ok("Trip Updated");
        }



        //
        [HttpGet("[action]")]
        public async Task<IActionResult> GetTripAdmin(int id)
        {
            var ATrip = await _tripService.GetTripAdmin(id);
            if (ATrip != null) return Ok (ATrip);
            return BadRequest();
        }
        

        //


        [HttpPut("{id}/state")] 
        public async Task<IActionResult> UpdateState(int id, string state)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            var st= await _tripService.UpdateTripStateAsync(id, state);
            if (st!= true) return BadRequest();
            return Ok("State Updated");
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> GetTripResevations(int tripId)
        {
            var re = await _tripService.GetTripResevations(tripId);
            if (re!= null) return Ok(re);
            return BadRequest();
        }
    }
}
