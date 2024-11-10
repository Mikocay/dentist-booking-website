using System;
using System.Collections.Generic;

namespace swp391_debo_be.Entity.Implement;

public partial class PaymentMethod
{
    public int Id { get; set; }

    public int? ProviderId { get; set; }

    public string? PublicKey { get; set; }

    public string? PrivateKey { get; set; }

    public string? PaymentInfo { get; set; }

    public string? IpnListenerLink { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual PaymentProvider? Provider { get; set; }
}
