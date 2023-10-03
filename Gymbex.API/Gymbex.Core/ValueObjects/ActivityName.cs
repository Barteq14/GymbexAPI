using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Exceptions;

namespace Gymbex.Core.ValueObjects
{
    public sealed record ActivityName
    {
        public string Name { get; }

        public ActivityName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidActivityNameException();
            }

            Name = name;
        }

        public static implicit operator ActivityName(string name) => new ActivityName(name);
        public static implicit operator string(ActivityName name) => name.Name;

        public override string ToString()
        {
            return Name;
        }
    }
}
