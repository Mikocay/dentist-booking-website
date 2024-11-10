using System;
using System.Collections.Generic;

namespace swp391_debo_be.Entity.Implement;

public partial class ClinicBranch
{
    public int Id { get; set; }

    public Guid? MngId { get; set; }

    public Guid? AdminId { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Avt { get; set; }

    public bool? Status { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual User? Admin { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual User? Mng { get; set; }
}
