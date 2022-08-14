using AutoMapper;
using Roosevelt.Module.Plugin.Domain;
using Roosevelt.Module.Plugin.Persistence.Entities;

namespace Roosevelt.Module.Plugin.Application.Mappings;

internal class PluginDeveloperMappingProfile : Profile
{
    public PluginDeveloperMappingProfile()
    {
        CreateMap<PluginDeveloperModel, PluginDeveloperEntity>();
        CreateMap<PluginDeveloperEntity, PluginDeveloperModel>();
    }
}