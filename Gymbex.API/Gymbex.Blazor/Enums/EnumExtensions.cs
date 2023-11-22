using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Gymbex.Blazor.Enums
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            var name = enumValue
                .GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                .GetName();

            return name;
        }
    }
}
