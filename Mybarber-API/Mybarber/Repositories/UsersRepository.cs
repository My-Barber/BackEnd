using Microsoft.EntityFrameworkCore;
using Mybarber.Models;
using Mybarber.Persistencia;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mybarber.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly Context _context;

        public UsersRepository(Context context)
        {
            _context = context;
        }

        //-----------------------------------------------------------------------------------------------------//

        public async Task<Users> GetUserAsync(string username, string password)
        {
            try
            {
                IQueryable<Users> query = _context.Users;
                query = query.AsNoTracking()
                       .OrderBy(users => users.IdUser)
                       .Where(users => users.Username == username && users.Password == password);

                return await query.FirstOrDefaultAsync();
            }catch(Exception)
            {
                throw new Exception();
            }
        }
    }
}
