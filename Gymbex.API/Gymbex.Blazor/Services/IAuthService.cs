using Gymbex.Blazor.Models;

namespace Gymbex.Blazor.Services
{
    public interface IAuthService
    {
        Task<RegisterResult> Register(Customer registerModel);
        Task<LoginResult> Login(SignInCommand loginModel);
        Task Logout();
    }
}
