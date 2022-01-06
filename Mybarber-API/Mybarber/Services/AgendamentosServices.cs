using Mybarber.Models;

using Mybarber.Repository;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public class AgendamentosServices : IAgendamentosServices
    {
        private readonly IAgendamentosRepository _repo;

        private readonly IGenerallyRepository _generally;

        public AgendamentosServices(IAgendamentosRepository repo, IGenerallyRepository generally)
        {
            this._repo = repo;
            this._generally = generally;
        }

        public async Task<IEnumerable<Agendamentos>> GetAllAgendamentosAsync()
        {
            try
            {
                var agendamentos = await _repo.GetAllAgendamentosAsync();

                return agendamentos;

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<Agendamentos> GetAgendamentoAsyncById(int idAgendamento)
        {
            try
            {
                var agendamento = await _repo.GetAgendamentosAsyncById(idAgendamento);

                return agendamento;

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<Agendamentos> PostAgendamentoAsync(Agendamentos agendamentos)
        {
            try
            {
                _generally.Add(agendamentos);

                if (await _generally.SaveChangesAsync())
                {

                    return agendamentos;
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
