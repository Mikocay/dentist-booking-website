using swp391_debo_be.Config.VnPay;
using swp391_debo_be.Dao.Implement;
using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Repository.Interface;

namespace swp391_debo_be.Repository.Implement
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentDao _paymentDao = new PaymentDao();
        public PaymentLinkDto Create(CreatePaymentDto createPaymentDto, Guid appointmentId)
        {
            return _paymentDao.Create(createPaymentDto, appointmentId);
        }

        public PaymenReturnDto HandlePaymentResponse(VnpayPayResponse vnpayResponse)
        {
            return _paymentDao.HandleVnpayPaymentReturnProcess(vnpayResponse);
        }
    }
}
