using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace auth.workspace.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimFilterController : ControllerBase
    {
        public WorkspaceDbContext _context { get; set; }
        public ClaimFilterController(WorkspaceDbContext context)
        {
             _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthenticationClaimRequirement>>> Get(string path, string method)
        {
            var claimRequirementSTEST = _context.AuthenticationClaimRequirements.Where(b => b.Uri == path).Count();
            if (claimRequirementSTEST == 0)
            {
                AuthenticationClaimRequirement _ClaimRequirement = new AuthenticationClaimRequirement();
                _ClaimRequirement.Uri = path;
                //int methodId = _context.Authentication_HttpMethod.Where(a => a.HttpMethod == Method).ToList().Select(c => c.Id).Last();
                var httpMethod = await _context.AuthenticationHttpMethods.Where(a => a.HttpMethod == method).ToListAsync();
                _ClaimRequirement.AuthenticationHttpMethodsId = httpMethod.Select(v => v.Id).LastOrDefault();
                _ClaimRequirement.beenReviewed = false;
                _ClaimRequirement.IsActive = true;



                _context.AuthenticationClaimRequirements.Add(_ClaimRequirement);
                await _context.SaveChangesAsync();

            }
            var httpMethodId = await _context.AuthenticationHttpMethods.Where(a => a.HttpMethod == method).ToListAsync();
            var claims = await _context.AuthenticationClaimRequirements.Where(a => a.Uri == path && a.AuthenticationHttpMethodsId == httpMethodId.Select(b => b.Id).LastOrDefault()).Include(x => x.authenticationClaimValues).ThenInclude(x => x.AuthenticationClaim).ToListAsync();

            return claims;
        }

    }
}
