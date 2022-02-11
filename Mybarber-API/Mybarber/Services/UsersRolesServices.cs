using Mybarber.Models;
using Mybarber.Repository;
using Mybarber.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Mybarber.Services
{
    public class UsersRolesServices: IUsersRolesServices
    {
        private readonly IGenerallyRepository _generally;

        public UsersRolesServices(IGenerallyRepository generally)
        {

            this._generally = generally;
        }
        public async Task<UsersRoles> PostUsersRolesAsync(UsersRoles usersRoles)
        {
            try
            {
                _generally.Add(usersRoles);

                if (await _generally.SaveChangesAsync())
                {

                    return usersRoles;
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
