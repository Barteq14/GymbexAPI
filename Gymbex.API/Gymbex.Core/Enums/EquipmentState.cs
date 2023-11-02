using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymbex.Core.Enums
{
    public enum EquipmentState
    {
        [Display(Name = "Stan dobry")]
        GoodState = 0,
        [Display(Name = "Stan zły")]
        BadState = 1,
    }
}
