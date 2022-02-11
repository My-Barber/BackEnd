using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mybarber.DataTransferObject.Relacionamento;
using Mybarber.Presenters.Interfaces;
using System.Threading.Tasks;

namespace Mybarber.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/v1/usersroles")]
    public class UserRolesControllers :ControllerBase
    {
        private readonly IUsersRolesPresenter _presenter;

        public UserRolesControllers(IUsersRolesPresenter presenter)
        {
            this._presenter = presenter;

        }
        [HttpPost]
        public async Task<IActionResult> PostUsersRolesAsync(UsersRolesRequestDto usersRolesDto)
        {

            var result = await _presenter.PostUsersRolesAsync(usersRolesDto);

            return Created($"/api/v1/usersroles/", result);

        }

    }
}
