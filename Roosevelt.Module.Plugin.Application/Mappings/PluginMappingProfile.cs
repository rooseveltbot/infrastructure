using AutoMapper;
using Roosevelt.Module.Plugin.Domain;
using Roosevelt.Module.Plugin.Persistence.Entities;

namespace Roosevelt.Module.Plugin.Application.Mappings;

internal class PluginMappingProfile : Profile
{
    public PluginMappingProfile()
    {
        CreateMap<PluginModel, PluginEntity>();
        CreateMap<PluginEntity, PluginModel>();
    }
}