using AutoMapper;
using Mybarber.DataTransferObject.Roles;
using Mybarber.Models;
using Mybarber.Presenters.Interfaces;
using Mybarber.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Mybarber.Presenters
{
    public class RolesPresenter : IRolesPresenter
    {

        private readonly IMapper _mapper;
        private readonly IRolesServices _service;
        public RolesPresenter(IRolesServices service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }
        public async Task<RolesRequestDto> PostRolesAsync(RolesRequestDto rolesDto)
        {
            try
            {
                var role = _mapper.Map<Roles>(rolesDto);

                await _service.PostRolesAsync(role);





                return rolesDto;

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
