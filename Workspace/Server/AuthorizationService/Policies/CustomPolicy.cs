using Microsoft.AspNetCore.Authorization;

namespace Workspace.Server.AuthorizationService.Policies
{
    public class CustomPolicy : IAuthorizationRequirement
    {
        public string RequrementName { get; set; }
        public CustomPolicy(string Requirement)
        {
            RequrementName = Requirement;
        }
    }
}
