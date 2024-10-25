using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using swp391_debo_be.Config.VnPay;
using swp391_debo_be.Constants;
using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Extensions;
using swp391_debo_be.Services.Interfaces;

namespace swp391_debo_be.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public ActionResult<ApiRespone> CreatePayment([FromBody] CreatePaymentDto createPaymentDto, [FromRoute] string appointmentId)
        {
            return _paymentService.Create(createPaymentDto, appointmentId);
        }

        [HttpGet("vnpay-return")]
        public ActionResult<ApiRespone> VnpayReturn([FromQuery] VnpayPayResponse response)
        {
            
            return _paymentService.HandlePaymentResponse(response);
        }
    }
}
