using Mybarber.DataTransferObject.Roles;
using System.Threading.Tasks;

namespace Mybarber.Presenters.Interfaces
{
    public interface IRolesPresenter
    {
        Task<RolesRequestDto> PostRolesAsync(RolesRequestDto rolesDto);
    }
}
