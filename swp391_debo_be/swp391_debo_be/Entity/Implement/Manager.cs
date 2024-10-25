using System;
using System.Collections.Generic;

namespace swp391_debo_be.Entity.Implement;

public partial class Manager
{
    public Guid Id { get; set; }

    public int? BrId { get; set; }

    public virtual ClinicBranch? Br { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
