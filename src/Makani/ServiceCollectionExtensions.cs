using Makani.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace Makani
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMakani(this IServiceCollection services)
        {
            services.AddTransient<JsInterop>();
            return services;
        }
    }
}
