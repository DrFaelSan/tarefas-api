using Microsoft.EntityFrameworkCore;
using TarefasAPI.Data;
using TarefasAPI.Respositorios.Genericos.Interaces;

namespace TarefasAPI.Respositorios.Genericos;

public class RepositorioGenerico<T, K>(AppDbContext appDbContext) : IRepositorioGenerico<T, K> where T : class
{
    protected readonly AppDbContext _appDbContext = appDbContext;

    public T Atualizar(T entidade)
    {
        _appDbContext.Set<T>().Update(entidade);
        _appDbContext.SaveChanges();
        return entidade;
    }

    public async Task<T?> BuscarPorIdAsync(K id)
        =>  await _appDbContext.Set<T>().FindAsync(id);


    public async Task<IEnumerable<T>> BuscarTodosAsync()
        => await _appDbContext.Set<T>().ToListAsync();

    public async Task<T> CriarAsync(T entidade)
    {
        await _appDbContext.Set<T>().AddAsync(entidade);
        await _appDbContext.SaveChangesAsync();
        return entidade;
    }

    public T Deletar(T entidade)
    {
        _appDbContext.Set<T>().Remove(entidade);
        _appDbContext.SaveChanges();
        return entidade;
    }
}