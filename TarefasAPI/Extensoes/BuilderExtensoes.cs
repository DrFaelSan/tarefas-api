using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TarefasAPI.Data;
using TarefasAPI.DTOs.Mapeamento;
using TarefasAPI.Respositorios.Genericos;
using TarefasAPI.Respositorios.Genericos.Interaces;
using TarefasAPI.Servicos;
using TarefasAPI.Servicos.Genericos.Interaces;

namespace TarefasAPI.Extensoes;

public static class BuilderExtensoes
{
    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddServicosERespositorios()
                        .AddAutoMapper(typeof(TarefaMapamento))
                        .AddSwagger()
                        .AddHttpClient()
                        .AddContexts();

        return builder;
    }
}

public static class ServiceColletionExtensoes
{
    public static IServiceCollection AddServicosERespositorios(this IServiceCollection services)
    {

        services.AddScoped(typeof(IRepositorioGenerico<,>), typeof(RepositorioGenerico<,>));
        services.AddScoped(typeof(IServicoGenerico<,>), typeof(ServicoGenerico<,>));
        
        
        return services;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer()
                .AddSwaggerGen();

        return services;
    }

    public static IServiceCollection AddHttpClient(this IServiceCollection services)
    {
        var baseUrl = "https://akabab.github.io/starwars-api/";
        ArgumentException.ThrowIfNullOrEmpty(baseUrl);

        services.AddHttpClient("star", httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        });
        return services;
    } 
    
    public static IServiceCollection AddContexts(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("TarefasDb"));
        return services;
    }
}
