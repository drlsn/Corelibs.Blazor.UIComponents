namespace Corelibs.Blazor.UIComponents.Common.Css
{
    public class CssAttribute
    {
        public double? Value { get; set; }
        public double? Value2 { get; set; }
        public string? ValueStr { get; set; }
        public Unit Unit { get; set; } = Unit.px;

        public CssAttribute() {}
        public CssAttribute(double value, Unit unit = Unit.px) { Value = value; Unit = unit; }
        public CssAttribute(string valuesString)
        {
            if (string.IsNullOrEmpty(valuesString))
                throw new ArgumentNullException();

            ValueStr = valuesString;

            if (valuesString.Contains("rgb"))
                return;

            GetFromValuesString(valuesString, out var values);
            if (values.Length == 0)
            {

            }
            else 
            if (values.Length >= 1)
            {
                Value = values[0].value;
                Unit = values[0].unit;
            }
            else
            if (values.Length >= 2)
            {
                Value2 = values[1].value;
                Unit = values[1].unit;
            }
        }

        private bool GetFromValuesString(string valuesString, out (double value, Unit unit)[] values)
        {
            var valuesStringSplit = valuesString.Split(' ');

            var list = new List<(double value, Unit unit)>();
            foreach (var valueStr in valuesStringSplit) 
            {
                if (!GetFromValueString(valueStr, out var value))
                    continue;

                list.Add(value);
            }

            values = list.ToArray();

            return true;
        }

        private bool GetFromValueString(string valueString, out (double value, Unit unit) value)
        {
            value = default;

            var lastNumber = valueString.Select((c, i) => (c, i)).LastOrDefault(ci => ci.c >= '0' && ci.c <= '9');
            
            var start = valueString.Substring(0, lastNumber.i + 1).Trim();
            var ending = valueString.Substring(lastNumber.i + 1).Trim();

            Unit unit = ending.FromName();
            if (!double.TryParse(start, out var valueParsed))
                return false;

            value = (valueParsed, unit);

            return true;
        }

        public override string ToString()
        {
            if (Value == null)
                return ValueStr ?? "";

            var value1 = $"{Value}{Unit.GetName()}";
            var value2 = Value2.HasValue ? $" {Value2}{Unit.GetName()}" : "";

            return value1 + value2;
        }

        public static implicit operator CssAttribute(string value) => new CssAttribute(value);
        public static implicit operator CssAttribute(double value) => new CssAttribute { Value = value };
        public static implicit operator CssAttribute((double value, double value2) t) => new CssAttribute { Value = t.value, Value2 = t.value2 };
        public static implicit operator CssAttribute((double value, Unit unit) t) => new CssAttribute() { Value = t.value, Unit = t.unit };
        public static implicit operator CssAttribute((double value, double value2, Unit unit) t) => new CssAttribute { Value = t.value, Value2 = t.value2, Unit = t.unit };
    }

    public class CssAttributeExt : CssAttribute
    {
        public CssAttributeExt() {}
        public CssAttributeExt(string valuesStr) : base(valuesStr) {}

        public static implicit operator CssAttributeExt(string value) => new CssAttributeExt(value);
        public static implicit operator CssAttributeExt(double value) => new CssAttributeExt { Value = value };
        public static implicit operator CssAttributeExt((double value, double value2) t) => new CssAttributeExt { Value = t.value, Value2 = t.value2 };
        public static implicit operator CssAttributeExt((double value, Unit unit) t) => new CssAttributeExt() { Value = t.value, Unit = t.unit };
        public static implicit operator CssAttributeExt((double value, double value2, Unit unit) t) => new CssAttributeExt { Value = t.value, Value2 = t.value2, Unit = t.unit };
    }
}
