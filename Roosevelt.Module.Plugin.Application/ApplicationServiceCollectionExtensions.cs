using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Roosevelt.Framework.Broker.ServiceBus.DependencyInjection;
using Roosevelt.Module.Plugin.Application.Mappings;

namespace Roosevelt.Module.Plugin.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddServiceBus(static options => { options.Assemblies.Add(Assembly.Load("Roosevelt.Module.Plugin.Application")); });
        services.AddAutoMapper(static config =>
        {
            config.AddProfile<PluginMappingProfile>();
            config.AddProfile<PluginDeveloperMappingProfile>();
        });

        return services;
    }
}