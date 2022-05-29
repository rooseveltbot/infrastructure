using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Roosevelt.Infrastructure.AspNetCore.Mvc.Controllers;

namespace Roosevelt.Infrastructure.AspNetCore.Mvc.Extensions;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInternalControllers(this IServiceCollection services, IConfiguration config)
    {
        services.AddControllers()
            .ConfigureApplicationPartManager(static manager =>
            {
                manager.ApplicationParts.Clear();
                manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
            });
        
        return services;
    }
}