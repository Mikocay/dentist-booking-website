using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace swp391_debo_be.Dto.Implement
{
    public class TokenRequestDto
    {
        [Required]
        public string? accessToken { get; set; }
        [Required]
        public string? refreshToken { get; set; }
    }
}
