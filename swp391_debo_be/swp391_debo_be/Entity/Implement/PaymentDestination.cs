using System;
using System.Collections.Generic;

namespace swp391_debo_be.Entity.Implement;

public partial class PaymentDestination
{
    public Guid Id { get; set; }

    public string? DesLogo { get; set; }

    public string? DesShortName { get; set; }

    public string? DesName { get; set; }

    public int? DesSortIndex { get; set; }

    public Guid? ParentId { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<PaymentDestination> InverseParent { get; set; } = new List<PaymentDestination>();

    public virtual PaymentDestination? Parent { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
