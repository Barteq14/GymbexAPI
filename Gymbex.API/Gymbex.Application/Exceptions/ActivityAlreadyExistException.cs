using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Exceptions;
using Gymbex.Core.ValueObjects;

namespace Gymbex.Application.Exceptions
{
    internal sealed class ActivityAlreadyExistException : CustomException
    {
        public ActivityAlreadyExistException(ActivityName name) 
            : base($"Activity: {name} already exist.")
        {
        }
    }
}
