using EventSchedulingAndRegistration.Domain.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedulingAndRegistration.Application.Abstract.Services
{
    public interface ITokenService
    {
        ClaimsPrincipal CurrentClaims { get; }
        Guid UserId { get; }
        string CreateJwtToken(User user);
    }
}
