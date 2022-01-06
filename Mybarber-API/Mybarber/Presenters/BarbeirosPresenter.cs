using AutoMapper;
using Mybarber.DataTransferObject.Barbeiro;
using Mybarber.Models;
using Mybarber.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Presenter
{
    public class BarbeirosPresenter : IBarbeirosPresenter
    {
        private readonly IMapper _mapper;
        private readonly IBarbeirosServices _service;
        public BarbeirosPresenter(IBarbeirosServices service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }


        //public async Task<IEnumerable<BarbeirosResponseDto>> GetAllBarbeirosAsync()
        //{
        //    try
        //    {
        //        var barbeiros = await _service.GetAllBarbeirosAsync();

        //        return _mapper.Map<IEnumerable<BarbeirosResponseDto>>(barbeiros);

        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception();
        //    }
        //}

        public async Task<BarbeirosResponseDto> GetBarbeiroAsyncById(int idBarbeiro)
        {
            try
            {
                var barbeiro = await _service.GetBarbeiroAsyncById(idBarbeiro);

                return _mapper.Map<BarbeirosResponseDto>(barbeiro);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<BarbeirosResponseDto> GetBarbeiroAsyncByTenant(int idBarbearia)
        {
            try
            {
                var barbeiros = await _service.GetBarbeiroAsyncByTenant(idBarbearia);

                return  _mapper.Map<BarbeirosResponseDto>(barbeiros); 
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<BarbeirosCompleteResponseDto> PostBarbeiroAsync(BarbeirosRequestDto barbeiroDto)
        {
            try
            {
                var barbeiro = _mapper.Map<Barbeiros>(barbeiroDto);

                await _service.PostBarbeiroAsync(barbeiro);

                var b = await _service.GetBarbeiroAsyncById(barbeiro.IdBarbeiro);



                return _mapper.Map<BarbeirosCompleteResponseDto>(b);

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
