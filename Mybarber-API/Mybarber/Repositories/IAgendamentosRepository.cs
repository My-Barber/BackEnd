using Mybarber.Models;
using System.Threading.Tasks;

namespace Mybarber.Repository
{
    public interface IAgendamentosRepository
    {

        //AGENDAMENTO
        Task<Agendamentos[]> GetAllAgendamentosAsync();
        Task<Agendamentos> GetAgendamentosAsyncById(int idAgendamento);
    }
}
