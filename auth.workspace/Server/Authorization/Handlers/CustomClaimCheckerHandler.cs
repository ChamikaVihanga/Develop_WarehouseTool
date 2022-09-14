
using Microsoft.AspNetCore.Mvc.Filters;
using static Workspace.Shared.AuthData.DataTransferObject;

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

        
            if (claimRequirements.Count == null)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
            foreach (AuthenticationClaimRequirement claimRequirement in claimRequirements)
            {
                if (claimRequirement.authenticationClaimValues.Count == 0 && claimRequirement.AuthenticationADAssignedGroups.Count == 0)
                {
                    context.Succeed(requirement);
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
                        if (context.User.HasClaim(c => c.Type == claimValue.AuthenticationClaim.Claim && c.Value == claimValue.Value))
                        {
                            context.Succeed(requirement);
                            return Task.CompletedTask;
                        }
                        
                    }
                    if (claimRequirement?.AuthenticationADAssignedGroups?.Count > 0)
                    {
                        foreach (var adGroup in claimRequirement.AuthenticationADAssignedGroups)
                        {
                            if(context.User.HasClaim(c => c.Type == "ActiveDirectoryGroups" && c.Value == adGroup.ADGroupGuid.ToString()))
                            {
                                context.Succeed(requirement);
                                return Task.CompletedTask;
                            }
                        }
                    }
                   
                }
            }
           

            return Task.CompletedTask;
        }

       
    }
    public class CheckClaims
    {
        public string ClaimName { get; set; }
        public bool Matched { get; set; } = false;
    }
}
