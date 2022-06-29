using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Makani.Utilities;

public interface IElementUtils
{
    ValueTask Blur();
    ValueTask ChangeDarkMode(bool on);
    ValueTask<bool> IsDarkMode();
    ValueTask ScrollToFragment(string elementId);
}

public class ElementUtils : IElementUtils
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

    public async ValueTask ChangeDarkMode(bool on)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("changeDarkMode", on);
    }

    public async ValueTask<bool> IsDarkMode()
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<bool>("isDarkMode");
    }
    
    public async ValueTask ScrollToFragment(string elementId)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("scrollToFragment", elementId);
    }
}