using Infrastructure.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Service;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService payment)
        {
            _paymentService = payment;
        }
        //----------------------------------------------------

        [HttpPost("[action]")]
        public async Task<IActionResult> AddPayment(PaymentDTO payment)
        {
            if (payment == null) {return BadRequest();}
           var pay = await _paymentService.AddPayment(payment);
            if (pay != null) { return Ok(pay); }
            return BadRequest();

        }




    }
}
