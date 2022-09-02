using admin.workspace.Server.Authorization.DataProviderInterfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace admin.workspace.Server.Authorization.Handlers
{
    public class EmployeesWithXPHandler : AuthorizationHandler<UsersWithITClaimAnd2YearsExpRequirement>
    {
        private readonly IEmpNumberOfYears _empNumberOfYears;
        public EmployeesWithXPHandler(IEmpNumberOfYears empNumberOfYears)
        {
            _empNumberOfYears = empNumberOfYears;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UsersWithITClaimAnd2YearsExpRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.Name ))
            {
                return Task.CompletedTask;
            }
            var username = context.User.FindAll(c => c.Type == ClaimTypes.Name).FirstOrDefault();
            var yearsofXP = _empNumberOfYears.GetXP(username.Value);

            if (yearsofXP >= requirement.years)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;

        }
    }
}
