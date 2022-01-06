using AutoMapper;
using Mybarber.DataTransferObject.Barbearia;
using Mybarber.DataTransferObject.Barbeiro;
using Mybarber.DataTransferObject.Servico;
using Mybarber.Models;
using Mybarber.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Presenter
{
    public class BarbeariasPresenter : IBarbeariasPresenter
    {
        private readonly IMapper _mapper;
        private readonly IBarbeariasServices _serviceBarbearia;
     
        public BarbeariasPresenter(IBarbeariasServices serviceBarbearia , IMapper mapper
     )
        {
            this._serviceBarbearia = serviceBarbearia;
            this._mapper = mapper;
     

        }


        //public async Task<IEnumerable<BarbeariasResponseDto>> GetAllBarbeariasAsync()
        //{
        //    try
        //    {
        //        var barbearias = await _service.GetAllBarbeariasAsync();

        //        return _mapper.Map<IEnumerable<BarbeariasResponseDto>>(barbearias);

        //    }catch (Exception)
        //    {
        //        throw new Exception();
        //    }
        //}
        
        public async Task<BarbeariasResponseDto> GetAllAtributesBarbeariaAsyncById(int idBarbearia)
        {
            try
            {
                var barbearia = await _serviceBarbearia.GetBarbeariaAsyncById(idBarbearia);

                var barbeariaDto =  _mapper.Map<BarbeariasResponseDto>(barbearia);
               
                return barbeariaDto;
            }
            catch (Exception) 
            {
                throw new Exception();
            }
        }

        public async Task<BarbeariasCompleteResponseDto> PostBarbeariaAsync(BarbeariasRequestDto barbeariaDto)
        {
            try
            {
                var barbearia = _mapper.Map<Barbearias>(barbeariaDto);

                await _serviceBarbearia.PostBarbeariaAsync(barbearia);

                var b = await _serviceBarbearia.GetBarbeariaAsyncById(barbearia.IdBarbearia);



                return _mapper.Map<BarbeariasCompleteResponseDto>(b);

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
