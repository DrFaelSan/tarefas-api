using AutoMapper;
using TarefasAPI.Data.Entidades;
using TarefasAPI.DTOs;
using TarefasAPI.Extensoes;
using TarefasAPI.Respositorios.Genericos.Interaces;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices();

var app = builder.Build();

app.MapGet("/starWars", async (IHttpClientFactory httpFactory) =>
{
    using HttpClient client = httpFactory.CreateClient("star");
    var response = await client.GetAsync($"api/all.json");
    return await response.ReadContentAs<IEnumerable<StarWarsDTO>>();
});

app.MapGet("/tarefas", async (IRepositorioGenerico<Tarefa, int> _repositorio) =>
{
    return await _repositorio.BuscarTodosAsync();
});

app.MapGet("/tarefas/{id}", async (IRepositorioGenerico<Tarefa, int> _repositorio, int id) =>
{
    return await _repositorio.BuscarPorIdAsync(id);
});

app.MapPost("/tarefas/criar", async (TarefaDTO tarefaDTo, IRepositorioGenerico<Tarefa, int> _repositorio, IMapper _mapper) =>
{
    var tarefa = _mapper.Map<Tarefa>(tarefaDTo);
    var tarefaCriada = await _repositorio.CriarAsync(tarefa);
    return _mapper.Map<TarefaDTO>(tarefaCriada);

});

app.UseService();

app.Run();