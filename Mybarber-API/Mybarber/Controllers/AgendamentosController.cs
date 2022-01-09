using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.Agendamento;
using Mybarber.Presenter;
using System;
using System.Threading.Tasks;

namespace Mybarber.Controllers
{ 
    [EnableCors]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AgendamentosController : ControllerBase
    {
        private readonly IAgendamentosPresenter _presenter;

        public AgendamentosController(IAgendamentosPresenter presenter)
        {
            this._presenter = presenter;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAgendamentosAsync()
        { 
            try
            {
                var result = await _presenter.GetAllAgendamentosAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

        [HttpGet("{idAgendamento:int}")]
        public async Task<IActionResult> GetAgendamentoAsyncById(int idAgendamento)
        {
            try
            {
                var result = await _presenter.GetAgendamentoAsyncById(idAgendamento);

                return Ok(result);

            }
            catch (Exception ex)
            {

                return BadRequest($"Erro:{ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostAgendamentoAsync(AgendamentosRequestDto agendamentoDto)
        {
            try
            {
                var result = await _presenter.PostAgendamentoAsync(agendamentoDto);

                return Created($"/api/v1/agendamentos/{result.IdAgendamento}", result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }
    }
}
