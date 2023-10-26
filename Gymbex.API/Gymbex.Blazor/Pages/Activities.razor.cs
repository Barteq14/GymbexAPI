using Blazored.LocalStorage;
using Gymbex.Blazor.Models;
using Gymbex.Blazor.Services;
using Microsoft.AspNetCore.Components;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

namespace Gymbex.Blazor.Pages
{
    public partial class Activities
    {
        private string API_URL = "https://localhost:7291/";
        private List<ActivityDto> ActivitiesList = new List<ActivityDto>();
        [Inject] public ILocalStorageService LocalStorageService { get; set; }
        [Inject] public IActivityService ActivityService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        public bool ShowError { get; set; } = false;
        public string Content { get; set; } = string.Empty;
        public bool IsError { get; set; } = false;

        private async Task RefreshActivitiesList()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync($"{API_URL}api/Activity");
            client.Dispose();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            ActivitiesList = await JsonSerializer.DeserializeAsync<List<ActivityDto>>(responseStream);
        }

        protected override async Task OnInitializedAsync()
        {
            await RefreshActivitiesList();
        }

        private async Task RegisterOnActivity(Guid activityId)
        {
            var token = await LocalStorageService.GetItemAsync<string>("authToken");
            var handler = new JwtSecurityTokenHandler();

            var jwt = new JwtSecurityToken(token);
            var uniqueName = jwt.Claims.FirstOrDefault(c => c.Type == "unique_name").Value;
            var id = Guid.Parse(uniqueName);
            var command = new ReservationActivityRequest { ActivityId = activityId , CustomerId = id};


            var result = await ActivityService.RegisterOnActivity(command, activityId);

            if (result.IsSuccess)
            {
                IsError = false;
                Content = result.Message;
            }
            else
            {
                IsError = true;
                Content = result.Error;
            }
            StateHasChanged();
        }
    }
}
