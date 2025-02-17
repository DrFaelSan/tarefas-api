using Microsoft.EntityFrameworkCore;
using TarefasAPI.Data.Entidades;

namespace TarefasAPI.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Tarefa> Tarefas { get; set; } 
}
