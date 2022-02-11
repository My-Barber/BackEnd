using Mybarber.DataTransferObject.Relacionamento;
using System.Threading.Tasks;

namespace Mybarber.Presenters.Interfaces
{
    public interface IUsersRolesPresenter
    {
        Task<UsersRolesRequestDto> PostUsersRolesAsync(UsersRolesRequestDto usersRolesDto);
    }
}
