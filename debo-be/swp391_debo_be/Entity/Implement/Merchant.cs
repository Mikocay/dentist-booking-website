using System;
using System.Collections.Generic;

namespace swp391_debo_be.Entity.Implement;

public partial class Merchant
{
    public Guid Id { get; set; }

    public string? MerchantName { get; set; }

    public string? MerchantWeblink { get; set; }

    public string? MerchantIpnUrl { get; set; }

    public string? MerchantReturnUrl { get; set; }

    public string? SecretKey { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
