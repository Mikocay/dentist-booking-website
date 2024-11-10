using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace swp391_debo_be.Dto.Implement
{
    public class AppointmentHistoryDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int? TreatId { get; set; }

        [Required]
        public string? TreatName { get; set; }

        public Guid? PaymentId { get; set; }

        public Guid? DentId { get; set; }

        public Guid? TempDentId { get; set; }

        public Guid? CusId { get; set; }

        public Guid? CreatorId { get; set; }

        public bool? IsCreatedByStaff { get; set; }

        public DateOnly? CreatedDate { get; set; }

        public DateOnly? StartDate { get; set; }

        [Required]
        public int? TimeSlot { get; set; }

        [Required]
        [RegularExpression("^(cancelled|pending|future|on-going|done)$", ErrorMessage = "Invalid status value")]

        public string? Status { get; set; }

        public string? Description { get; set; }

        public string? Note { get; set; }
    }
}
