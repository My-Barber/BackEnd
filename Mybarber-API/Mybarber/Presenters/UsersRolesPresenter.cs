using AutoMapper;
using Mybarber.DataTransferObject.Relacionamento;
using Mybarber.Models;
using Mybarber.Presenters.Interfaces;
using Mybarber.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Mybarber.Presenters
{
    public class UsersRolesPresenter : IUsersRolesPresenter
    {
        private readonly IMapper _mapper;
        private readonly IUsersRolesServices _service;

        public UsersRolesPresenter(IUsersRolesServices service, IMapper mapper
     )
        {
            this._service = service;
            this._mapper = mapper;


        }
        public async Task<UsersRolesRequestDto> PostUsersRolesAsync(UsersRolesRequestDto usersRolesDto)
        {
            try
            {
                var role = _mapper.Map<UsersRoles>(usersRolesDto);

                await _service.PostUsersRolesAsync(role);





                return usersRolesDto;

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
