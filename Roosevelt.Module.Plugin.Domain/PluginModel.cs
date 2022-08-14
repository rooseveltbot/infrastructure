namespace Roosevelt.Module.Plugin.Domain;

public class PluginModel
{
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public string Version { get; set; }
    public IEnumerable<PluginDeveloperModel> Authors { get; set; }
    public string Description { get; set; }
}