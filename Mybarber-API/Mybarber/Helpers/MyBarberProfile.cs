using AutoMapper;
using Mybarber.DataTransferObject.Agendamento;
using Mybarber.DataTransferObject.Barbearia;
using Mybarber.DataTransferObject.Barbeiro;
using Mybarber.DataTransferObject.Relacionamento;
using Mybarber.DataTransferObject.Servico;
using Mybarber.Models;

namespace Mybarber.Helpers
{
    public class MyBarberProfile : Profile
    {
        public MyBarberProfile()
        {
            CreateMap<Barbearias, BarbeariasResponseDto>();
            CreateMap<Barbearias, BarbeariasRequestDto>().ReverseMap();
            CreateMap<Barbearias, BarbeariasCompleteResponseDto>().ReverseMap();
            CreateMap<Servicos, ServicosCompleteResponseDto>().ReverseMap();
            CreateMap<Servicos, ServicosRequestDto>().ReverseMap();
            CreateMap<Servicos, ServicosResponseDto>();
            CreateMap<Barbeiros, BarbeirosResponseDto>();
            CreateMap<Barbeiros, BarbeirosCompleteResponseDto>().ReverseMap();
            CreateMap<Barbeiros, BarbeirosRequestDto>().ReverseMap();
            CreateMap<Agendamentos, AgendamentosRequestDto>().ReverseMap();
            CreateMap<Agendamentos, AgendamentosCompleteResponseDto>().ReverseMap();
            CreateMap<Agendamentos, AgendamentosResponseDto>();
            CreateMap<ServicosBarbeiros, ServicosBarbeirosRequestDto>().ReverseMap();
            CreateMap<ServicosBarbeiros, ServicosBarbeirosResponseDto>();

        }
    }
}
