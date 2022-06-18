using Makani.Themes;
using Makani.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace Makani;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMakani(this IServiceCollection services)
    {
        // javascript
        services.AddTransient<ElementUtils>();
        services.AddTransient<PrismUtils>();

        // themes
        services.AddSingleton<ButtonTheme>();

        // services
        services.AddSingleton<ToastService>();

        return services;
    }
}
