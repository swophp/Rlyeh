namespace Rlyeh.Extensions;

using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddEngine(this IServiceCollection services)
    {
        services.AddSingleton<IApplicationContext, ApplicationContext>();
        services.AddSingleton<IApplication, Application>();
    }
}
