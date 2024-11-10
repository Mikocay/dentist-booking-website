using System;
using System.Collections.Generic;

namespace swp391_debo_be.Entity.Implement;

public partial class PaymentNotification
{
    public Guid Id { get; set; }

    public string? PaymentRefId { get; set; }

    public string? NotiDate { get; set; }

    public string? NotiAmount { get; set; }

    public string? NotiContent { get; set; }

    public string? NotiMessage { get; set; }

    public string? NotiSignature { get; set; }

    public Guid? PaymentId { get; set; }

    public Guid? MerchantId { get; set; }

    public string? NotiStatus { get; set; }

    public string? NotiResDate { get; set; }

    public virtual Payment? Payment { get; set; }
}
