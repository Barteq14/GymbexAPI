using Gymbex.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gymbex.Application.Commands.Equipments
{
    public sealed record RemoveEquipment(Guid EquipmentId) : ICommand;
}
