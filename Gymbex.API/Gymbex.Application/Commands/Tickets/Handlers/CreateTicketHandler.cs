using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Application.Abstractions;
using Gymbex.Core.Entities;
using Gymbex.Core.Enums;
using Gymbex.Core.Exceptions;
using Gymbex.Core.Repositories;
using Gymbex.Core.ValueObjects;

namespace Gymbex.Application.Commands.Tickets.Handlers
{
    internal sealed class CreateTicketHandler : ICommandHandler<CreateTicket>
    {
        private readonly ITicketRepository _ticketRepository;
        private static TicketKindEnum _kind;
        private static DateTime? _dateTo;

        public CreateTicketHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task HandlerExecuteAsync(CreateTicket command)
        {
            if (command.from.Date < DateTime.UtcNow.Date)
            {
                throw new InvalidTicketDatesException();
            }

            if (!Enum.IsDefined(typeof(TicketKindEnum), command.ticketKind))
            {
                throw new InvalidKindOfTicketException(command.ticketKind);
            }

            _kind = (TicketKindEnum)command.ticketKind;
            _dateTo = GetEndTicketDate(_kind, command.from);

            if (_dateTo is null)
            {
                throw new EndTicketDateIsNullException();
            }

            var newTicket = new Ticket(command.ticketId, _kind, command.from.Date, _dateTo.Value);
            await _ticketRepository.CreateAsync(newTicket);
        }

        private DateTime? GetEndTicketDate(TicketKindEnum ticketKind, Date startDate)
        {
            DateTime? endDate = null;

            switch (_kind)
            {
                case TicketKindEnum.OneDay:
                    endDate = startDate.Value.Date.AddDays(1);
                    break;
                case TicketKindEnum.Month:
                    endDate = startDate.Value.Date.AddDays(30);
                    break;
                case TicketKindEnum.HalfYear:
                    endDate = startDate.Value.Date.AddMonths(6);
                    break;
                case TicketKindEnum.Year:
                    endDate = startDate.Value.Date.AddYears(1);
                    break;
            }

            return endDate;
        }
    }
}
