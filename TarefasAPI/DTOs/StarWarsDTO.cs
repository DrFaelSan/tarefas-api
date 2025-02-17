namespace TarefasAPI.DTOs;

public record StarWarsDTO
{
    public string? Name { get; set; }
    public string? Gender { get; set; }
    public string? Image { get; set; }
    public double? Height { get; set; }
}
