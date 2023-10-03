using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Exceptions;

namespace Gymbex.Infrastructure.DAL.Exceptions
{
    internal sealed class ActivityNotFoundException : CustomException
    {
        public ActivityNotFoundException(Guid id) 
            : base($"Activity with id: {id} was not found.")
        {
        }
    }
}
