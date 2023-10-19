using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Gymbex.Blazor.Components
{
    public partial class ModalBlazor
    {
        [Parameter] public RenderFragment BodyContent { get; set; }
        [Parameter] public string Title { get; set; }
        [Parameter] public EventCallback OnSave { get; set; }
        [Parameter] public string ModalId { get; set; }
        [Parameter] public string ModalClass { get; set; }

        private async Task OnCancel()
        {
            await JSRuntime.InvokeVoidAsync("closeModal", ModalId);
        }
    }
}
