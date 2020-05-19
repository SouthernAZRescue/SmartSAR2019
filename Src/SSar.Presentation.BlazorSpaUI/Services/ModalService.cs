using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace SSar.Presentation.BlazorSpaUI.Services
{
    public class ModalService
    {
        public event Action<string, RenderFragment> OnShow;
        public event Action OnClose;

        public void Show(string title, Type contentType, object model = null)
        {
            if (contentType.BaseType != typeof(ComponentBase))
            {
                throw new ArgumentException($"{contentType.FullName} must be a Blazor Component");
            }

            var content = new RenderFragment(x =>
            {
                x.OpenComponent(1, contentType); 
                x.AddAttribute(2, "Model", model);
                x.CloseComponent();
            });
            OnShow?.Invoke(title, content);
        }

        public void Close()
        {
            OnClose?.Invoke();
        }
    }
}

// Credit: Chris Sainty, Creating a Reusable Javascript-Free Blazor Modal
// https://www.telerik.com/blogs/creating-a-reusable-javascript-free-blazor-modal