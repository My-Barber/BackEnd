using Mybarber.DataTransferObject.Relacionamento;
using System.Threading.Tasks;

namespace Mybarber.Presenters
{
    public interface IRelacionamentosPresenter
    {
        Task<ServicosBarbeirosRequestDto> PostAgendamentoAsync(ServicosBarbeirosRequestDto relacionamentoDto);
    }
}
