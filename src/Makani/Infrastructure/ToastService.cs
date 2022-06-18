using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Makani;
public class ToastService
{
    private readonly ILogger<ToastService> _log;

    /// <summary>
    /// How long the toast should be visible before disappearing.
    /// </summary>
    private readonly int _durationMs = 1000 * 5;

    public Action<Toast>? OnChange { get; set; }

    public ToastService(ILogger<ToastService> log)
    {
        _log = log;
    }

    internal List<Toast> Messages { get; set; } = new();

    public async Task AddToast(string message, MkState state = MkState.Default)
    {
        await AddToast(new Toast(message, state));
    }

    public async Task AddToast(Toast toast)
    {
        _log.LogInformation("Adding toast {toast}", toast);

        Messages.Add(toast);

        OnChange?.Invoke(toast);

        // don't wait for the remove to fire
#pragma warning disable CS4014
        Remove(toast, _durationMs);
#pragma warning restore CS4014
    }

    internal async Task Remove(Toast toast, int removeInMs)
    {
        var timer = new PeriodicTimer(TimeSpan.FromMilliseconds(removeInMs));

        while (await timer.WaitForNextTickAsync())
        {
            _log.LogInformation("Removing toast {toast}", toast);
            await BeginRemove(toast);
        }
    }

    private async Task BeginRemove(Toast toast)
    {
        // mark the toast as removing so the UI has a chance 
        // to make it disappear nicely
        toast.IsRemoving = true;
        OnChange?.Invoke(toast);

        // start a timer to remove the toast a few seconds after the UI can
        // fade it out
        var timer = new PeriodicTimer(TimeSpan.FromMilliseconds(2000));
        while (await timer.WaitForNextTickAsync())
        {
            // actually remove the toast
            Messages.Remove(toast);
            OnChange?.Invoke(toast);
        }
    }
}

public class Toast
{
    public Toast(string message, MkState state = MkState.Default)
    {
        Message = message;
        State = state;
    }

    public string Message { get; }
    public MkState State { get; }

    internal bool IsRemoving { get; set; }
}