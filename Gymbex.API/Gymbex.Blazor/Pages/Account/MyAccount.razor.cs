using Microsoft.AspNetCore.Components;

namespace Gymbex.Blazor.Pages.Account
{
    public partial class MyAccount
    {
        [Parameter] public Guid CustomerId { get; set; }

        protected override Task OnInitializedAsync()
        {
            //zapytanie o usera
        }
    }
}
