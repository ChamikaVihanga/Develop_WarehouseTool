

namespace auth.workspace.Server.Authorization
{
    public class CustomClaimRequirement : IAuthorizationRequirement
    {
        public string RequrementName { get; set; }
        public CustomClaimRequirement(string Requirement)
        {
            RequrementName = Requirement;
        }
    }
}
