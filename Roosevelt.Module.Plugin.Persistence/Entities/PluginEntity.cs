using Roosevelt.Common.Persistence;

namespace Roosevelt.Module.Plugin.Persistence.Entities;

public class PluginEntity : Entity<Guid>
{
    public string Name { get; set; }
    public IEnumerable<PluginDeveloperEntity> Authors { get; set; }
    public string Version { get; set; }
    public string Description { get; set; }
}  