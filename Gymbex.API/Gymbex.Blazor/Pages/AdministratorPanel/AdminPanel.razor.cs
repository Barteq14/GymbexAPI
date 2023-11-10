using Gymbex.Blazor.Models;
using Gymbex.Blazor.Services.Activity;
using Gymbex.Blazor.Services.Customer;
using Gymbex.Blazor.Services.Equipment;
using Gymbex.Blazor.Services.Reservation;
using Gymbex.Blazor.Services.Ticket;
using Microsoft.AspNetCore.Components;

namespace Gymbex.Blazor.Pages.AdministratorPanel
{
    public partial class AdminPanel
    {
        [Inject] public NavigationManager NavigationManager{ get; set; }
        [Inject] public ICustomerService CustomerService{ get; set; }
        [Inject] public ITicketService TicketService { get; set; }
        [Inject] public IActivityService ActivityService { get; set; }
        [Inject] public IReservationService ReservationService { get; set; }
        [Inject] public IEquipmentService EquipmentService { get; set; }
        public List<CustomerDto> Customers { get; set; } = new List<CustomerDto>();
        public List<TicketDto> Tickets { get; set; } = new List<TicketDto>();
        public List<ActivityDto> Activities { get; set; } = new List<ActivityDto>();
        public List<ReservationDto> Reservations { get; set; } = new List<ReservationDto>();
        public List<EquipmentDto> Equipments { get; set; } = new List<EquipmentDto>();


        public bool ShowCustomers { get; set; }
        public bool ShowTickets { get; set; }
        public bool ShowActivities { get; set; }
        public bool ShowReservations { get; set; }
        public bool ShowEquipments { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            Customers = await CustomerService.GetCustomersAsync();
            Tickets = await TicketService.GetTicketsAsync();
            Activities = await ActivityService.GetActivitiesAsync();
            Reservations = await ReservationService.GetAllReservationsForAdmin();

            var stateEquipmentResult = await EquipmentService.GetEquipments();
            if (stateEquipmentResult.IsSuccess)
            {
                Equipments = stateEquipmentResult.StateModel;
            }
        }

        private async Task InvokeEdit<T>(T value)
        {
            if(value is CustomerDto customer)
            {
                var updateModel = new UpdateCustomer {
                    CustomerId = customer.Id,
                    Fullname = customer.FullName,
                    Phone = customer.PhoneNumber,
                    Username = customer.Username
                };

                var result = await CustomerService.UpdateCustomerDtoAsync(updateModel);
            }

            if(value is TicketDto ticket)
            {
               
            }

            if(value is ActivityDto activity)
            {
                
            }
        }

        private async Task InvokeDelete<T>(T value)
        {
            if (value is CustomerDto customer)
            {
               
            }

            if (value is TicketDto ticket)
            {
                
            }

            if (value is ActivityDto activity)
            {
               
            }
        }

        private void ResetVariables()
        {
            ShowCustomers = false;
            ShowTickets = false;
            ShowActivities = false;
            ShowReservations = false;
            ShowEquipments = false;
        }

        private void CustomerListView()
        {
            ResetVariables();
            ShowCustomers = true;
            StateHasChanged();
        }

        private void TicketListView()
        {
            ResetVariables();
            ShowTickets = true;
            StateHasChanged();
        }

        private void ActivityListView()
        {
            ResetVariables();
            ShowActivities = true;
            StateHasChanged();
        }

        private void ReservationListView()
        {
            ResetVariables();
            ShowReservations = true;
            StateHasChanged();
        }

        private void EquipmentListView()
        {
            ResetVariables();
            ShowEquipments = true;
            StateHasChanged();
        }
    }
}
