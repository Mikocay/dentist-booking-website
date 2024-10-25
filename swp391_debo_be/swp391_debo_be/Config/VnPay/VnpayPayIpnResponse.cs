namespace swp391_debo_be.Config.VnPay
{
    public class VnpayPayIpnResponse
    {
        public VnpayPayIpnResponse()
        {

        }
        public VnpayPayIpnResponse(string rspCode, string message)
        {
            RspCode = rspCode;
            Message = message;
        }
        public void Set(string rspCode, string message)
        {
            RspCode = rspCode;
            Message = message;
        }
        public string RspCode { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
