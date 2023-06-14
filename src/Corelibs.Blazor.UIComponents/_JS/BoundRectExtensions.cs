using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Corelibs.Blazor.UIComponents.JS
{
    public class BoundRect
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Top { get; set; }
        public double Right { get; set; }
        public double Bottom { get; set; }
        public double Left { get; set; }
    }

    public static class BoundRectExtensions
    {
        public static ValueTask<BoundRect> GetRect(this IJSRuntime jsRuntime, string className)
        {
            return jsRuntime.InvokeAsync<BoundRect>("getBoundingClientRectByClass", className);
        }

        public static ValueTask<BoundRect> GetRect(this IJSRuntime jsRuntime, ElementReference reference)
        {
            return jsRuntime.InvokeAsync<BoundRect>("getBoundingClientRect", reference);
        }
    }
}
