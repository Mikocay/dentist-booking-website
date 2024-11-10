using swp391_debo_be.Constants;
using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Entity.Implement;

namespace swp391_debo_be.Services.Interfaces
{
    public interface ITokenService
    {
        public ApiRespone GenerateAccessToken(UserRequestDto user);

        public ApiRespone GenerateRefreshToken(TokenRequestDto token);

        public ApiRespone HandleLogout(string token);

        public string GetAuthorizationHeader(HttpRequest request);
        public string GetUserIdFromToken(string token);
    }
}
