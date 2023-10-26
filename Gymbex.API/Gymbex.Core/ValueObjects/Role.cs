using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Exceptions;

namespace Gymbex.Core.ValueObjects
{
    public sealed record Role
    {
        public string Value { get; private set; }
        public Role(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidRoleException();
            }
            Value = value;
        }

        public static implicit operator Role(string role) => new Role(role);
        public static implicit operator string(Role role) => role.Value;

        public static Role User()
            => new("User");

        public static Role Administrator()
            => new("Administrator");

        public static Role Instructor()
            => new("Instructor");
    }
}
