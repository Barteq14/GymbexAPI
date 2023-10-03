using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Exceptions
{
    internal class ActivityDateIsInPastException : CustomException
    {
        public ActivityDateIsInPastException(DateTime date) 
            : base($"Input date: {date} is in past. Please input valid date.")
        {
        }
    }
}
