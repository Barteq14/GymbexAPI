using Microsoft.AspNetCore.Components;

namespace Gymbex.Blazor.Components
{
    public partial class BlazorCard
    {
        [Parameter] public string Title { get; set; }
        [Parameter] public string Description { get; set; }
        [Parameter] public string ButtonTitle { get; set; }
        [Parameter] public string ImageSrc { get; set; }
    }
}
