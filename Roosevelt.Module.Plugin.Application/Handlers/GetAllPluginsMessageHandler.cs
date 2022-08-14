using AutoMapper;
using Roosevelt.Framework.Broker.ServiceBus;
using Roosevelt.Module.Plugin.Application.Messages;
using Roosevelt.Module.Plugin.Domain;
using Roosevelt.Module.Plugin.Persistence.Repositories;

namespace Roosevelt.Module.Plugin.Application.Handlers;

internal class GetAllPluginsMessageHandler : MessageHandler<GetAllPlugins, IEnumerable<PluginModel>>
{
    private readonly IMapper _mapper;
    private readonly IPluginRepository _pluginRepository;

    public GetAllPluginsMessageHandler(IMapper mapper, IPluginRepository pluginRepository)
    {
        _mapper = mapper;
        _pluginRepository = pluginRepository;
    }

    public override async Task<IEnumerable<PluginModel>> Handle(GetAllPlugins message, CancellationToken cancellationToken)
    {
        var entities = await _pluginRepository.AllToListAsync(null, new []{"Authors"});
        return _mapper.Map<IEnumerable<PluginModel>>(entities);
    }
}