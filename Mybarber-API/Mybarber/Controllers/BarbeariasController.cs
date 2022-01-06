using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.Barbearia;
using Mybarber.Presenter;
using Mybarber.Repository;
using System;
using System.Threading.Tasks;

namespace Mybarber.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BarbeariasController : ControllerBase
    {
        private readonly IBarbeariasPresenter _presenter;
    

        public BarbeariasController(IBarbeariasPresenter presenter )
        {
            this._presenter = presenter;
           
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAllBarbeariasAsync()
        //{

        //    try
        //    {
        //        var result = await _presenter.GetAllBarbeariasAsync();

        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Erro:{ex.Message}");
        //    }
        //}

        [HttpGet("{idBarbearia:int}")]
        public async Task<IActionResult> GetBarbeariaAsyncById(int idBarbearia)
        
        {
            try
            {
                var result = await _presenter.GetAllAtributesBarbeariaAsyncById(idBarbearia);
               

                return  Ok(result);

            }
            catch (Exception ex)
            {

                return BadRequest($"Erro:{ex.Message}");
            }

        }

        [HttpPost]
        public async Task<IActionResult> PostBarbeariaAsync(BarbeariasRequestDto barbeariaDto)
        {
            try
            {
                var result = await _presenter.PostBarbeariaAsync(barbeariaDto);

                return Created($"/api/v1/candidates/{result.IdBarbearia}", result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }
    }
}
