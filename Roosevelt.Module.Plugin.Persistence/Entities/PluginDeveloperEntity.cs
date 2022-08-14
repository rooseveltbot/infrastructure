using System.ComponentModel.DataAnnotations.Schema;

namespace Roosevelt.Module.Plugin.Persistence.Entities;

public class PluginDeveloperEntity
{
    [ForeignKey("Plugin")]
    public Guid PluginId { get; set; }
    
    public PluginEntity? Plugin { get; set; }
    
    public Guid UserId { get; set; }
}