using Gymbex.Blazor.Models;

namespace Gymbex.Blazor.Services.Auth
{
    public interface IAuthService
    {
        Task<RegisterResult> Register(CustomerRegisterModel registerModel);
        Task<LoginResult> Login(SignInCommand loginModel);
        Task Logout();
    }
}
