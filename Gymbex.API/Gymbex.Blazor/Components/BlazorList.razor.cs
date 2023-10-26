using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace Gymbex.Blazor.Components
{
    public partial class BlazorList<T>
    {
        [Parameter] public List<T> Items { get; set; }
        [Parameter] public string Title { get; set; }
        [Parameter] public bool ShowAdditionalButton { get; set; } = false;
        [Parameter] public string AdditionalButtonTitle { get; set; }
        
        private List<PropertyInfo> GetProperties()
        {
            if(Items is not null && Items.Any())
            {
                var itemType = Items.First().GetType(); 
                return itemType.GetProperties().ToList();
            }
            return new List<PropertyInfo>();
        }
    }
}
