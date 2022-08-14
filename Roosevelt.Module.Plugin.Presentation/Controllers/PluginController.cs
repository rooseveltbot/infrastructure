using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Roosevelt.Framework.Broker.ServiceBus.Abstractions;
using Roosevelt.Module.Plugin.Application.Messages;
using Roosevelt.Module.Plugin.Presentation.ViewModels;

namespace Roosevelt.Module.Plugin.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
internal class PluginController : Controller
{
    private readonly IMapper _mapper;
    private readonly IServiceBus _serviceBus;

    public PluginController(IMapper mapper, IServiceBus serviceBus)
    {
        _mapper = mapper;
        _serviceBus = serviceBus;
    }

    [HttpGet]
    public async Task<IEnumerable<PluginViewModel>> Example()
    {
        var plugins = await _serviceBus.Send(new GetAllPlugins());
        return _mapper.Map<IEnumerable<PluginViewModel>>(plugins);
    }
}