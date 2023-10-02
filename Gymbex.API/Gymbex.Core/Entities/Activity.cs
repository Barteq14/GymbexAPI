using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Entities
{
    public sealed class Activity
    {
        private readonly HashSet<Customer> _customers = new();
        /// <summary>
        /// Id zajęć
        /// </summary>
        public Guid Id { get; private set; }
        /// <summary>
        /// Nazwa zajęć
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Data odbywania się zajęć
        /// </summary>
        public DateTime Date { get; private set; }
        /// <summary>
        /// Lista użytkowników zapisanych na zajęcia
        /// </summary>
        public IEnumerable<Customer> Customers { get; private set; }

        public Activity(Guid id, string name, DateTime date)
        {
            Id = id;
            Name = name;
            Date = date;
            Customers = _customers;
        }
    }
}
