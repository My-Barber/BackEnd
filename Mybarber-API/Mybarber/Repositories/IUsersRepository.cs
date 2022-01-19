using Mybarber.Models;
using System.Threading.Tasks;

namespace Mybarber.Repositories
{
    public interface IUsersRepository

    {
        Task<Users> GetUserAsync(string username, string password);
    }
}
