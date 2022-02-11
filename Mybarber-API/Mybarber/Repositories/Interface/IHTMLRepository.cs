using Mybarber.Models;
using System.Threading.Tasks;

namespace Mybarber.Repositories.Interface
{
    public interface IHTMLRepository
    {
        Task<HTML> GetHTMLAsyncById(int idHTML);
    }
}
