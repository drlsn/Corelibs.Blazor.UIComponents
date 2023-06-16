using Microsoft.AspNetCore.Components;

namespace Corelibs.Blazor.UIComponents.Layouts;

public class BaseLayout : LayoutComponentBase
{
    private int _menuSize;
    protected string _paddingLeftCssAttribute => _menuSize == 0 ? "" : $"padding-left: {_menuSize.ToString()}px;";

    protected void OnMenuSizeChanged(int size)
    {
        _menuSize = size;
        InvokeAsync(StateHasChanged);
    }
}
