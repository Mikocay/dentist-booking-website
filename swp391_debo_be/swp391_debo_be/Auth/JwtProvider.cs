using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Entity.Implement;
using System.IdentityModel.Tokens.Jwt;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;

namespace swp391_debo_be.Auth
{
    public static class JwtProvider
    {
        private static readonly IConfiguration _configuration;

        static JwtProvider()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        /// <summary>
        /// Generate token
        /// </summary>
        /// <param name="claims">the</param>
        /// <returns></returns>
        public static string GenerateToken(List<Claim> claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(JwtSettingModel.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(JwtSettingModel.ExpireDayAccessToken),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public static string GenerateRefreshToken(List<Claim> claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(JwtSettingModel.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(JwtSettingModel.ExpireDayRefreshToken),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
        public static void HandleRefreshToken(string tokenInput, out string accessToken, out string refreshToken)
        {
            List<Claim> claims = DecodeToken(tokenInput);

            // Generate access token
            accessToken = GenerateToken(claims);

            // Generate refresh token
            refreshToken = GenerateToken(claims);
        }

        public static List<Claim> DecodeToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(JwtSettingModel.SecretKey);

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;

            var claims = jwtToken.Claims.ToList();

            return claims;
        }

        public static bool Validation(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtSettingModel.SecretKey);


            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
            }, out SecurityToken validatedToken);

            return true;
        }

        public static async Task<GoogleJsonWebSignature.Payload> VerifyGoogleTokenAsync(GoogleAuthDto googleAuthDto)
        {
            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string> { _configuration["GoogleAuthSettings:ClientId"] }
                };

                var payload = await GoogleJsonWebSignature.ValidateAsync(googleAuthDto.Code, settings);

                return payload;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Gets the user id from token
        /// </summary>
        /// <param name="token">The token value.</param>
        /// <returns></returns>
        public static string? GetUserId(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return null;
            }

            List<Claim> claims = DecodeToken(token);

            return GetUserId(claims);
        }

        /// <summary>
        /// Gets the user identifier from the list of claim.
        /// </summary>
        /// <param name="claims">The list of the claim.</param>
        /// <returns></returns>
        public static string? GetUserId(List<Claim> claims)
        {
            if (!claims.IsNullOrEmpty())
            {
                Claim? claim = claims.FirstOrDefault(c => c.Type == "nameid");

                if (claim != null)
                {
                    return claim.Value;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the userId by the given http context object.
        /// </summary>
        /// <param name="httpContext">The http context object.</param>
        /// <returns></returns>
        public static string? GetUserId(this HttpContext httpContext)
        {
            string accessToken = GetAccessTokenByHeader(httpContext.Request);

            return GetUserId(accessToken);
        }

        public static string GetRole(this HttpContext httpContext)
        {
            string accessToken = GetAccessTokenByHeader(httpContext.Request);

            return GetRole(accessToken);
        }

        public static string GetRole(this HttpRequest httpRequest)
        {
            string accessToken = GetAccessTokenByHeader(httpRequest);

            return GetRole(accessToken);
        }

        public static string GetRole(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return string.Empty;
            }

            List<Claim> claims = DecodeToken(token);

            return GetRole(claims);
        }

        public static string GetRole(List<Claim> claims)
        {
            if (!claims.IsNullOrEmpty())
            {
                Claim claim = claims.FirstOrDefault(c => c.Type == "role");

                if (claim != null)
                {
                    return claim.Value;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Gets the userId by the given http request object.
        /// </summary>
        /// <param name="httpRequest">The http request object.</param>
        /// <returns></returns>
        public static string? GetUserId(this HttpRequest httpRequest)
        {
            string accessToken = GetAccessTokenByHeader(httpRequest);

            if (string.IsNullOrEmpty(accessToken))
            {
                return null;
            }

            return GetUserId(accessToken);
        }

        public static string GetAccessTokenByHeader(this HttpRequest httpRequest)
        {
            string authorization = httpRequest.Headers[JwtConstant.Header.Authorization];
            return GetAccessTokenByHeader(authorization);
        }

        public static string GetAccessTokenByHeader(string authorizationValue)
        {
            try
            {
                if (string.IsNullOrEmpty(authorizationValue))
                {
                    return string.Empty;
                }

                return authorizationValue.Split(" ").Last();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
