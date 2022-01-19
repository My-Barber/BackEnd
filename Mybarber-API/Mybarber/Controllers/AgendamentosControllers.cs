using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.Agendamento;
using Mybarber.Helpers;
using Mybarber.Presenter;
using Mybarber.Repository;
using System;
using System.Threading.Tasks;

namespace Mybarber.Controllers
{ 


   /// <summary>
   /// 
   /// </summary>
    [EnableCors]
    [ApiController]
    [Route("api/v1/agendamentos")]
    public class AgendamentosControllers : ControllerBase
    {
        private readonly IAgendamentosPresenter _presenter;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="presenter"></param>
        public AgendamentosControllers(IAgendamentosPresenter presenter, IAgendamentosRepository repo)
        {
            this._presenter = presenter;
            this._repo = repo;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idAgendamento"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="agendamentoDto"></param>
        /// <returns></returns>
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


        private readonly IAgendamentosRepository _repo;

       
        [HttpGet("tenant/{tenant:int}")]
        public async Task<IActionResult> GetAgendamentosAsyncByTenant(int tenant, [FromQuery] PageParams pageParams)
        {
            try
            {
                var result = await _repo.GetAgendamentosAsyncByTenant(tenant, pageParams);

                Response.AddPagination(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages);
               

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }


    }
}
