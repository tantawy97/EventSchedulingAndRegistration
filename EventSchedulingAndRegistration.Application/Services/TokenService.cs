using EventSchedulingAndRegistration.Application.Abstract.Services;
using EventSchedulingAndRegistration.Application.Common;
using EventSchedulingAndRegistration.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EventSchedulingAndRegistration.Application.Services
{
    public class TokenService(
        IHttpContextAccessor _httpContextAccessor, 
        ILogger<TokenService> _logger, 
        IOptionsMonitor<JWTConfiguration> jwtConfiguration) :ITokenService
    {
        private readonly JWTConfiguration _jwtConfiguration = jwtConfiguration.CurrentValue;

        public ClaimsPrincipal? CurrentClaims => _httpContextAccessor?.HttpContext?.User;

        public Guid UserId
        {
            get
            {
                _logger.LogInformation("Returning userID from claims");
                var userIdString = CurrentClaims?.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                if (Guid.TryParse(userIdString, out Guid userId))
                {
                    return userId;
                }
                return Guid.Empty;
            }
        }
        public string CreateJwtToken(User user)
        {
            var roleClaims = new List<Claim>();
            roleClaims.Add(new Claim("roles",user.Email== "Admin@Admin.com" ? "Admin": "User"));

            var claims = new[]
           {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            }.Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtConfiguration.Issuer,
            audience: _jwtConfiguration.Audience,
            claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtConfiguration.DurationInHours),
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
