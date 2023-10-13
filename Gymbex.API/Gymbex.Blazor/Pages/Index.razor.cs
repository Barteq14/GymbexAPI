using Gymbex.Blazor.Components;
using Microsoft.AspNetCore.Components;

namespace Gymbex.Blazor.Pages
{
    public partial class Index
    {
        [Parameter] public string RedirectInfo { get; set; } 
        [Inject] public Notification Notification { get; set; }

    }
}
