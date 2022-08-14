using Roosevelt.Framework.Broker.ServiceBus.Abstractions;
using Roosevelt.Module.Plugin.Domain;

namespace Roosevelt.Module.Plugin.Application.Messages;

public class GetAllPlugins : IMessage<IEnumerable<PluginModel>>
{
}