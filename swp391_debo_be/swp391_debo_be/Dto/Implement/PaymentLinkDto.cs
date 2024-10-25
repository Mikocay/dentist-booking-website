namespace swp391_debo_be.Dto.Implement
{
    public class PaymentLinkDto
    {
        public Guid? PaymentId { get; set; }
        public string PaymentUrl { get; set; } = string.Empty;
    }
}
