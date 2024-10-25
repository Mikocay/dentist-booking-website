using Microsoft.Owin.Security;
using swp391_debo_be.Config.VnPay;
using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Entity.Implement;

namespace swp391_debo_be.Dao.Interface
{
    public interface IPaymentDao
    {
        public PaymentLinkDto Create(CreatePaymentDto createPaymentDto, Guid appointmentId);
        public PaymenReturnDto HandleVnpayPaymentReturnProcess(VnpayPayResponse vnpayPayResponse);
    }
}
