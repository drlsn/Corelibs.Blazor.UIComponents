namespace Corelibs.Blazor.UIComponents.Common.Css
{
    public static class StyleExtensions
    {
        public static string ToStyle<T>(this string attributeName, T? value, Unit unit = Unit.px)
        {
            if (value == null)
                return null;

            string valueString = value.ToString();
            if (value is not string and not CssAttribute)
                valueString += unit.GetName();

            return $"{attributeName}: {valueString}";
        }
    }
}
