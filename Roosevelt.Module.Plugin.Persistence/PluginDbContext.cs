using Microsoft.EntityFrameworkCore;
using Roosevelt.Module.Plugin.Persistence.Entities;

namespace Roosevelt.Module.Plugin.Persistence;

internal class PluginDbContext : DbContext, IPluginDbContext
{
    public PluginDbContext(DbContextOptions<PluginDbContext> options) : base(options)
    {
    }

    public DbSet<PluginEntity> Plugins { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PluginEntity>()
            .ToTable("plugin", "plugin")
            .HasMany(static p => p.Authors)
            .WithOne(static p => p.Plugin);

        modelBuilder.Entity<PluginDeveloperEntity>()
            .ToTable("plugin_developer", "plugin")
            .HasKey(static pd => new { pd.UserId, pd.PluginId });
    }
}