using swp391_debo_be.Config.VnPay;
using swp391_debo_be.Constants;
using swp391_debo_be.Cores;
using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Services.Interfaces;

namespace swp391_debo_be.Services.Implements
{
    public class PaymentService : IPaymentService
    {
        public ApiRespone Create(CreatePaymentDto createPaymentDto, string appointmentId)
        {

            if (Guid.TryParse(appointmentId, out Guid appId))
            {

            var result = CPayment.Create(createPaymentDto, appId);

            if (result == null)
            {
                return new ApiRespone
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = "Create payment failed",
                    Data = null,
                    Success = false
                };
            }
            return new ApiRespone
            {
                StatusCode = System.Net.HttpStatusCode.Created,
                Message = "Create payment successfully",
                Data = result,
                Success = true
            };
            } else
            {
                return new ApiRespone
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = "AppointmentId is invalid",
                    Data = null,
                    Success = false
                };
            }

        }

        public ApiRespone HandlePaymentResponse(VnpayPayResponse vnpayResponse)
        {
            var result = CPayment.HandlePaymentResponse(vnpayResponse);

            if (result.PaymentStatus != "00")
            {
                return new ApiRespone
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = "Payment failed",
                    Data = result,
                    Success = false
                };
            }

            return new ApiRespone
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Payment successfully",
                Data = result,
                Success = true
            };
        }
    }
}
