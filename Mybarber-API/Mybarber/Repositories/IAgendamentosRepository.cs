using Mybarber.Helpers;
using Mybarber.Models;
using System.Threading.Tasks;

namespace Mybarber.Repository
{
    public interface IAgendamentosRepository
    {

        //AGENDAMENTO
        Task<Agendamentos[]> GetAllAgendamentosAsync();
        Task<Agendamentos> GetAgendamentosAsyncById(int idAgendamento);
        Task<PageList<Agendamentos>> GetAgendamentosAsyncByTenant(int tenant, PageParams pageParams);
    }
}
