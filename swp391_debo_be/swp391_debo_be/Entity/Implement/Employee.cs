using System;
using System.Collections.Generic;

namespace swp391_debo_be.Entity.Implement;

public partial class Employee
{
    public Guid Id { get; set; }

    public int? BrId { get; set; }

    public int? Type { get; set; }

    public double? Salary { get; set; }

    public virtual ClinicBranch? Br { get; set; }

    public virtual User IdNavigation { get; set; } = null!;

    public virtual ICollection<ClinicTreatment> Treats { get; set; } = new List<ClinicTreatment>();
}
