using System.ComponentModel.DataAnnotations;

namespace swp391_debo_be.Dto.Implement
{
    public class UserRequestDto
    {
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
