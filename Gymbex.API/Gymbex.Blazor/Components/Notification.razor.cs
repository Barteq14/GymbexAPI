using Microsoft.AspNetCore.Components;

namespace Gymbex.Blazor.Components
{
    public partial class Notification
    {
        [Parameter] public bool VisibleTitle { get; set; } = false;
        [Parameter] public bool VisibleContent { get; set; } = false;
        [Parameter] public string Title { get; set; }
        [Parameter] public string Content { get; set; }
        [Parameter] public bool VisibleNotification { get; set; } = false;

        public void ExitNotification()
        {
            VisibleNotification = false;
            StateHasChanged();
        }
    }
}
