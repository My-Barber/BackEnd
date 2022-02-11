using Mybarber.Models;
using System.Threading.Tasks;

namespace Mybarber.Repositories
{
    public interface IRolesRepository
    {
        Task<Roles> GetRoleAsync(string roleName);
        Task<Roles> GetRoleAsyncByUsersId(int userId);
    }
}
