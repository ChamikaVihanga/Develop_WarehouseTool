

namespace auth.workspace.Server.Authorization.DataProviders
{
    public class CustomClaimChecker : ICustomClaimChecker
    {
        private readonly WorkspaceDbContext _context;
        public CustomClaimChecker(WorkspaceDbContext context)
        {
            _context = context;
        }
       
        public async Task<List<AuthenticationClaimRequirement>> getClaimRequirement(string EndPoint, string Method, QueryString queryString)
        {
           
            var claimRequirementSTEST = _context.AuthenticationClaimRequirements.Where(b => b.Uri == EndPoint).Count();
            if (claimRequirementSTEST == 0)
            {
                AuthenticationClaimRequirement _ClaimRequirement = new AuthenticationClaimRequirement();
                _ClaimRequirement.Uri = EndPoint;
                //int methodId = _context.Authentication_HttpMethod.Where(a => a.HttpMethod == Method).ToList().Select(c => c.Id).Last();
                var httpMethod = await _context.AuthenticationHttpMethods.Where(a => a.HttpMethod == Method).ToListAsync();
                _ClaimRequirement.AuthenticationHttpMethodsId = httpMethod.Select(v => v.Id).LastOrDefault();
                _ClaimRequirement.beenReviewed = false;
                _ClaimRequirement.IsActive = true;
           
                

                _context.AuthenticationClaimRequirements.Add(_ClaimRequirement);
                await _context.SaveChangesAsync();  

            }
            var httpMethodId = await _context.AuthenticationHttpMethods.Where(a => a.HttpMethod == Method).ToListAsync();
            var claims = await _context.AuthenticationClaimRequirements.Where(a => a.Uri == EndPoint && a.AuthenticationHttpMethodsId == httpMethodId.Select(b => b.Id).LastOrDefault()).Include(x => x.authenticationClaimValues).ThenInclude(x => x.AuthenticationClaim).ToListAsync();
         
            return claims;
        }

    }
}
