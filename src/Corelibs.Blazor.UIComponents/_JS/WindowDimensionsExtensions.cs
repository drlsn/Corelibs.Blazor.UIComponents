using Microsoft.JSInterop;

namespace Corelibs.Blazor.UIComponents.JS
{
    public class WindowDimensions
    {
        public double Width { get; set; }
        public double Height { get; set; }
    }

    public static class WindowDimensionsExtensions
    {
        public static ValueTask<WindowDimensions> GetWindowDimensions(this IJSRuntime jsRuntime) =>
            jsRuntime.InvokeAsync<WindowDimensions>("getWindowDimensions");
    }
}
