using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.Images;
using Mybarber.Presenters;
using System;
using System.Threading.Tasks;

namespace Mybarber.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ServicoImagemController : ControllerBase
    {
        private readonly IServicoImagemPresenter _presenter;

        public ServicoImagemController(IServicoImagemPresenter presenter)
        {
            this._presenter = presenter;
        }

        [HttpPost]
        public async Task<IActionResult> PostServicoImagemAsync(ServicoImagemRequestDto imagemDto)
        {
            try
            {

                var result = await _presenter.PostServicoImagemAsync(imagemDto);




                return Created($"/api/v1/servicoImagem/", result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex.Message}");
            }
        }
    }
}
