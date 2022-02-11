using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mybarber.Models
{
    public class Roles
    {
        [Key()]
       public int IdRole { get; set; }
        public string RoleName { get; set; }
        public int RoleStrength { get; set; }
        public ICollection<UsersRoles> UsersRoles { get; set; }

       

    }
}
