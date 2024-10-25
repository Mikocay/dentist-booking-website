using System.ComponentModel.DataAnnotations;

namespace swp391_debo_be.Dto.Implement
{
    public class UserDto
    {
        [Required]
        public Guid Id { get; set; }

        public int? Role { get; set; }

        public string? Username { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public bool? Gender { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime? DateOfBirthday { get; set; }

        public string? MedRec { get; set; }

        public string? Avt { get; set; }
    }
}
