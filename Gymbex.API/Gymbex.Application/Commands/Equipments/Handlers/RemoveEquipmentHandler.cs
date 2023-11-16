using Gymbex.Application.Abstractions;
using Gymbex.Core.Exceptions;
using Gymbex.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Application.Commands.Equipments.Handlers
{
    public sealed class RemoveEquipmentHandler(IEquipmentRepository equipmentRepository) : ICommandHandler<RemoveEquipment>
    {
        public async Task HandlerExecuteAsync(RemoveEquipment command)
        {
            var equipment = await equipmentRepository.GetByIdAsync(command.EquipmentId);
            
            if(equipment is null)
            {
                throw new EquipmentNotFoundException(command.EquipmentId);
            }

            await equipmentRepository.DeleteAsync(equipment);
        }
    }
}
