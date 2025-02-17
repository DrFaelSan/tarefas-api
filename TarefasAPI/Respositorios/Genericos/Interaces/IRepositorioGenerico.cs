namespace TarefasAPI.Respositorios.Genericos.Interaces;

public interface IRepositorioGenerico<TEntidade, TChave> where TEntidade : class
{
    Task<IEnumerable<TEntidade>> BuscarTodosAsync();
    Task<TEntidade?> BuscarPorIdAsync(TChave id);
    Task<TEntidade> CriarAsync(TEntidade entidade);
    TEntidade Atualizar(TEntidade entidade);
    TEntidade Deletar(TEntidade entidade);
}