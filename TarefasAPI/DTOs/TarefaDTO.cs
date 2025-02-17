namespace TarefasAPI.DTOs;

public sealed record TarefaDTO
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public bool Completa { get; set; }
}
