namespace Rlyeh.Sandbox;

using Microsoft.Extensions.DependencyInjection;
using Rlyeh;
using Rlyeh.Extensions;
using Serilog;

internal class Program
{
    public static async Task Main(string[] args)
    {
        using var serviceProvider = CreateServiceProvider();

        var application = serviceProvider.GetRequiredService<IApplication>();
        await application.RunAsync(new CancellationToken(false));
    }

    private static ServiceProvider CreateServiceProvider()
    {
        var services = new ServiceCollection();

        services.AddSingleton(Log.Logger);
        services.AddEngine();

        return services.BuildServiceProvider();
    }
}
