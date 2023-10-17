using Blazored.LocalStorage;
using Gymbex.Blazor.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;

namespace Gymbex.Blazor.Services
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

        public async Task<TokenJWT> Login(SignInCommand loginModel)
        {
            var response = await _httpClient.PostAsJsonAsync($"{API}api/customer/sign-in", loginModel);
            TokenJWT result = new TokenJWT();

            if (response.IsSuccessStatusCode)
            {
                var loginResult = await response.Content.ReadFromJsonAsync<TokenJWT>();
                var token = loginResult.AccessToken;

                await _localStorage.SetItemAsync("authToken", token);
                result.AccessToken = token;
            }
            else
            {
                result.AccessToken = null;
            }
            return result;
        }
         
        public async Task<RegisterResult> Register(Customer registerModel)
        {
            var result = await _httpClient.PostAsJsonAsync($"{API}api/customer/sign-up", registerModel);
            if (!result.IsSuccessStatusCode)
                return new RegisterResult { Successful = true, Errors = null };
            return new RegisterResult { Successful = false, Errors = new List<string> { "Error occured" } };
        }

        public async Task Logout()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            await _localStorage.RemoveItemAsync("authToken");
        }
    }
}
