using Infrastructure.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Service;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {


        private readonly IReservationService _ReservationService;
        public ReservationController(IReservationService Reservation)
        {
            _ReservationService = Reservation;
        }

        //----------------------------------------------------------------------


        [HttpPost("[action]")]
        public async Task<IActionResult> AddReservation(reservationDTO reservation)
        {
            if (reservation == null) { return BadRequest(); }
            var res = await _ReservationService.AddReservation(reservation);
            if (res != null) { return Ok(res); }
            return BadRequest();


        }




    }
}
