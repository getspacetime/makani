using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Makani.Utilities;

public class ElementUtils
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;
    public ElementUtils(IJSRuntime jsRuntime)
    {
        _moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Makani/makani.js").AsTask());
    }

    /// <summary>
    /// Blurs the active element.
    /// </summary>
    /// <returns></returns>
    public async ValueTask Blur()
    {
        var module = await _moduleTask.Value;

        await module.InvokeVoidAsync("blurActive");
    }

    /// <summary>
    /// Blurs the supplied element.
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public async ValueTask Blur(ElementReference element)
    {
        var module = await _moduleTask.Value;

        await module.InvokeVoidAsync("blur", element);
    }
}