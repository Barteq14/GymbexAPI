using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Dtos;
using Gymbex.Application.Security;
using Gymbex.Core.ValueObjects;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Gymbex.Infrastructure.Auth
{
    internal sealed class Authenticatior : IAuthenticator
    {
        private readonly IOptions<AuthOption> _options;
        private readonly SigningCredentials _signingCredentials;
        private readonly JwtSecurityTokenHandler _jwtHandler = new JwtSecurityTokenHandler();
        private readonly TimeSpan _expire;
        private readonly string _issuer;
        private readonly string _audience;

        public Authenticatior(IOptions<AuthOption> options)
        {
            _options = options;
            _signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SigningKey)), SecurityAlgorithms.HmacSha256);
            _expire = options.Value.Expiry ?? TimeSpan.FromHours(1);
            _issuer = options.Value.Issuer;
            _audience = options.Value.Audience;
        }

        public JwtDto CreateToken(Guid customerId, Role role, Email email)
        {
            var now = DateTime.UtcNow;
            var expire = now.Add(_expire);

            var claims = new List<Claim>()
            {
                new(JwtRegisteredClaimNames.Sub, customerId.ToString()),
                new(JwtRegisteredClaimNames.UniqueName, customerId.ToString()),
                new Claim(ClaimTypes.Role, role.ToString()),
                new Claim(ClaimTypes.Email, email.ToString()),
                new Claim(ClaimTypes.Name, email),
                new Claim("CustomerId", customerId.ToString())
            };

            var jwt = new JwtSecurityToken(_issuer, _audience, claims, now, expire, _signingCredentials);
            var accessToken = _jwtHandler.WriteToken(jwt);

            return new JwtDto()
            {
                AccessToken = accessToken
            };
        }
    }
}
