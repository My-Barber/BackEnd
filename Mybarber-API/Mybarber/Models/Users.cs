using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mybarber.Models
{
    public class Users
    {
        [Key()]
        public int IdUser { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }    
        
        public ICollection<UsersRoles> UsersRoles { get; set; }

        public Barbearias Barbearias { get; set; }

        public int BarbeariasId { get; set; }

        public Users(string username, string email, int barbeariasId)
        {
            this.Username = username;
            this.Email = email;
            this.BarbeariasId = barbeariasId;
        }
        public Users()
        {
                
        }

       
    }
}
