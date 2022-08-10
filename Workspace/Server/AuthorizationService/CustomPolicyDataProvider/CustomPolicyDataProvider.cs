using Workspace.Shared.Auth;

namespace Workspace.Server.AuthorizationService.CustomPolicyDataProvider
{
    public class CustomPolicyDataProvider : ICustomPolicyDataProvider
    {
        private readonly AuthDbContext _context;
        public CustomPolicyDataProvider(AuthDbContext authDbContext)
        {
            _context = authDbContext;
        }
        public List<AuthenticationClaimRequirement> getClaimRequirement(string ClaimName)
        {
            var claims = _context.AuthenticationClaimRequirements.Where(a => a.RequirementName == ClaimName).Include(x => x.AuthenticationClaimValuesClaimValues).ThenInclude(x => x.AuthenticationClaim).ToList();

            return claims;
        }
    }
}
