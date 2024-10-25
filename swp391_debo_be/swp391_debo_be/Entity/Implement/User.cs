using System;
using System.Collections.Generic;

namespace swp391_debo_be.Entity.Implement;

public partial class User
{
    public Guid Id { get; set; }

    public int? Role { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string Password { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public bool? Gender { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime? DateOfBirthday { get; set; }

    public string? MedRec { get; set; }

    public string? Avt { get; set; }

    public bool? IsFirstTime { get; set; }

    public virtual ICollection<Appointment> AppointmentCreators { get; set; } = new List<Appointment>();

    public virtual ICollection<Appointment> AppointmentCus { get; set; } = new List<Appointment>();

    public virtual ICollection<Appointment> AppointmentDents { get; set; } = new List<Appointment>();

    public virtual ICollection<Appointment> AppointmentTempDents { get; set; } = new List<Appointment>();

    public virtual ICollection<ClinicBranch> ClinicBranchAdmins { get; set; } = new List<ClinicBranch>();

    public virtual ICollection<ClinicBranch> ClinicBranchMngs { get; set; } = new List<ClinicBranch>();

    public virtual ICollection<ClinicTreatment> ClinicTreatments { get; set; } = new List<ClinicTreatment>();

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual Role? RoleNavigation { get; set; }
}
