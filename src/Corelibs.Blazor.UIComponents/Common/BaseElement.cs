using Corelibs.Basic.Collections;
using Corelibs.Blazor.UIComponents.Common.Css;
using Microsoft.AspNetCore.Components;

namespace Corelibs.Blazor.UIComponents.Common
{
    public abstract class BaseElement : ComponentBase
    {
        [Parameter] public string style { get; set; } = "";
        [Parameter] public string @class { get; set; } = "";

        protected string Style 
        { 
            get
            {
                var type = GetType();
                var properties = type.GetProperties().ToArray();
                var cssAttProperties = properties.Where(p => p.PropertyType == typeof(CssAttribute)).ToArray();
                var cssAttValues = cssAttProperties
                    .Select(p => new { property = p, value = p.GetValue(this) as CssAttribute })
                    .Where(p => p.value != null)
                    .ToArray();

                var styles = cssAttValues.Select(kv =>
                {
                    var name = kv.property.Name.PascalToKebabCase();
                    var value = kv.value.ToString();
                    if (string.IsNullOrEmpty(value))
                        return "";

                    return $"{name}: {value};";
                }).ToArray();

                if (styles.Length <= 1)
                    return styles.FirstOrDefault();

                return styles.Aggregate((x, y) => x + y);
            }
        }

        protected Action OnClick<T>(Action<T> action, T argument) => () =>
        {
            if (action == null || action.GetInvocationList().Length == 0)
                return;

            action.Invoke(argument);
        };

        protected Func<Task> OnClick<T>(Func<T, Task<bool>> action, T argument) => async () =>
        {
            if (action == null || action.GetInvocationList().Length == 0)
                return;

            var result = await action.Invoke(argument);
            if (!result)
                return;

            await InvokeAsync(StateHasChanged);
        };

        protected string CombinedStyle => Style + style;
    }
}
