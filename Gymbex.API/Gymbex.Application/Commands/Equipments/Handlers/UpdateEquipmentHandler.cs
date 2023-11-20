using Gymbex.Application.Abstractions;
using Gymbex.Core.Repositories;
using Gymbex.Core.Exceptions;
using Gymbex.Core.ValueObjects.Equipmetn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Application.Commands.Equipments.Handlers
{
    public sealed class UpdateEquipmentHandler(IEquipmentRepository equipmentRepository) : ICommandHandler<UpdateEquipment>
    {
        public async Task HandlerExecuteAsync(UpdateEquipment command)
        {
            var equipment = await equipmentRepository.GetByIdAsync(command.EquipmentId);
            if(equipment is null)
            {
                throw new EquipmentNotFoundException(command.EquipmentId);
            }

            equipment.UpdateEquipment(command.EquipmentName, command.EquipmentDescription, 
                command.EquipmentState, command.Quantity, command.CategoryEquipmentId);

            await equipmentRepository.UpdateAsync(equipment);
        }
    }
}
