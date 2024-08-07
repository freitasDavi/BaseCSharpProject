using CashFlow.Domain.Entities;
using CashFlow.Domain.Security;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CashFlow.Infrastructure.Security
{
    internal class JwtTokenGenerator : IAccessTokenGenerator
    {
        private readonly uint _expirationTimeMinutes;
        private readonly string _signingkey;
        public JwtTokenGenerator(uint expirationTimeMinutes, string signingkey)
        {
            _expirationTimeMinutes = expirationTimeMinutes;

            _signingkey = signingkey;

        }
        public string Generate(User user)
        {
            var claims = new List<Claim>() 
            { 
                new (ClaimTypes.Name, user.Name),
                new (ClaimTypes.Sid, user.UserIdentifier.ToString()),
                new (ClaimTypes.Role, user.Role),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(_expirationTimeMinutes),
                SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            
            return tokenHandler.WriteToken(securityToken);
        }

        public Guid GetUserFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var codigoUsuario = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value;

            if (codigoUsuario is null)
            {
                throw new UnauthorizedAccessException();
            }

            return new Guid(codigoUsuario);

        }

        private SymmetricSecurityKey SecurityKey ()
        {
            var key = Encoding.UTF8.GetBytes(_signingkey);

            return new SymmetricSecurityKey(key);
        }
    }
}
