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
            //var claimRequirementSTEST = _context.AuthenticationClaimRequirements.Where(b => b.Uri == EndPoint).Count();
            //if (claimRequirementSTEST == 0)
            //{
            //    AuthenticationClaimRequirement _ClaimRequirement = new AuthenticationClaimRequirement();
            //    _ClaimRequirement.Uri = EndPoint;
            //    //int methodId = _context.Authentication_HttpMethod.Where(a => a.HttpMethod == Method).ToList().Select(c => c.Id).Last();
            //    var httpMethod = await _context.AuthenticationHttpMethods.Where(a => a.HttpMethod == Method).ToListAsync();
            //    _ClaimRequirement.AuthenticationHttpMethodsId = httpMethod.Select(v => v.Id).LastOrDefault();
            //    _ClaimRequirement.beenReviewed = false;
            //    _ClaimRequirement.IsActive = true;



            //    _context.AuthenticationClaimRequirements.Add(_ClaimRequirement);
            //    await _context.SaveChangesAsync();

            //}
            //var httpMethodId = await _context.AuthenticationHttpMethods.Where(a => a.HttpMethod == Method).ToListAsync();
            //var claims = await _context.AuthenticationClaimRequirements.Where(a => a.Uri == EndPoint && a.AuthenticationHttpMethodsId == httpMethodId.Select(b => b.Id).LastOrDefault()).Include(x => x.authenticationClaimValues).ThenInclude(x => x.AuthenticationClaim).ToListAsync();

            //return claims;
            var claims = await _claimProviderService.GetClaims(EndPoint, Method);
            return claims;


        }
    }
}
