using Microsoft.EntityFrameworkCore;
using Mybarber.Models;
using Mybarber.Persistencia;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mybarber.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        private readonly Context _context;

        public RolesRepository(Context context)
        {
            _context = context;
        }

        //-----------------------------------------------------------------------------------------------------//
        public async Task<Roles> GetRoleAsync(string roleName)
        {
            try
            {
                IQueryable<Roles> query = _context.Roles;
                query = query.AsNoTracking()
                       .OrderBy(roles => roles.IdRole)
                       .Where(roles => roles.RoleName == roleName);

                return await query.FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public async Task<Roles> GetRoleAsyncByUsersId(int userId)
        {
            try
            {
                IQueryable<Roles> query = _context.Roles;
                query = query.AsNoTracking()
                       .OrderBy(roles => roles.IdRole)
                       .Where(roles => roles.IdRole == userId);

                return await query.FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
