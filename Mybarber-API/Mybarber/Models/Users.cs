using System.ComponentModel.DataAnnotations;

namespace Mybarber.Models
{
    public class Users
    {
        [Key()]
        public int IdUser { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public Barbearias barbearias { get; set; }

        public int BarbeariasId { get; set; }


        public Users()
        {
                
        }
    }
}
