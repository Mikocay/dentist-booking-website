using System;
using System.Collections.Generic;

namespace swp391_debo_be.Entity.Implement;

public partial class Rule
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<ClinicTreatment> ClinicTreatments { get; set; } = new List<ClinicTreatment>();
}
