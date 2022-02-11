using Mybarber.Models;
using Mybarber.Repository;
using Mybarber.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public class RolesServices : IRolesServices
    {
        private readonly IGenerallyRepository _generally;

        public RolesServices(IGenerallyRepository generally)
        {
            
            this._generally = generally;
        }

        public async Task<Roles> PostRolesAsync(Roles role)
        {
            try
            {
                _generally.Add(role);

                if (await _generally.SaveChangesAsync())
                {

                    return role;
                }
                else
                {
                    throw new InvalidOperationException("Operação falhou");
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
