using Workspace.Server.Services.ClaimProviderService;
using Workspace.Shared.AuthData;

namespace Workspace.Server.AuthorizationService.CustomPolicyDataProvider
{
    public class CustomPolicyDataProvider : ICustomPolicyDataProvider
    {
        private readonly WorkspaceDbContext _context;
        private readonly IClaimProviderService _claimProviderService;
        public CustomPolicyDataProvider(WorkspaceDbContext workspaceDbContext, IClaimProviderService claimProviderService)
        {
            _context = workspaceDbContext;
            _claimProviderService = claimProviderService;
        }
        public async Task<List<AuthenticationClaimRequirement>> getClaimRequirement(string EndPoint, string Method)
        {
            
            var claims = await _claimProviderService.GetClaims(EndPoint, Method);
            return claims;


        }
    }
}
