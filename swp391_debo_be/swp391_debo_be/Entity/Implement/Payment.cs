using System;
using System.Collections.Generic;

namespace swp391_debo_be.Entity.Implement;

public partial class Payment
{
    public Guid Id { get; set; }

    public string? PaymentContent { get; set; }

    public string? PaymentCurrency { get; set; }

    public string? PaymentRefId { get; set; }

    public decimal? RequiredAmount { get; set; }

    public DateTime? PaymentDate { get; set; }

    public DateTime? ExpireDate { get; set; }

    public string? PaymentLanguage { get; set; }

    public decimal? PaidAmount { get; set; }

    public string? PaymentStatus { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<PaymentTransaction> PaymentTransactions { get; set; } = new List<PaymentTransaction>();
}
