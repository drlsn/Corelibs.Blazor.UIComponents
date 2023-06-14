using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Corelibs.Blazor.UIComponents.JS
{
    public static class SetPositionExtensions
    {
        public static ValueTask SetPosition(this IJSRuntime jsRuntime, ElementReference element, double x, double y) =>
            jsRuntime.InvokeVoidAsync("setPosition", element, x, y);
    }
}
