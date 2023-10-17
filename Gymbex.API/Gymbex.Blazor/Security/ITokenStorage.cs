using Gymbex.Blazor.Models;

namespace Gymbex.Blazor.Security
{
    public interface ITokenStorage
    {
        TokenJWT GetToken();
    }
}
