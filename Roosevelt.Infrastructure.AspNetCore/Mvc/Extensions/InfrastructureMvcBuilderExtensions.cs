using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;

namespace Roosevelt.Infrastructure.AspNetCore.Mvc.Extensions;

public static class InfrastructureMvcBuilderExtensions
{
    public static IMvcBuilder FromAssembly(this IMvcBuilder builder, string assemblyName)
    {
        var assembly = new AssemblyPart(Assembly.Load(assemblyName));

        return builder.ConfigureApplicationPartManager(manager => manager.ApplicationParts.Add(assembly));
    }
}