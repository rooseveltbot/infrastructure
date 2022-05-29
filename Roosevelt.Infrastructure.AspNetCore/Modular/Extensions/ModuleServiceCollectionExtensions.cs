using Microsoft.Extensions.DependencyInjection;

namespace Roosevelt.Infrastructure.AspNetCore.Modular.Extensions;

public static class ModuleServiceCollectionExtensions
{
    public static IServiceCollection AddModule<TModule>(this IServiceCollection services)
        where TModule : class, IModule
    {
        var module = ActivatorUtilities.CreateInstance<TModule>(services.BuildServiceProvider());
        module.ConfigureServices(services);

        services.AddSingleton<IModule>(module);

        return services;
    }
}