using Microsoft.JSInterop;

namespace Makani.Utilities;

public class PrismUtils
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;

    public PrismUtils(IJSRuntime jsRuntime)
    {
        moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Makani/makani.js").AsTask());
    }

    public async ValueTask HighlightAll()
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("highlight");
    }
}