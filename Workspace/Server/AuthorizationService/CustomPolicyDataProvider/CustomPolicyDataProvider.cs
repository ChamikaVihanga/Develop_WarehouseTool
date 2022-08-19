using Workspace.Shared.AuthData;

namespace Workspace.Server.AuthorizationService.CustomPolicyDataProvider
{
    public class CustomPolicyDataProvider : ICustomPolicyDataProvider
    {
        private readonly WorkspaceDbContext _context;
        public CustomPolicyDataProvider(WorkspaceDbContext workspaceDbContext)
        {
            _context = workspaceDbContext;
        }
        public List<AuthenticationClaimRequirement> getClaimRequirement(string ClaimName)
        {
            List<AuthenticationClaimRequirement> claims = _context.AuthenticationClaimRequirements.Where(x => x.Uri == ClaimName).Include(y => y.authenticationClaimValues).ThenInclude(a => a.AuthenticationClaim).ToList();

            return claims;
        }
    }
}
