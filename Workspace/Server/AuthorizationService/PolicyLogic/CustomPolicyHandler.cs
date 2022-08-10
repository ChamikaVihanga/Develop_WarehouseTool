using Microsoft.AspNetCore.Authorization;
using Workspace.Server.AuthorizationService.CustomPolicyDataProvider;
using Workspace.Server.AuthorizationService.Policies;
using Workspace.Shared.Auth;

namespace Workspace.Server.AuthorizationService.PolicyHandler
{
    public class CustomPolicyHandler : AuthorizationHandler<CustomPolicy>
    {
        private readonly ICustomPolicyDataProvider _customPolicyDataProvider;
        private readonly IHttpContextAccessor _contextAccessor;
        public CustomPolicyHandler(ICustomPolicyDataProvider customPolicyDataProvider, IHttpContextAccessor contextAccessor)
        {
            _customPolicyDataProvider = customPolicyDataProvider;
            _contextAccessor = contextAccessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomPolicy requirement)
        {
            HttpContext httpContext = _contextAccessor.HttpContext;
            var RequestString = httpContext.Request.Path.Value.ToString();
            var Method = httpContext.Request.Method.ToString();
            
            List<AuthenticationClaimRequirement> claimRequirements = _customPolicyDataProvider.getClaimRequirement($"{RequestString}::{Method}");

            if (claimRequirements == null)
            {
                return Task.CompletedTask;
            }
            foreach (AuthenticationClaimRequirement claimRequirement in claimRequirements)
            {
                if (claimRequirement.AuthenticationClaimValuesClaimValues == null)
                {
                    return Task.CompletedTask;
                }
                else
                {
                    foreach (var claimValue in claimRequirement.AuthenticationClaimValuesClaimValues)
                    {
                        if (claimValue.AuthenticationClaim == null)
                        {
                            return Task.CompletedTask;
                        }
                        if (!context.User.HasClaim(c => c.Type == claimValue.AuthenticationClaim.Claim && c.Value == claimValue.Value))
                        {
                            return Task.CompletedTask;
                        }
                    }

                }
            }
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
