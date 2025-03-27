using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Service;
using Infrastructure.DTO;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomTripController : ControllerBase
    {
        private readonly ICustomTripService _customTripService;

        public CustomTripController(ICustomTripService customTrip)
        {
            _customTripService = customTrip;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> RequstCustomTrip(CustomTripDTO customTrip)
        {
            var Ctrip = await _customTripService.RequestCustomTrip(customTrip);

            if (Ctrip == false)
            { return BadRequest("خطاء في الطلب"); }

            return Ok("تم الطلب");
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> ResponseustomTrip(AdminCustomTripDTO customTrip)
        {
            var c = await _customTripService.ResponseCustomTrip(customTrip);
            if (c == "Custom trip accepted." || c == "Custom trip rejected.")
            { return Ok(c); }
            return BadRequest(c);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> AllCustomTrip()
        {

           var all= await _customTripService.AllCustomTrip();

            if(all ==null) { return BadRequest("No Wait CustomTrip"); }
            return Ok(all);

        }
    }
}
