using AutoMapper;
using Mybarber.DataTransferObject.Relacionamento;
using Mybarber.Models;
using Mybarber.Repository;
using System;
using System.Threading.Tasks;

namespace Mybarber.Presenters
{
    public class RelacionamentosPresenter : IRelacionamentosPresenter
    {
        private readonly IMapper _mapper;
        private readonly IGenerallyRepository _repo;
        public RelacionamentosPresenter(IGenerallyRepository repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }

        public async Task<ServicosBarbeirosRequestDto> PostAgendamentoAsync(ServicosBarbeirosRequestDto relacionamentoDto)
        {
            try
            {
                var relacionamento =   _mapper.Map<ServicosBarbeiros>(relacionamentoDto);

                 _repo.Add(relacionamento);

                if (await _repo.SaveChangesAsync())
                {

                    return relacionamentoDto;
                }
                else
                {
                    throw new InvalidOperationException("Operação falhou");
                }


            }
            catch (Exception)
            {
                throw new Exception();
            }
        }


    }
}
