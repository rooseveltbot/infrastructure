using Roosevelt.Common.Persistence.EntityFramework;
using Roosevelt.Module.Plugin.Persistence.Entities;

namespace Roosevelt.Module.Plugin.Persistence.Repositories;

internal class PluginRepository : EntityFrameworkRepository<PluginEntity>, IPluginRepository
{
    public PluginRepository(IPluginDbContext context) : base(context)
    {
    }
}