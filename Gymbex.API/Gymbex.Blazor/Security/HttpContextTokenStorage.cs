using Gymbex.Blazor.Models;
using Microsoft.AspNetCore.Http;

namespace Gymbex.Blazor.Security
{
    public sealed class HttpContextTokenStorage : ITokenStorage
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public HttpContextTokenStorage(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public TokenJWT GetToken()
        {
            var items = _contextAccessor.HttpContext.Items;
            var token = _contextAccessor.HttpContext.Items.Where(x => x.Key.Equals("jwt")).FirstOrDefault().Value;
            
            if(token is null)
            {
                return new TokenJWT { AccessToken = string.Empty };
            }

            return new TokenJWT
            {
                AccessToken = token.ToString()
            };
        }
    }
}
