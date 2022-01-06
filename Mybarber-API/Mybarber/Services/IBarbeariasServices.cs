using Mybarber.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public interface IBarbeariasServices
    {
        //Task<IEnumerable<Barbearias>> GetAllBarbeariasAsync();
        Task<Barbearias> GetBarbeariaAsyncById(int idBarbearia);

        Task<Barbearias> PostBarbeariaAsync(Barbearias barbearias);
    }
}
