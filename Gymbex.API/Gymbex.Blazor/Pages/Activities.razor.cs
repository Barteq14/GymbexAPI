using Gymbex.Blazor.Models;
using System.Text.Json;

namespace Gymbex.Blazor.Pages
{
    public partial class Activities
    {
        private string API_URL = "https://localhost:7291/";
        private IEnumerable<ActivityDto> ActivitiesList = Enumerable.Empty<ActivityDto>();
        private async Task RefreshActivitiesList()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync($"{API_URL}api/Activity");
            client.Dispose();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            ActivitiesList = await JsonSerializer.DeserializeAsync<IEnumerable<ActivityDto>>(responseStream);
        }

        protected override async Task OnInitializedAsync()
        {
            await RefreshActivitiesList();
        }
    }
}
