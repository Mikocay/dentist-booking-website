using Microsoft.Extensions.Options;

namespace swp391_debo_be.Config.VnPay
{
    public class VnpayConfig
    {
        public static string ConfigName => "Vnpay";
        public string Version { get; set; } = "2.1.0";
        public string TmnCode { get; set; } = "APPZFC7N";
        public string HashSecret { get; set; } = "YONPSVXYSUNSPVKIUOOOWXASIHLLYIFS";
        public string PaymentUrl { get; set; } = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html";
        public string ReturnUrl { get; set; } = "http://localhost:5193/api/payment/vnpay-return";
    }
}
