using System.ComponentModel.DataAnnotations;

namespace Gymbex.Blazor.Enums
{
    public enum EquipmentState
    {
        [Display(Name = "Stan dobry")]
        GoodState = 0,
        [Display(Name = "Stan zły")]
        BadState = 1,
    }
}
