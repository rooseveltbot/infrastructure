using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Roosevelt.Infrastructure.AspNetCore.Modular.Extensions;

public static class ModuleApplicationBuilderExtensions
{
    public static IApplicationBuilder UseModules(this IApplicationBuilder app, IWebHostEnvironment environment)
    {
        var modules = app.ApplicationServices.GetRequiredService<IEnumerable<IModule>>();
        
        foreach (var module in modules)
        {
            module.Configure(app, environment);
        }

        return app;
    }
}