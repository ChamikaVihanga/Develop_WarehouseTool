using Microsoft.AspNetCore.Authorization;
using Workspace.Server.AuthorizationService.CustomPolicyDataProvider;
using Workspace.Server.AuthorizationService.Policies;
using Workspace.Shared.AuthData;

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
        protected async override Task<Task> HandleRequirementAsync(AuthorizationHandlerContext context, CustomPolicy requirement)
        {
            HttpContext httpContext = _contextAccessor.HttpContext;
            var RequestString = httpContext.Request.Path.Value.ToString();
            var Method = httpContext.Request.Method.ToString();

            QueryString queryString = QueryString.Empty;
            if (httpContext.Request.QueryString != QueryString.Empty)
            {
                queryString = httpContext.Request.QueryString;
                RequestString = RequestString.Replace(queryString.ToString(), "");
            }


            List<AuthenticationClaimRequirement> claimRequirements = await _customPolicyDataProvider.getClaimRequirement(RequestString, Method);

            if (claimRequirements == null)
            {
                return Task.CompletedTask;
            }
            foreach (AuthenticationClaimRequirement claimRequirement in claimRequirements)
            {
                if (claimRequirement.authenticationClaimValues == null)
                {
                    return Task.CompletedTask;
                }
                else
                {
                    foreach (var claimValue in claimRequirement.authenticationClaimValues)
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
