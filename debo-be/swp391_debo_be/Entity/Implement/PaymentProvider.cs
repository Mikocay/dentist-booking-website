using System;
using System.Collections.Generic;

namespace swp391_debo_be.Entity.Implement;

public partial class PaymentProvider
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Desciption { get; set; }

    public virtual ICollection<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();
}
