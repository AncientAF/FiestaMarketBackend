using FiestaMarketBackend.Core.Enums;
using Microsoft.AspNetCore.Authorization;

namespace FiestaMarketBackend.Infrastructure.Authentication
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public PermissionEnum[] Permissions { get; set; } = [];

        public PermissionRequirement(PermissionEnum[] permissions)
        {
            Permissions = permissions;
        }
    }
}
