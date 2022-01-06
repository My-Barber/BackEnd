using Microsoft.EntityFrameworkCore;
using Mybarber.Models;
using Mybarber.Persistencia;
using Mybarber.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace Mybarber.Repositories
{
    public class AgendamentosRepository : IAgendamentosRepository
    {
        private readonly Context _context;

        public AgendamentosRepository(Context context)
        {
            _context = context;
        }

        //-----------------------------------------------------------------------------------------------------//

        public async Task<Agendamentos> GetAgendamentosAsyncById(int idAgendamento)
        {
            IQueryable<Agendamentos> query = _context.Agendamentos;

            query = query.AsNoTracking()
                .OrderBy(agendamentos => agendamentos.IdAgendamento)
                .Where(agendamentos => agendamentos.IdAgendamento == idAgendamento);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Agendamentos[]> GetAllAgendamentosAsync()
        {
            IQueryable<Agendamentos> query = _context.Agendamentos;

            query = query.AsNoTracking()
                         .OrderBy(agendamentos => agendamentos.IdAgendamento);

            return await query.ToArrayAsync();
        }
    }
}
