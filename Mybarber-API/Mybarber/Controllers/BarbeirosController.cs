using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.Barbeiro;
using Mybarber.Presenter;
using System;
using System.Threading.Tasks;

namespace Mybarber.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BarbeirosController : ControllerBase
    {
        private readonly IBarbeirosPresenter _presenter;

        public BarbeirosController(IBarbeirosPresenter presenter)
        {
            this._presenter = presenter;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAllBarbeirosAsync()
        //{

        //    try
        //    {
        //        var result = await _presenter.GetAllBarbeirosAsync();

        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Erro:{ex.Message}");
        //    }
        //}

        [HttpGet("{idBarbeiro:int}")]
        public async Task<IActionResult> GetBarbeiroAsyncById(int idBarbeiro)
        {
            try
            {
                var result = await _presenter.GetBarbeiroAsyncById(idBarbeiro);

                return Ok(result);

            }
            catch (Exception ex)
            {

                return BadRequest($"Erro:{ex.Message}");
            }

        }

        [HttpGet("barbearia/{idBarbearia:int}")]
        public async Task<IActionResult> GetBarbeiroAsyncByTenant(int idBarbearia)
        {
            try
            {
                var result = await _presenter.GetBarbeiroAsyncByTenant(idBarbearia);

                return Ok(result);

            }
            catch (Exception ex)
            {

                return BadRequest($"Erro:{ex.Message}");
            }

        }




        [HttpPost]
        public async Task<IActionResult> PostBarbeiroAsync(BarbeirosRequestDto barbeiroDto)
        {
            try
            {
                var result = await _presenter.PostBarbeiroAsync(barbeiroDto);

                return Created($"/api/v1/candidates/{result.IdBarbeiro}", result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }
    }
}
