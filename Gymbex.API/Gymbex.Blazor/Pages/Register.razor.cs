using Gymbex.Blazor.Components;
using Gymbex.Blazor.Models;
using Gymbex.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Gymbex.Blazor.Pages
{
    public partial class Register
    {
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public Notification Notification { get; set; }
        public  string Email { get; set; }
        public  string Issuer { get; set; }
        public Customer Customer { get; set; } = new Customer();
        public SignInCommand SignInCommand { get; set; } = new SignInCommand();
        private JwtSecurityToken jwtSecurityToken;

        private async Task SignUp()
        {
            var customer = Customer;
            customer.Role = "User";
            customer.TicketId = null;
            customer.CustomerId = Guid.NewGuid();
            await SingUpRequest();
        }

        private string API_URL = "https://localhost:7291/";
        private IEnumerable<CustomerDto> CustomerList = Enumerable.Empty<CustomerDto>();


        private async Task SingUpRequest()
        {
            HttpClient _client = new HttpClient();
            var response = await _client.PostAsJsonAsync($"{API_URL}api/customer/sign-up", Customer);
            if (response.IsSuccessStatusCode)
            {
                NavigationManager.NavigateTo("/registration-success");
            }
        }

        private async Task SignInRequest()
        {
            HttpClient _client = new HttpClient();
            var response = await _client.PostAsJsonAsync($"{API_URL}api/customer/sign-in", SignInCommand);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var token = JsonSerializer.Deserialize<TokenJWT>(responseContent);
                jwtSecurityToken = new JwtSecurityToken(token.AccessToken);
                Email = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type.Equals("Email"))?.Value;
                Issuer = jwtSecurityToken.Claims.FirstOrDefault().Issuer;

                //var claims = new List<Claim>
                //{
                //    new Claim("Email", Email)
                //};

                //var identity = new ClaimsIdentity(claims, "custom");
                //var user = new ClaimsPrincipal(identity);

                //AuthenticationStateProvider.SetUser(user);

                // Przenieś użytkownika na stronę po zalogowaniu
                NavigationManager.NavigateTo("/login-success");
            }
        }
    }
}
