
using Microsoft.AspNetCore.Mvc.Filters;

namespace admin.workspace.Server.Authorization.Handlers
{
    public class CustomClaimCheckerHandler : AuthorizationHandler<CustomClaimRequirement>
    {
        private readonly ICustomClaimChecker _customClaimChecker;
        private readonly IHttpContextAccessor _contextAccessor;

        public CustomClaimCheckerHandler(ICustomClaimChecker customClaimChecker, IHttpContextAccessor contextAccessor)
        {
            _customClaimChecker = customClaimChecker;
            _contextAccessor = contextAccessor;
        }
        protected async override Task<Task> HandleRequirementAsync(AuthorizationHandlerContext context, CustomClaimRequirement requirement)
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




            List<AuthenticationClaimRequirement> claimRequirements = await _customClaimChecker.getClaimRequirement(RequestString, Method, queryString);
            
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
