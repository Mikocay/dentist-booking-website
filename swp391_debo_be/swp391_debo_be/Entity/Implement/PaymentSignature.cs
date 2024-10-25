using System;
using System.Collections.Generic;

namespace swp391_debo_be.Entity.Implement;

public partial class PaymentSignature
{
    public Guid Id { get; set; }

    public string? SignValue { get; set; }

    public string? SignAlgo { get; set; }

    public DateTime? SignDate { get; set; }

    public string? SignOwn { get; set; }

    public Guid? PaymentId { get; set; }

    public virtual Payment? Payment { get; set; }
}
