using System.ComponentModel.DataAnnotations;

namespace TarefasAPI.Data.Entidades;

public class Tarefa
{
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; } = null!;
    public bool Completa { get; set; }
}
