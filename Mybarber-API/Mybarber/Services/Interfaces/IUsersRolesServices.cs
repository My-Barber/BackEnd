using Mybarber.Models;
using System.Threading.Tasks;

namespace Mybarber.Services.Interfaces
{
    public interface IUsersRolesServices
    {
        Task<UsersRoles> PostUsersRolesAsync(UsersRoles usersRoles);
    }
}
