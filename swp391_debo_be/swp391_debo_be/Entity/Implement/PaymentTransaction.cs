using System;
using System.Collections.Generic;

namespace swp391_debo_be.Entity.Implement;

public partial class PaymentTransaction
{
    public Guid Id { get; set; }

    public string? TranMessage { get; set; }

    public string? TranStatus { get; set; }

    public decimal? TranAmount { get; set; }

    public DateTime? TranDate { get; set; }

    public Guid? PaymentId { get; set; }

    public virtual Payment? Payment { get; set; }
}
