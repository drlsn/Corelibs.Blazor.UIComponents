using Microsoft.AspNetCore.Components;

namespace Corelibs.Blazor.UIComponents.Common;

public abstract class UIComponent : ComponentBase
{
    public static Func<Task> InvokeVoid(Delegate del, params object[] args)
    {
        return () =>
        {
            if (del is null)
                return Task.CompletedTask;

            var task = del.DynamicInvoke(args) as Task;
            if (task is null)
                return Task.CompletedTask;

            return task;
        };
    }

    public static Func<Task<bool>> InvokeBool(Delegate del, params object[] args)
    {
        return () =>
        {
            if (del is null)
                return Task.FromResult(true);

            var task = del.DynamicInvoke(args) as Task<bool>;
            if (task is null)
                return Task.FromResult(true);

            return task;
        };
    }
}
