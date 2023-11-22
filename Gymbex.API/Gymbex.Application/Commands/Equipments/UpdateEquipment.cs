using Gymbex.Application.Abstractions;
using Gymbex.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Application.Commands.Equipments
{
    public sealed record UpdateEquipment(Guid EquipmentId, string EquipmentName, string EquipmentDescription, 
        EquipmentState EquipmentState, int Quantity, Guid CategoryEquipmentId): ICommand;
}