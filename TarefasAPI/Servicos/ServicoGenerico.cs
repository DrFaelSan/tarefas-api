using TarefasAPI.Respositorios.Genericos.Interaces;
using TarefasAPI.Servicos.Genericos.Interaces;

namespace TarefasAPI.Servicos;

public class ServicoGenerico<T,K>(IRepositorioGenerico<T, K> repositorioGenerico) : IServicoGenerico<T,K> where T : class
{
    private readonly IRepositorioGenerico<T,K> _repositorioGenerico = repositorioGenerico;

    public async Task<IEnumerable<T>> BuscarTodosAsync()
        => await _repositorioGenerico.BuscarTodosAsync();
}

