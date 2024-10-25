using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace swp391_debo_be.Entity.Implement;

public partial class DeboDev02Context : DbContext
{
    public DeboDev02Context()
    {
    }

    public DeboDev02Context(DbContextOptions<DeboDev02Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<ClinicBranch> ClinicBranches { get; set; }

    public virtual DbSet<ClinicTreatment> ClinicTreatments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentTransaction> PaymentTransactions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Rule> Rules { get; set; }

    public virtual DbSet<TreatmentCategory> TreatmentCategories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=debo_dev_02;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3214EC27F1C5041F");

            entity.ToTable("Appointment");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedDate).HasColumnName("Created_Date");
            entity.Property(e => e.CreatorId).HasColumnName("Creator_ID");
            entity.Property(e => e.CusId).HasColumnName("Cus_ID");
            entity.Property(e => e.DentId).HasColumnName("Dent_ID");
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.IsCreatedByStaff).HasColumnName("Is_Created_By_Staff");
            entity.Property(e => e.Note).HasMaxLength(2000);
            entity.Property(e => e.PaymentId).HasColumnName("Payment_ID");
            entity.Property(e => e.StartDate).HasColumnName("Start_Date");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.TempDentId).HasColumnName("Temp_Dent_ID");
            entity.Property(e => e.TimeSlot).HasColumnName("Time_Slot");
            entity.Property(e => e.TreatId).HasColumnName("Treat_ID");

            entity.HasOne(d => d.Creator).WithMany(p => p.AppointmentCreators)
                .HasForeignKey(d => d.CreatorId)
                .HasConstraintName("FK_Appointment.Creator_ID");

            entity.HasOne(d => d.Cus).WithMany(p => p.AppointmentCus)
                .HasForeignKey(d => d.CusId)
                .HasConstraintName("FK_Appointment.Cus_ID");

            entity.HasOne(d => d.Dent).WithMany(p => p.AppointmentDents)
                .HasForeignKey(d => d.DentId)
                .HasConstraintName("FK_Appointment.Dent_ID");

            entity.HasOne(d => d.Payment).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("FK_Appointment.Payment_ID");

            entity.HasOne(d => d.TempDent).WithMany(p => p.AppointmentTempDents)
                .HasForeignKey(d => d.TempDentId)
                .HasConstraintName("FK_Appointment.Temp_Dent_ID");

            entity.HasOne(d => d.Treat).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.TreatId)
                .HasConstraintName("FK_Appointment.Treat_ID");
        });

        modelBuilder.Entity<ClinicBranch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clinic_B__3214EC279C81B512");

            entity.ToTable("Clinic_Branch");

            entity.HasIndex(e => e.Email, "UQ_Email").IsUnique();

            entity.HasIndex(e => e.Phone, "UQ_Phone").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AdminId).HasColumnName("Admin_ID");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.MngId).HasColumnName("Mng_ID");
            entity.Property(e => e.Phone).HasMaxLength(10);

            entity.HasOne(d => d.Admin).WithMany(p => p.ClinicBranchAdmins)
                .HasForeignKey(d => d.AdminId)
                .HasConstraintName("FK_Clinic Branch.Admin_ID");

            entity.HasOne(d => d.Mng).WithMany(p => p.ClinicBranchMngs)
                .HasForeignKey(d => d.MngId)
                .HasConstraintName("FK_Clinic Branch.Mng_ID");
        });

        modelBuilder.Entity<ClinicTreatment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clinic_T__3214EC27AE5163A5");

            entity.ToTable("Clinic_Treatment");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AdminId).HasColumnName("Admin_ID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.NumOfApp).HasColumnName("Num_Of_App");
            entity.Property(e => e.RuleId).HasColumnName("Rule_ID");

            entity.HasOne(d => d.Admin).WithMany(p => p.ClinicTreatments)
                .HasForeignKey(d => d.AdminId)
                .HasConstraintName("FK_Clinic Treatment.Admin_ID");

            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.ClinicTreatments)
                .HasForeignKey(d => d.Category)
                .HasConstraintName("FK_Clinic Treatment.Category");

            entity.HasOne(d => d.Rule).WithMany(p => p.ClinicTreatments)
                .HasForeignKey(d => d.RuleId)
                .HasConstraintName("FK_ClinicTreatment.Rule_ID");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC27FC7EF367");

            entity.ToTable("Employee");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.BrId).HasColumnName("Br_ID");

            entity.HasOne(d => d.Br).WithMany(p => p.Employees)
                .HasForeignKey(d => d.BrId)
                .HasConstraintName("FK_Employee.Br_ID");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Employee)
                .HasForeignKey<Employee>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee.UserID");

            entity.HasMany(d => d.Treats).WithMany(p => p.Dents)
                .UsingEntity<Dictionary<string, object>>(
                    "DentistMajor",
                    r => r.HasOne<ClinicTreatment>().WithMany()
                        .HasForeignKey("TreatId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Dentist Major.Treat_ID"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("DentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Dentist Major.Dent_ID"),
                    j =>
                    {
                        j.HasKey("DentId", "TreatId").HasName("PK__Dentist___7EA26274180BAAE5");
                        j.ToTable("Dentist_Major");
                        j.IndexerProperty<Guid>("DentId").HasColumnName("Dent_ID");
                        j.IndexerProperty<int>("TreatId").HasColumnName("Treat_ID");
                    });
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Feedback__3214EC27E453B585");

            entity.ToTable("Feedback");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CusId).HasColumnName("Cus_ID");
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.TreatId).HasColumnName("Treat_ID");

            entity.HasOne(d => d.Cus).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CusId)
                .HasConstraintName("FK_Feedback.Cus_ID");

            entity.HasOne(d => d.Treat).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.TreatId)
                .HasConstraintName("FK_Feedback.Treat_ID");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payment__3214EC0754D0230F");

            entity.ToTable("Payment");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
            entity.Property(e => e.PaidAmount).HasColumnType("decimal(19, 2)");
            entity.Property(e => e.PaymentContent).HasMaxLength(250);
            entity.Property(e => e.PaymentCurrency).HasMaxLength(10);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentLanguage).HasMaxLength(10);
            entity.Property(e => e.PaymentRefId).HasMaxLength(50);
            entity.Property(e => e.PaymentStatus).HasMaxLength(20);
            entity.Property(e => e.RequiredAmount).HasColumnType("decimal(19, 2)");
        });

        modelBuilder.Entity<PaymentTransaction>(entity =>
        {
            entity.ToTable("PaymentTransaction");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.TranAmount).HasColumnType("decimal(19, 2)");
            entity.Property(e => e.TranDate).HasColumnType("datetime");
            entity.Property(e => e.TranMessage).HasMaxLength(250);
            entity.Property(e => e.TranStatus).HasMaxLength(10);

            entity.HasOne(d => d.Payment).WithMany(p => p.PaymentTransactions).HasForeignKey(d => d.PaymentId);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__D80AB49BB389FDC7");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("Role_ID");
            entity.Property(e => e.Role1)
                .HasMaxLength(50)
                .HasColumnName("Role");
        });

        modelBuilder.Entity<Rule>(entity =>
        {
            entity.ToTable("Rule");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TreatmentCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Treatmen__3214EC27A33F4755");

            entity.ToTable("Treatment_Category");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC2717580BB2");

            entity.ToTable("User", tb => tb.HasTrigger("trgAfterInsertUser"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.DateOfBirthday).HasColumnName("Date Of Birthday");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.IsFirstTime).HasColumnName("Is_First_Time");
            entity.Property(e => e.LastName).HasMaxLength(30);
            entity.Property(e => e.MedRec).HasColumnName("Med_Rec");
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(20);

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Role)
                .HasConstraintName("FK_User.Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
