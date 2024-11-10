using Google.Apis.Auth.OAuth2.Requests;
using swp391_debo_be.Auth;
using swp391_debo_be.Constants;
using swp391_debo_be.Cores;
using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Entity.Implement;
using swp391_debo_be.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;

namespace swp391_debo_be.Services.Implements
{
    public class TokenService : ITokenService
    {
        private const string UserNotFoundErrorMessage = "User not Found";

        public ApiRespone GenerateAccessToken(UserRequestDto user)
        {
            try
                {
                User foundUser = null;
                if (user.PhoneNumber == null && user.Email != null)
                {
                    foundUser = CUser.GetUserByEmail(user.Email);
                }
                else if (user.PhoneNumber != null && user.Email == null)
                {
                    foundUser = CUser.GetUserByPhoneNumber(user.PhoneNumber);
                } else
                {
                    return new ApiRespone { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Invalid Request", Success = false };
                }

                if (foundUser == null)
                {
                    return new ApiRespone { StatusCode = System.Net.HttpStatusCode.NotFound, Message = UserNotFoundErrorMessage, Success = false };
                }

                if (!CUser.IsPasswordExist(user.Password, foundUser))
                {
                    return new ApiRespone { StatusCode = System.Net.HttpStatusCode.NotFound, Message = "Invalid Password", Success = false };
                }


                Role role = CRole.GetRoleById((int)foundUser.Role);

                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, foundUser.Id.ToString()),
                    new Claim(ClaimTypes.Email, foundUser.Email ?? string.Empty),
                    new Claim(ClaimTypes.Name, foundUser.Username ?? string.Empty),
                    new Claim(ClaimTypes.MobilePhone, foundUser.Phone ?? string.Empty),
                    new Claim(ClaimTypes.Role, role.Role1 ?? string.Empty)
                };

                string accessToken = JwtProvider.GenerateToken(claims);

                string refreshToken = JwtProvider.GenerateRefreshToken(claims); 
                // Add code here to generate access token

                CUser.SaveRefreshToken(foundUser.Id, refreshToken);

                return new ApiRespone { StatusCode = System.Net.HttpStatusCode.OK, Data = new { AccessToken = accessToken, RefreshToken = refreshToken } };
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private void AddRole(User user, List<Claim> claims)
        {
            try
            {
                string[] roleName = CUser.GetRoleName(user);

                if (roleName != null && roleName.Length > 0)
                {
                    List<Claim> claimRoles = new List<Claim>();
                    foreach (var role in roleName)
                    {
                        claimRoles.Add(new Claim(ClaimTypes.Role, role));
                    }
                    claims.AddRange(claimRoles);
                }
            } catch (System.Exception)
            {
                throw;
            }
            
        }

        public ApiRespone GenerateRefreshToken(TokenRequestDto tokenRequest)
        {
            try
            {
                List<Claim> claims = JwtProvider.DecodeToken(tokenRequest.accessToken);

                System.Console.WriteLine(claims.ToString());

                if (claims == null)
                {
                    return new ApiRespone { StatusCode = System.Net.HttpStatusCode.Forbidden, Message = "Invalid Token", Success = false };
                }


                Claim claim = claims.FirstOrDefault(c => c.Type == "email");
                if (claim == null)
                {
                    return new ApiRespone { StatusCode = System.Net.HttpStatusCode.Forbidden, Message = "Invalid Token", Success = false };
                }   
                User user = CUser.GetUserByEmail(claim.Value);

                if (CUser.IsRefreshTokenExist(user) == false)
                {
                    return new ApiRespone { StatusCode = System.Net.HttpStatusCode.Forbidden, Message = UserNotFoundErrorMessage, Success = false };
                }
                string accessToken = string.Empty;
                string refreshToken = string.Empty;
                
                JwtProvider.HandleRefreshToken(tokenRequest.accessToken, out accessToken, out refreshToken);
                CUser.SaveRefreshToken(user.Id, refreshToken);

                var result = new { AccessToken = accessToken, RefreshToken = refreshToken };

                return new ApiRespone { StatusCode = System.Net.HttpStatusCode.OK, Data = result };
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public ApiRespone HandleLogout(string token)
        {
            try
            {
                List<Claim> claims = JwtProvider.DecodeToken(token);

                if (claims == null)
                {
                    return new ApiRespone { StatusCode = System.Net.HttpStatusCode.Forbidden, Message = "Invalid Token", Success = false };
                }


                Claim claim = claims.FirstOrDefault(x => x.Type == JwtConstant.KeyClaim.Email);
                if (claim == null)
                {
                    return new ApiRespone { StatusCode = System.Net.HttpStatusCode.Forbidden, Message = "Invalid Claim", Success = false };
                }
                User user = CUser.GetUserByEmail(claim.Value);

                var result = CUser.DeleteRefreshToken(user.Id);

                if (result == false)
                {
                    return new ApiRespone { StatusCode = System.Net.HttpStatusCode.Forbidden, Message = UserNotFoundErrorMessage, Success = false };
                }

                return new ApiRespone { StatusCode = System.Net.HttpStatusCode.OK, Message = "Logout Success" };
            } catch
            {
                throw;
            }
        }

        public string GetAuthorizationHeader(HttpRequest request)
        {
            return request.Headers.Authorization.FirstOrDefault();
        }

        public string GetUserIdFromToken(string token)
        {
            var jwtToken = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;

            if (jwtToken == null)
            {
                return null;
            }

            return jwtToken.Claims.FirstOrDefault(c => c.Type == "nameid")?.Value;
        }
    }
}
