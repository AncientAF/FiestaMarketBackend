using FiestaMarketBackend.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace FiestaMarketBackend.Infrastructure.Authentication
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly IServiceScopeFactory _serviceScope;

        public PermissionAuthorizationHandler(IServiceScopeFactory serviceScope)
        {
            _serviceScope = serviceScope;
        }

        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            var userId = context.User.Claims
                .FirstOrDefault(c => c.Type == CustomClaims.UserId);

            if (userId is null || !Guid.TryParse(userId.Value, out var id))
                return;

            using var scope = _serviceScope.CreateScope();

            var userRepo = scope.ServiceProvider.GetRequiredService<UserRepository>();

            var permissions = await userRepo.GetUserPermissions(id);

            if (permissions.Intersect(requirement.Permissions).Any())
                context.Succeed(requirement);

        }
    }
}
