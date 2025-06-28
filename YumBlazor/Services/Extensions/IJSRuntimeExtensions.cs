using Microsoft.JSInterop;

namespace YumBlazor.Services.Extensions;

public static class IJSRuntimeExtensions
{
    public static async Task ToastrSuccessAsync(this IJSRuntime js, string message)
    {
        await js.InvokeVoidAsync("ShowToastr", "success", message);
    }

    public static async Task ToastrErrorAsync(this IJSRuntime js, string message)
    {
        await js.InvokeVoidAsync("ShowToastr", "error", message);
    }
}