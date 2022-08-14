using Microsoft.EntityFrameworkCore;
using Roosevelt.Common.Persistence.EntityFramework;
using Roosevelt.Module.Plugin.Persistence.Entities;

namespace Roosevelt.Module.Plugin.Persistence;

public interface IPluginDbContext : IEntityFrameworkContext
{
    public DbSet<PluginEntity> Plugins { get; set; }
}