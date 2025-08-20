using Microsoft.OpenApi.Models;
using ONDCPoC.Api.Filters;
using ONDCPoC.Api.Middleware;
using ONDCPoC.Core;
using Serilog;

namespace ONDCPoC.Api;

public static class Program
{
    private static readonly Config Config = new();

    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Load configuration
        builder.Configuration.GetSection("Config").Bind(Config);
        builder.Services.AddSingleton(Config);

        // Logging
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

        builder.Host.UseSerilog();

        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "ONDCPoC", Version = "v1" });
            //options.OperationFilter<AddClientHeadersOperationFilter>();
            options.CustomSchemaIds(type => type.FullName); 
        });

        // Add services to the container
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddHttpClient();
        builder.Services.AddTransient<IONDCService, ONDCService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            c.RoutePrefix = string.Empty;
        });

        app.UseHttpsRedirection();
        app.UseMiddleware<ClientAuthMiddleware>();

        app.UseAuthorization();
        app.MapControllers();

        await app.RunAsync();
    }
}