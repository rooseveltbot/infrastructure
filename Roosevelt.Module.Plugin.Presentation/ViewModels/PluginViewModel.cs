namespace Roosevelt.Module.Plugin.Presentation.ViewModels;

public class PluginViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Version { get; set; }
    public IEnumerable<PluginDeveloperViewModel> Authors { get; set; }
    public string Description { get; set; }
}