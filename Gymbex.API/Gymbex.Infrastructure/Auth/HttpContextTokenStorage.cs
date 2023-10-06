using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Dtos;
using Gymbex.Application.Security;
using Microsoft.AspNetCore.Http;

namespace Gymbex.Infrastructure.Auth
{
    public sealed class HttpContextTokenStorage : ITokenStorage
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public HttpContextTokenStorage(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void Set(JwtDto accessToken)
            => _contextAccessor.HttpContext?.Items.Add("jwt",accessToken);


        public JwtDto GetJwt()
        {
            if (_contextAccessor is null)
            {
                return null;
            }

            if (_contextAccessor.HttpContext.Items.TryGetValue("jwt", out var jwtToken))
            {
                return jwtToken as JwtDto;
            }

            return null;
        }
    }
}
