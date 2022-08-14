using AutoMapper;
using Roosevelt.Module.Plugin.Domain;
using Roosevelt.Module.Plugin.Presentation.ViewModels;

namespace Roosevelt.Module.Plugin.Presentation.Mappings;

public class PluginMappingProfile : Profile
{
    public PluginMappingProfile()
    {
        CreateMap<PluginViewModel, PluginModel>();
        CreateMap<PluginModel, PluginViewModel>();
    }
}