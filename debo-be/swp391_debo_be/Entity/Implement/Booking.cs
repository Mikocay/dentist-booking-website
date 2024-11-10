using System;
using System.Collections.Generic;

namespace swp391_debo_be.Entity.Implement;

public partial class Booking
{
    public Guid Id { get; set; }

    public Guid? PaymentId { get; set; }

    public Guid? CusId { get; set; }

    public Guid? DenId { get; set; }

    public Guid? CreatorId { get; set; }

    public bool? IsCreatedByStaff { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public string? Status { get; set; }

    public string? MedRec { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual User? Creator { get; set; }

    public virtual User? Cus { get; set; }

    public virtual Employee? Den { get; set; }

    public virtual Payment? Payment { get; set; }
}
