namespace Corelibs.Blazor.UIComponents.Common.Css
{
    public enum Unit
    {
        px,
        rem,
        pt,
        em,

        None,
    }

    public static class UnitExtensions
    {
        public static string GetName(this Unit unit) =>
            unit switch
            {
                Unit.px => "px",
                Unit.rem => "rem",
                Unit.pt => "%",
                Unit.em => "em",
                _ => ""
            };

        public static Unit FromName(this string unit) =>
            unit switch
            {
                "px" => Unit.px,
                "rem" => Unit.rem,
                "em" => Unit.em,
                "%" => Unit.pt,
                _ => Unit.None
            };
    }
}
