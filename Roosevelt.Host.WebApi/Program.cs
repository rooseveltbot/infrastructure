using Roosevelt.Infrastructure.AspNetCore.Modular.Extensions;
using Roosevelt.Infrastructure.AspNetCore.Mvc.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInternalControllers(builder.Configuration);
builder.Services.AddModule<Roosevelt.Module.Plugin.Startup>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseModules(app.Environment);

app.Run();