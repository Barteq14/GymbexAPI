using Gymbex.Blazor.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Gymbex.Blazor.Pages
{
    public partial class Index
    {
        [Parameter] public string RedirectInfo { get; set; } 
        [Inject] public Notification Notification { get; set; }

    }
}
