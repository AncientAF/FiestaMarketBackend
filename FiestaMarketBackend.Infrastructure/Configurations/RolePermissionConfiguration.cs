using FiestaMarketBackend.Core.Entities;
using FiestaMarketBackend.Core.Enums;
using FiestaMarketBackend.Infrastructure.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiestaMarketBackend.Infrastructure.Configurations
{
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        private readonly AuthOptions _options;

        public RolePermissionConfiguration(AuthOptions options)
        {
            _options = options;
        }

        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasKey(rp => new { rp.RoleId, rp.PermissionId });

            builder.HasData(ParseRolePermissions());
        }

        private RolePermission[] ParseRolePermissions()
        {
            return _options.RolePermissions
                .SelectMany(rp => rp.Permissions
                .Select(p => new RolePermission
                {
                    RoleId = (int)Enum.Parse<Role>(rp.Role),
                    PermissionId = (int)Enum.Parse<PermissionEnum>(p)
                }))
                .ToArray();
        }
    }
}
