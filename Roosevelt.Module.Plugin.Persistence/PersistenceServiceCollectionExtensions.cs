using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Roosevelt.Common.Persistence.EntityFramework;
using Roosevelt.Module.Plugin.Persistence.Repositories;

namespace Roosevelt.Module.Plugin.Persistence;

public static class PersistenceServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PluginDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("Default");

            options.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString),
                static options =>
                {
                    options.SchemaBehavior(MySqlSchemaBehavior.Translate, static (schema, table) => $"{schema}.{table}");
                    options.MigrationsAssembly("Roosevelt.Module.Plugin.Persistence");
                });
        });

        services.AddScoped<IPluginDbContext>(static provider => provider.GetRequiredService<PluginDbContext>());
        services.AddScoped<IEntityFrameworkContext>(static provider => provider.GetRequiredService<PluginDbContext>());
        services.AddScoped<IPluginRepository, PluginRepository>();

        return services;
    }
}