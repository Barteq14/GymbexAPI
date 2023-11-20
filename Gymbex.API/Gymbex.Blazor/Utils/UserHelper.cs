using Blazored.LocalStorage;
using System.IdentityModel.Tokens.Jwt;

namespace Gymbex.Blazor.Utils
{
    public static class UserHelper
    {
        public static async Task<Guid> GetUserId(ILocalStorageService localStorageService)
        {
            var token = await localStorageService.GetItemAsync<string>("authToken");

            if (token is null)
            {
                return Guid.NewGuid();
            }
            var handler = new JwtSecurityTokenHandler();

            var jwt = new JwtSecurityToken(token);

            var uniqueName = jwt.Claims.FirstOrDefault(c => c.Type == "unique_name").Value;

            return Guid.Parse(uniqueName);
        }
    }
}
