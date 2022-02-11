using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.Roles;
using Mybarber.Presenters.Interfaces;
using System.Threading.Tasks;

namespace Mybarber.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/v1/roles")]
    public class RolesControllers : ControllerBase
    {
        private readonly IRolesPresenter _presenter;

        public RolesControllers(IRolesPresenter presenter)
        {
            this._presenter = presenter;

        }

        [HttpPost]
        public async Task<IActionResult> PostRoleAsync(RolesRequestDto rolesDto)
        {

            var result = await _presenter.PostRolesAsync(rolesDto);

            return Created($"/api/v1/roles/", result);

        }

    }
}
