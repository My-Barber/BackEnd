using Mybarber.Models;
using System.Threading.Tasks;

namespace Mybarber.Services.Interfaces
{
    public interface IRolesServices
    {
        Task<Roles> PostRolesAsync(Roles role);
    }
}
