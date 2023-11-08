using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Reflection.Metadata;

namespace Gymbex.Blazor.Components
{
    public partial class AlertBlazor
    {
        [Parameter] public string id { get; set; }
        [Parameter] public string Content { get; set; }
        [Parameter] public string Class { get; set; }
        [Parameter] public bool IsError { get; set; } = false;
        [Parameter] public bool IsVisible { get; set; } = false;

        private ElementReference alertElement;
        private string SetClass;

    }
}
