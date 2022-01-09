using Mybarber.Models;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public interface IServicoImagemServices
    {
        Task<ServicoImagem> PostServicoImagemAsync(ServicoImagem imagem);
    }
}
