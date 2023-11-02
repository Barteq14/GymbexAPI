using Microsoft.AspNetCore.Components;
using System.Net.Sockets;
using System.Reflection;

namespace Gymbex.Blazor.Components
{
    public partial class BlazorList<T>
    {
        [Parameter] public List<T> Items { get; set; }
        [Parameter] public string Title { get; set; }
        [Parameter] public bool ShowAdditionalButton { get; set; } = false;
        [Parameter] public bool IsAdmin { get; set; } = false;
        [Parameter] public bool ShowActionHeader { get; set; } = true;
        [Parameter] public bool HaveChildContent { get; set; } = true;
        [Parameter] public string AdditionalButtonTitle { get; set; }
        [Parameter] public RenderFragment<T> ChildContent { get; set; }

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
