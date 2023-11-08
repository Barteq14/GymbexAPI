using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Entities;
using Gymbex.Core.Enums;
using Gymbex.Core.Enums.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Gymbex.Infrastructure.DAL
{
    internal sealed class DatabaseInitializer : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public DatabaseInitializer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<GymbexDbContext>();
                dbContext.Database.Migrate();

                var tickets = dbContext.Tickets.ToList();
                if (!tickets.Any())
                {
                    tickets = new List<Ticket>()
                    {
                        new Ticket(Guid.NewGuid(), TicketKindEnum.OneDay, TicketKindEnum.OneDay.GetDisplayName()),
                        new Ticket(Guid.NewGuid(), TicketKindEnum.Month, TicketKindEnum.Month.GetDisplayName()),
                        new Ticket(Guid.NewGuid(), TicketKindEnum.HalfYear, TicketKindEnum.HalfYear.GetDisplayName()),
                        new Ticket(Guid.NewGuid(), TicketKindEnum.Year, TicketKindEnum.Year.GetDisplayName()),
                    };

                    dbContext.Tickets.AddRange(tickets);
                    dbContext.SaveChanges();
                }

                var categoriesEquipment = dbContext.CategoriesEquipment.ToList();
                if (!categoriesEquipment.Any())
                {
                    categoriesEquipment = new List<CategoryEquipment>()
                    {
                        CategoryEquipment.Create(Guid.NewGuid(), "Gryfy i obciążenia"),
                        CategoryEquipment.Create(Guid.NewGuid(), "Skakanki, wałki, rollert, gumy, piłki"),
                        CategoryEquipment.Create(Guid.NewGuid(), "Maty do ćwiczeń"),
                        CategoryEquipment.Create(Guid.NewGuid(), "Hantle, ciężarki, talerze"),
                        CategoryEquipment.Create(Guid.NewGuid(), "Wyciągi poręcze i atlasy do ćwiczeń"),
                        CategoryEquipment.Create(Guid.NewGuid(), "Stojaki i sztangi"),
                        CategoryEquipment.Create(Guid.NewGuid(), "Drążki do podciągania"),
                        CategoryEquipment.Create(Guid.NewGuid(), "Bramy wielofunkcyjne"),
                        CategoryEquipment.Create(Guid.NewGuid(), "Maszyny na wolny ciężar"),
                        CategoryEquipment.Create(Guid.NewGuid(), "Ławki, modlitewniki"),
                    };

                    dbContext.CategoriesEquipment.AddRange(categoriesEquipment);
                    dbContext.SaveChanges();
                }

                var equipments = dbContext.Equipments.ToList();
                if (!equipments.Any())
                {
                    var categories = categoriesEquipment.ToList();  
                    var categoryIds = categoriesEquipment.Select(cat => cat.Id).ToList();

                    equipments = new List<Equipment>()
                    {
                        Equipment.Create(Guid.NewGuid(), "Sztanga 1,5m", "Sztanga, rozmiar półtora metra, średnia", EquipmentState.GoodState, 10, categoryIds[5]),
                        Equipment.Create(Guid.NewGuid(), "Sztanga 2m", "Sztanga, rozmiar dwa metry, duża", EquipmentState.GoodState, 10, categoryIds[5]),
                        Equipment.Create(Guid.NewGuid(), "Gryf 1m", "Gryf, rozmiar jeden metr, mały", EquipmentState.GoodState, 10, categories.FirstOrDefault(x => x.Name.Value.Contains("Gryfy")).Id),
                        Equipment.Create(Guid.NewGuid(), "Gryf 1,5m", "Gryf, rozmiar półtora metra, duży", EquipmentState.GoodState, 10, categoryIds[0]),
                        Equipment.Create(Guid.NewGuid(), "Skakanka 2m", "Skakanka, rozmiar 2 metry", EquipmentState.GoodState, 10, categoryIds[1]),
                        Equipment.Create(Guid.NewGuid(), "Mata", "Mata do ćwiczeń", EquipmentState.GoodState, 10, categoryIds[2]),
                        Equipment.Create(Guid.NewGuid(), "Hantel 5kg", "Hantle do ćwiczeń 5 kg", EquipmentState.GoodState, 10, categoryIds[3]),
                        Equipment.Create(Guid.NewGuid(), "Hantel 7kg", "Hantle do ćwiczeń 7 kg", EquipmentState.GoodState, 10, categoryIds[3]),
                        Equipment.Create(Guid.NewGuid(), "Hantel 10kg", "Hantle do ćwiczeń 10 kg", EquipmentState.GoodState, 10, categoryIds[3]),
                        Equipment.Create(Guid.NewGuid(), "Hantel 12kg", "Hantle do ćwiczeń 12 kg", EquipmentState.GoodState, 10, categoryIds[3]),
                        Equipment.Create(Guid.NewGuid(), "Hantel 15kg", "Hantle do ćwiczeń 15 kg", EquipmentState.GoodState, 10, categoryIds[3]),
                        Equipment.Create(Guid.NewGuid(), "Hantel 20kg", "Hantle do ćwiczeń 20 kg", EquipmentState.GoodState, 10, categoryIds[3]),
                        Equipment.Create(Guid.NewGuid(), "Hantel 25kg", "Hantle do ćwiczeń 25 kg", EquipmentState.GoodState, 10, categoryIds[3]),
                        Equipment.Create(Guid.NewGuid(), "Hantel 30kg", "Hantle do ćwiczeń 30 kg", EquipmentState.GoodState, 10, categoryIds[3]),
                        Equipment.Create(Guid.NewGuid(), "Hantel 35kg", "Hantle do ćwiczeń 35 kg", EquipmentState.GoodState, 10, categoryIds[3]),
                        Equipment.Create(Guid.NewGuid(), "Talerz 2,5kg", "Talerz o ciężarze 2,5 kg do wyciskania", EquipmentState.GoodState, 20, categoryIds[3]),
                        Equipment.Create(Guid.NewGuid(), "Talerz 5kg", "Talerz o ciężarze 5 kg do wyciskania", EquipmentState.GoodState, 20, categoryIds[3]),
                        Equipment.Create(Guid.NewGuid(), "Talerz 10kg", "Talerz o ciężarze 10 kg do wyciskania", EquipmentState.GoodState, 20, categoryIds[3]),
                        Equipment.Create(Guid.NewGuid(), "Talerz 20kg", "Talerz o ciężarze 20 kg do wyciskania", EquipmentState.GoodState, 20, categoryIds[3]),
                        Equipment.Create(Guid.NewGuid(), "Atlas", "Atlas wielofunkcyjny do ćwiczeń", EquipmentState.GoodState, 8, categoryIds[4]),
                        Equipment.Create(Guid.NewGuid(), "Wyciąg", "Wyciąg wielofunkcyjny do ćwiczeń", EquipmentState.GoodState, 10, categoryIds[4]),
                        Equipment.Create(Guid.NewGuid(), "Stojak na sztangę", "Stojak na sztangę", EquipmentState.GoodState, 10, categoryIds[5]),
                        Equipment.Create(Guid.NewGuid(), "Drążek", "Drążek do podciągania, długość: 2 metry", EquipmentState.GoodState, 5, categoryIds[6]),
                        Equipment.Create(Guid.NewGuid(), "Brama", "Brama wielofunkcyjna", EquipmentState.GoodState, 3, categoryIds[7]),
                        Equipment.Create(Guid.NewGuid(), "Ławka", "Ławka do ćwiczeń, szerokość: 1.5 metra", EquipmentState.GoodState, 30, categoryIds[9]),
                        Equipment.Create(Guid.NewGuid(), "Gumy", "Gumy do ćwiczeń, różne rozmiary", EquipmentState.GoodState, 40, categoryIds[1]),
                        Equipment.Create(Guid.NewGuid(), "Piłki", "Piłki do ćwiczeń", EquipmentState.GoodState, 15, categoryIds[1]),
                    };

                    dbContext.Equipments.AddRange(equipments);
                    dbContext.SaveChanges();
                }
                return Task.CompletedTask;
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
