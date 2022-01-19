using Mybarber.Models;
using System.Threading.Tasks;

namespace Mybarber.Repositories
{
    public interface IRelacionamentoRepository
    {
        Task<ServicosBarbeiros> GetServicosBarbeirosAsyncByTenant(int idTenant);
    }
}
