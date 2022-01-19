using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.Barbearia;
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
    [Route("api/v1/barbearias")]
    public class BarbeariasControllers : ControllerBase
    {
        private readonly IBarbeariasPresenter _presenter;
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="presenter"></param>
        public BarbeariasControllers(IBarbeariasPresenter presenter )
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
        


        /// <summary>
        /// Método responsável por obter as barbearias utilizando o parametro IdBarbearia
        /// </summary>
        /// <param name="idBarbearia"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="barbeariaDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostBarbeariaAsync(BarbeariasRequestDto barbeariaDto)
        {
            try
            {
                var result = await _presenter.PostBarbeariaAsync(barbeariaDto);

                return Created($"/api/v1/Barbearias/{result.IdBarbearia}", result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }

        [HttpDelete("{idBarbearia:int}")]
        public async Task<IActionResult> DeleteBarbeariaAsyncById(int idBarbearia)
        {

            try
            {
                var result = await _presenter.DeleteBarbeariaAsyncById(idBarbearia);

                return Ok(result);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
