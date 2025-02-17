namespace TarefasAPI.Servicos.Genericos.Interaces;

public interface IServicoGenerico<T, K> where T : class
{
    Task<IEnumerable<T>> BuscarTodosAsync();
}
