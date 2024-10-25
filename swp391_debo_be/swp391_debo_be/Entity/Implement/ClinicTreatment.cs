using System;
using System.Collections.Generic;

namespace swp391_debo_be.Entity.Implement;

public partial class ClinicTreatment
{
    public int Id { get; set; }

    public int? Category { get; set; }

    public Guid? AdminId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public double? Price { get; set; }

    public bool? Status { get; set; }

    public int? RuleId { get; set; }

    public int? NumOfApp { get; set; }

    public virtual User? Admin { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual TreatmentCategory? CategoryNavigation { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual Rule? Rule { get; set; }

    public virtual ICollection<Employee> Dents { get; set; } = new List<Employee>();
}
