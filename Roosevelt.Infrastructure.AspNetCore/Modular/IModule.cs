using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Roosevelt.Infrastructure.AspNetCore.Modular;

public interface IModule
{
    public IServiceCollection ConfigureServices(IServiceCollection services);
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment environment);
}