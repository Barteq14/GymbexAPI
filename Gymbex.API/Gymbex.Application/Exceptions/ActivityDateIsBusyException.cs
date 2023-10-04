using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymbex.Core.Exceptions;
using Gymbex.Core.ValueObjects;

namespace Gymbex.Application.Exceptions
{
    internal sealed class ActivityDateIsBusyException : CustomException
    {
        public ActivityDateIsBusyException(Date date) 
            : base($"Activity date: {date} is already busy.")
        {
        }
    }
}
