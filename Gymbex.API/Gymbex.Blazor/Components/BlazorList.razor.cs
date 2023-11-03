﻿using Microsoft.AspNetCore.Components;
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


        //paginacja
        private int currentPage = 1;
        private int itemsPerPage = 10;
        private int totalItems => Items.Count;
        private int totalPages => (int)Math.Ceiling((double)totalItems / itemsPerPage);

        private List<T> CurrentPageItems => Items
            .Skip((currentPage -1) * itemsPerPage)
            .Take(itemsPerPage)
            .ToList();

        private bool IsFirstPage => currentPage == 1;
        private bool IsLastPage => currentPage == totalPages;

        private void GoToPage(int page)
        {
            if(page >= 1 && page <= totalPages)
            {
                currentPage = page;
            }
        }

        private void GoToNextPage()
        {
            if (!IsLastPage)
            {
                currentPage++;
            }
        }

        private void GoToPreviousPage()
        {
            if (!IsFirstPage)
            {
                currentPage--;
            }
        }

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
