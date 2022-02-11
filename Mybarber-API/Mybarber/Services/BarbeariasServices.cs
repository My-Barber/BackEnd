using Mybarber.Exceptions;
using Mybarber.Exceptions.Tradutor;
using Mybarber.Models;

using Mybarber.Repository;
using Mybarber.Validations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Mybarber.Exceptions.BusinessException;
using static Mybarber.Exceptions.ViewException;

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
                if(ValidaCNPJ.IsCnpj(barbearias.CNPJ) == false)
                    throw new CNPJException(TraslateExceptions.CNPJInvalido);


               _generally.Add(barbearias);

                if (await _generally.SaveChangesAsync())
                {
                    
                    return barbearias;
                }
                else
                {
                    throw new DbException(TraslateExceptions.NotSaved);
                }
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }
        public async Task<string> DeleteBarbeariaAsyncById(int idBarbearia)
        {
            try
            {
                var barbeariaFinded = await _repo.GetBarbeariasAsyncById(idBarbearia);

                if (barbeariaFinded == null) { throw new Exception(); }


                _generally.Delete(barbeariaFinded);

                if (await _generally.SaveChangesAsync())
                {

                    return "Barbearia Deletado Com sucesso.";
                }
                else
                {
                    throw new InvalidOperationException("Operação falhou");
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
