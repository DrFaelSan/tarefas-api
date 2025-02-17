using AutoMapper;
using TarefasAPI.Data.Entidades;

namespace TarefasAPI.DTOs.Mapeamento;

public class TarefaMapamento : Profile
{
    public TarefaMapamento()
    {
        CreateMap<Tarefa, TarefaDTO>().ReverseMap();
    }
}
