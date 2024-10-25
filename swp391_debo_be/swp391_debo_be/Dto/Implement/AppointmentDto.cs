using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace swp391_debo_be.Dto.Implement
{
    public class AppointmentDto
    {
        public string? DentId { get; set; }

        public int TreateId { get; set; }

        public string? Date { get; set; }

        public int TimeSlot { get; set; }

    }
}
