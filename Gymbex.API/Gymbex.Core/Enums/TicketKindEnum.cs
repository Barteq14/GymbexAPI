using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Enums
{
    public enum TicketKindEnum
    {
        [Display(Name = "Karnet na jeden dzień")]
        OneDay = 0,
        [Display(Name = "Karnet na miesiąc")]
        Month = 1,
        [Display(Name = "Karnet na pół roku")]
        HalfYear = 2,
        [Display(Name = "Karnet na rok")]
        Year = 3,
    }
}
