namespace Mybarber.Models
{
    public class UsersRoles
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public Roles Roles { get; set; }
        public Users Users { get; set; }
        public int BarbeariasId { get; set; }
        public virtual Barbearias Barbearias { get; set; }


    }
}
