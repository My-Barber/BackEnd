using Mybarber.Models;

using Mybarber.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public class BarbeariasServices : IBarbeariasServices
    {

        private readonly IBarbeariasRepository _repo;

        private readonly IGenerallyRepository _generally;

        public BarbeariasServices(IBarbeariasRepository repo, IGenerallyRepository generally)
        {
            this._repo = repo;
            this._generally = generally;
        }

        //public async Task<IEnumerable<Barbearias>> GetAllBarbeariasAsync()
        //{
        //    try
        //    {
        //        var barbearias = await _repo.GetAllBarbeariasAsync();

        //        return barbearias;

        //    }catch(Exception)
        //    {
        //        throw new Exception();
        //    }
        //}

        public async Task<Barbearias> GetBarbeariaAsyncById(int idBarbearia)
        {
            try 
            {
                var barbearia = await _repo.GetBarbeariasAsyncById(idBarbearia);

                return barbearia;

            }catch(Exception)
            {
                throw new Exception();
            }
        }

        public async Task<Barbearias> PostBarbeariaAsync(Barbearias barbearias)
        {
            try
            {
                _generally.Add(barbearias);

                if (await _generally.SaveChangesAsync())
                {
                    
                    return barbearias;
                }
                else
                {
                    throw new InvalidOperationException("Operação falhou");
                }
            }
            catch (Exception )
            {
                throw new Exception();
            }
        }
    }
}
