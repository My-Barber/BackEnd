using AutoMapper;
using Mybarber.DataTransferObject.Agendamento;
using Mybarber.Models;
using Mybarber.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Presenter
{
    public class AgendamentosPresenter : IAgendamentosPresenter
    {
        private readonly IMapper _mapper;
        private readonly IAgendamentosServices _service;
        public AgendamentosPresenter(IAgendamentosServices service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }


        public async Task<IEnumerable<AgendamentosResponseDto>> GetAllAgendamentosAsync()
        {
            try
            {
                var agendamento = await _service.GetAllAgendamentosAsync();

                return _mapper.Map<IEnumerable<AgendamentosResponseDto>>(agendamento);

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<AgendamentosResponseDto> GetAgendamentoAsyncById(int idAgendamento)
        {
            try
            {
                var agendamento = await _service.GetAgendamentoAsyncById(idAgendamento);

                return _mapper.Map<AgendamentosResponseDto>(agendamento);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<AgendamentosCompleteResponseDto> PostAgendamentoAsync(AgendamentosRequestDto agendamentoDto)
        {
            try
            {
                var agendamento = _mapper.Map<Agendamentos>(agendamentoDto);

                await _service.PostAgendamentoAsync(agendamento);

                var b = await _service.GetAgendamentoAsyncById(agendamento.IdAgendamento);



                return _mapper.Map<AgendamentosCompleteResponseDto>(b);

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }



    }
}
