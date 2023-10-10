using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Exceptions
{
    public sealed class ActivityNotFoundException : CustomException
    {
        public ActivityNotFoundException(Guid id) 
            : base($"Activity with id: {id} was not found.")
        {
        }
    }
}
