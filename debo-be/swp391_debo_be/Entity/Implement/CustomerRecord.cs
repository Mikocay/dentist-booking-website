using System;
using System.Collections.Generic;

namespace swp391_debo_be.Entity.Implement;

public partial class CustomerRecord
{
    public int Id { get; set; }

    public Guid? CusId { get; set; }

    public Guid? DentId { get; set; }

    public string? Summary { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual User? Cus { get; set; }

    public virtual Employee? Dent { get; set; }
}
