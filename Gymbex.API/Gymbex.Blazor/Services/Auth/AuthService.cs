using Blazored.LocalStorage;
using Gymbex.Blazor.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using Gymbex.Blazor.ValueObjects;

namespace Gymbex.Blazor.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        private const string API = "https://localhost:7291/";
        public AuthService(HttpClient httpClient,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public async Task<LoginResult> Login(SignInCommand loginModel)
        {
            loginModel.Email = new Email(loginModel.Email);

            var response = await _httpClient.PostAsJsonAsync($"{API}api/customer/sign-in", loginModel);
            LoginResult result = new LoginResult();

            if (response.IsSuccessStatusCode)
            {
                var loginResult = await response.Content.ReadFromJsonAsync<LoginResult>();
                var token = loginResult.Token;

                await _localStorage.SetItemAsync("authToken", token);

                result.IsSuccess = response.IsSuccessStatusCode;
                result.Token = token;
            }
            else
            {
                var loginResult = await response.Content.ReadFromJsonAsync<LoginResult>();

                result.IsSuccess = response.IsSuccessStatusCode;
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    result.Error = loginResult.Error;
                }
            }
            return result;
        }

        public async Task<RegisterResult> Register(CustomerRegisterModel registerModel)
        {
            var result = await _httpClient.PostAsJsonAsync($"{API}api/customer/sign-up", registerModel);
            var registerResult = await result.Content.ReadFromJsonAsync<RegisterResult>();

            if (result.IsSuccessStatusCode)
                return new RegisterResult { IsSuccess = registerResult.IsSuccess };
            return new RegisterResult { IsSuccess = registerResult.IsSuccess, Error = registerResult.Error };
        }

        public async Task Logout()
        {
            try
            {
                var token = await _localStorage.GetItemAsync<string>("authToken");
                await _localStorage.RemoveItemAsync("authToken");
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"Błąd podczas wylogowywania: {ex.Message}");
            }
           
        }
    }
}
