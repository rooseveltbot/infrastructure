using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Roosevelt.Infrastructure.AspNetCore.Modular;
using Roosevelt.Infrastructure.AspNetCore.Mvc.Extensions;
using Roosevelt.Module.Plugin.Application;
using Roosevelt.Module.Plugin.Persistence;
using Roosevelt.Module.Plugin.Presentation.Mappings;

namespace Roosevelt.Module.Plugin;

public class Startup : IModule
{
    private readonly ILogger<Startup> _logger;
    private readonly IConfiguration _configuration;

    public Startup(ILogger<Startup> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public IServiceCollection ConfigureServices(IServiceCollection services)
    {
        services.AddControllers().FromAssembly("Roosevelt.Module.Plugin.Presentation");
        services.AddAutoMapper(static config =>
        {
            config.AddProfile<PluginMappingProfile>();
            config.AddProfile<PluginDeveloperMappingProfile>();
        });

        services.AddApplication();
        services.AddPersistence(_configuration);

        return services;
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
    {
        app.UseRouting();
    }
}