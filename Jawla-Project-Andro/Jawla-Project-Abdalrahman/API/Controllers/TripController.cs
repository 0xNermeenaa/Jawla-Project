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

        [HttpGet("[action]")]
        public int gg()
        {
            return 15;
        }



        [HttpGet("[action]")]
        public IActionResult Get()
        {
            return Ok(new { message = "Hello, World!" });
        }

    }
}
