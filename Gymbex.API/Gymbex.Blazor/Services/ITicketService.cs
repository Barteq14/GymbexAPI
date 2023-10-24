﻿using Gymbex.Blazor.Models;

namespace Gymbex.Blazor.Services
{
    public interface ITicketService
    {
        //metoda do pobrania ticketu
        Task<Ticket> GetTicketAsync(Guid ticketId);
    }
}
