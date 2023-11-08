using Blazored.LocalStorage;
using Gymbex.Blazor.Models;
using Gymbex.Blazor.Services;
using Gymbex.Blazor.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
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
            foreach (var item in ActivitiesList)
            {
                if (item.Name.Equals("Yoga"))
                {
                    item.ImageSrc = "../Images/female-1300399_1280.png";
                }
                if (item.Name.Equals("Cross fit"))
                {
                    item.ImageSrc = "../Images/crossfitImage.jpg";
                }
                if (item.Name.Equals("Fitness"))
                {
                    item.ImageSrc = "../Images/fitness.jpg";
                }
                if (item.Name.Equals("Zumba"))
                {
                    item.ImageSrc = "../Images/zumba.jpeg";
                }
            }
        }

        private async Task RegisterOnActivity(Guid activityId)
        {
            var userId = await UserHelper.GetUserId(LocalStorageService);

            var command = new ReservationActivityRequest { ActivityId = activityId , CustomerId = userId };


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
