using Gymbex.Application.Abstractions;
using Gymbex.Core.Entities;
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
    public sealed class CreateEquipmentHandler(IEquipmentRepository repository) : ICommandHandler<CreateEquipment>
    {
        public async Task HandlerExecuteAsync(CreateEquipment command)
        {
            var category = await repository.GetCategoryAsync(command.CategoryEquipmentId);

            if (category is null)
            {
                throw new CategoryEquipmentNotFoundException(command.CategoryEquipmentId);
            }

            var equipment = Equipment.Create(command.EquipmentId, command.EquipmentName,
                    command.EquipmentDescription, command.EquipmentState,
                    command.Quantity, command.CategoryEquipmentId);

            category.AddEquipment(equipment);
            await repository.UpdateCategoryEquipmentAsync(category);
        }
    }
}
