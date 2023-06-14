namespace Corelibs.Blazor.UIComponents.Common;

public static class StringExtensions
{
    public static bool IsOk(this string str) => !string.IsNullOrWhiteSpace(str);
}
