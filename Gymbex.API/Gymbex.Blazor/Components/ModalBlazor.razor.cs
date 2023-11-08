using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Gymbex.Blazor.Components
{
    public partial class ModalBlazor
    {
        [Parameter] public RenderFragment BodyContent { get; set; }
        [Parameter] public string Title { get; set; }
        [Parameter] public EventCallback OnSave { get; set; }
        [Parameter] public string OnSaveTitle { get; set; }
        [Parameter] public string ModalId { get; set; }
        [Parameter] public string ModalClass { get; set; }
        [Parameter] public bool AlertMode { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            if (string.IsNullOrEmpty(OnSaveTitle))
            {
                OnSaveTitle = "Zapisz zmiany";
            }
        }

        private async Task OnCancel()
        {
            await JSRuntime.InvokeVoidAsync("closeModal", ModalId);
        }
    }
}
