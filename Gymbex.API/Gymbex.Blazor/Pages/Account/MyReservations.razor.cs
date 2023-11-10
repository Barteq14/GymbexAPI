using Blazored.LocalStorage;
using Gymbex.Blazor.Models;
using Gymbex.Blazor.Services.Customer;
using Gymbex.Blazor.Utils;
using Microsoft.AspNetCore.Components;
using System.IdentityModel.Tokens.Jwt;

namespace Gymbex.Blazor.Pages.Account
{
    public partial class MyReservations
    {
        [Inject] public ICustomerService CustomerService { get; set; }
        [Inject] public ILocalStorageService LocalStorageService { get; set; }
        public List<ReservationDto> Reservations { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            var userId = await UserHelper.GetUserId(LocalStorageService);

            Reservations = await CustomerService.GetCustomerReservations(userId);
        }
    }
}
