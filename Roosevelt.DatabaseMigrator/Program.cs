using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Roosevelt.Common.Persistence.EntityFramework;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

var serviceProvider = new ServiceCollection()
    .AddSingleton<IConfiguration>(config)
    .AddLogging(static builder => builder.AddConsole())
    .BuildServiceProvider();

var logger = serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger<Program>();
logger.LogInformation("Starting database migrator...");

var contexts = serviceProvider.GetRequiredService<IEnumerable<IEntityFrameworkContext>>().ToList();
logger.LogInformation("Loaded {Count} compatible database contexts", contexts.Count);

foreach (var context in contexts)
{
    var pendingMigrations = await context.Database.GetPendingMigrationsAsync();

    if (pendingMigrations.Any())
    {
        logger.LogInformation("Executing migrations from {Name}...", context.GetType().FullName);
        await context.Database.MigrateAsync();
    }
    else
    {
        logger.LogInformation("No pending migrations for {Name}", context.GetType().FullName);
    }
}