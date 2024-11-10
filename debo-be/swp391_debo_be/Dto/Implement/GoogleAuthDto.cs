using System.ComponentModel.DataAnnotations;

namespace swp391_debo_be.Dto.Implement
{
    public class GoogleAuthDto
    {
        [Required]
        public string? Code { get; set; }
    }
}
