using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.Relacionamento;
using Mybarber.Persistencia;
using Mybarber.Presenter;
using Mybarber.Presenters;
using System;
using System.Threading.Tasks;

namespace Mybarber.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ServicosBarbeirosController : ControllerBase
    {
        private readonly IRelacionamentosPresenter _presenter;

        public ServicosBarbeirosController(IRelacionamentosPresenter presenter)
        {
            this._presenter = presenter;
        }

        [HttpPost]
        public async Task<IActionResult> PostRelacionamentoAsync(ServicosBarbeirosRequestDto relacionamentoDto)
        {
            try
            {

                var result = await _presenter.PostAgendamentoAsync(relacionamentoDto);




                return Created($"/api/v1/barbeirosservicos/", result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }






    }
}
