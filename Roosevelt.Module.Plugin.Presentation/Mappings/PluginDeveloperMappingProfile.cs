using AutoMapper;
using Roosevelt.Module.Plugin.Domain;
using Roosevelt.Module.Plugin.Presentation.ViewModels;

namespace Roosevelt.Module.Plugin.Presentation.Mappings;

public class PluginDeveloperMappingProfile : Profile
{
    public PluginDeveloperMappingProfile()
    {
        CreateMap<PluginDeveloperViewModel, PluginDeveloperModel>();
        CreateMap<PluginDeveloperModel, PluginDeveloperViewModel>();
    }
}