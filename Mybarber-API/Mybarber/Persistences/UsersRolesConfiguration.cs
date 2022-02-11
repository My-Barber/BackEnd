using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mybarber.Models;

namespace Mybarber.Persistences
{
    public class UsersRolesConfiguration : IEntityTypeConfiguration<UsersRoles>
    {
        public void Configure(EntityTypeBuilder<UsersRoles> builder)
        {
            builder.HasKey(x => new { x.UserId, x.RoleId });
        }
    }
}
