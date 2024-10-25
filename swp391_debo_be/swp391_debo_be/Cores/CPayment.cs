using swp391_debo_be.Config.VnPay;
using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Repository.Implement;
using swp391_debo_be.Repository.Interface;

namespace swp391_debo_be.Cores
{
    public class CPayment
    {
        protected static readonly IPaymentRepository paymentRepository = new PaymentRepository();

        public static PaymentLinkDto Create(CreatePaymentDto createPaymentDto, Guid appointmentId)
        {
            try
            {
                return paymentRepository.Create(createPaymentDto, appointmentId);
            }
            catch
            {
                throw;
            }
        }

        public static PaymenReturnDto HandlePaymentResponse(VnpayPayResponse vnpayResponse)
        {
            try
            {
                return paymentRepository.HandlePaymentResponse(vnpayResponse);
            }
            catch
            {
                throw;
            }
        }
    }
}
