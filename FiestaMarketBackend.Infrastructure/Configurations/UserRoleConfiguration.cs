using FiestaMarketBackend.Core.Entities;
using FiestaMarketBackend.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiestaMarketBackend.Infrastructure.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasMany(r => r.Permissions).WithMany(u => u.Roles)
                .UsingEntity<RolePermission>(l => l.HasOne<Permission>().WithMany().HasForeignKey(e => e.PermissionId),
                r => r.HasOne<UserRole>().WithMany().HasForeignKey(e => e.RoleId));

            var roles = Enum.GetValues<Role>().Select(r => new UserRole
            {
                Id = (int)r,
                Name = r.ToString()
            });

            builder.HasData(roles);
        }
    }
}
