using Gymbex.Blazor.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace Gymbex.Blazor.Pages.MainPage
{
    public partial class Index
    {
        [Parameter] public string RedirectInfo { get; set; }
        [Inject] public Notification Notification { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("scrollToTop");
            }
        }

    }
}
