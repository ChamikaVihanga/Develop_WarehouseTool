using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace admin.workspace.Server.Controllers.AuthenticationControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationPolicyRequirementController : ControllerBase
    {
        private readonly WorkspaceDbContext _context;

        public AuthenticationPolicyRequirementController(WorkspaceDbContext context)
        {
            _context = context;
        }

        [HttpGet, Route("GetAllRequirements"), Authorize(Policy = "VSPolicy")]
        public async Task<ActionResult<List<AuthenticationClaimRequirement>>> GetAllRequirements()
        {
            
            if (_context.AuthenticationClaimRequirements == null)
            {
                return BadRequest();
            }
            else
            {
                return await _context.AuthenticationClaimRequirements
                    .Include(v => v.AuthenticationHttpMethods)
                    .Include(v => v.authenticationClaimValues)
                    .ThenInclude(v => v.AuthenticationClaim)
                    .ToListAsync();
            }

        }

        [HttpGet, Authorize(Policy = "VSPolicy")]
        public async Task<ActionResult<AuthenticationClaimRequirement>> GetAllRequirement(int? id)
        {
            if (_context.AuthenticationClaimRequirements == null)
            {
                return BadRequest();
            }
            else
            {
                if (id == null)
                {
                    return NotFound();
                }
                else
                {
                    return await _context.AuthenticationClaimRequirements
                    .Where(x => x.RequirementId == id)
                    .Include(c => c.AuthenticationADAssignedGroups)
                    .Include(a => a.authenticationClaimValues)
                    .ThenInclude(a => a.AuthenticationClaim).FirstOrDefaultAsync();
                }
                
            }


        }
        [HttpPut, Route("ReviewPath"), Authorize(Policy = "VSPolicy")]
        public async Task UpdateRecords(int id, AuthenticationClaimRequirement authenticationClaimRequirement)
        {
            var current = _context.AuthenticationClaimRequirements.FirstOrDefault(x => x.RequirementId == id);
            current.RequirementName = authenticationClaimRequirement.RequirementName;
            current.beenReviewed = authenticationClaimRequirement.beenReviewed;
            current.description = authenticationClaimRequirement.description;

            _context.Update(current);
            await _context.SaveChangesAsync();
        }

        [HttpPost, Route("AddEnd-Point"), Authorize(Policy = "VSPolicy")]
        public async Task<ActionResult> AddEndPoint(AuthenticationClaimRequirement requirement)
        {
            List<string> authentication_ClaimRequirements = await _context.AuthenticationClaimRequirements.Select(a => a.RequirementName).ToListAsync();

            if (!authentication_ClaimRequirements.Contains(requirement.RequirementName)) 
            { 
                AuthenticationClaimRequirement authentication_ClaimRequirement = new AuthenticationClaimRequirement() { RequirementName = requirement.RequirementName, IsActive=true };
                _context.AuthenticationClaimRequirements.Add(authentication_ClaimRequirement);
                await _context.SaveChangesAsync();
                return Ok($"Successfully Added End-Point, {requirement.RequirementName}");
            }
            else
            {
                return BadRequest($"{requirement.RequirementName}, End-Point has been configured!");
            }

        }


        [HttpPost, Route("BindClaimValues")]
        public async Task<ActionResult<string>> AddClaimsToRequirements(DataTransferObject.ClaimValueDTO claimValueDTO)
        {
            try
            {
                AuthenticationClaimRequirement Requirement = _context.AuthenticationClaimRequirements
                    .Include(a => a.authenticationClaimValues)
                    .Single(b => b.RequirementId == claimValueDTO.RequirementId);

                AuthenticationClaimValue ClaimValue = _context.AuthenticationClaimValues.Single(p => p.ClaimValueId == claimValueDTO.ValueId);
                Requirement.authenticationClaimValues.Add(ClaimValue);
                await _context.SaveChangesAsync();

                return Ok("Success.");
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            
        }

        [HttpPost, Route("DeleteBindValues"), Authorize(Policy ="VSPolicy")]
        public async Task<ActionResult<string>> DeleteBindValues(DataTransferObject.ClaimValueDTO claimValueDTO)
        {
            AuthenticationClaimRequirement Requirement = _context.AuthenticationClaimRequirements.Include(a => a.authenticationClaimValues).Single(b => b.RequirementId == claimValueDTO.RequirementId);
            if (claimValueDTO.RequirementId is not null && claimValueDTO.ValueId is null)
            {
                _context.AuthenticationClaimRequirements.Remove(Requirement);
                await _context.SaveChangesAsync();
                return Ok("Requirement has been deleted.");
            }
            try
            {
                
                AuthenticationClaimValue ClaimValue = _context.AuthenticationClaimValues.Single(p => p.ClaimValueId == claimValueDTO.ValueId);
                Requirement.authenticationClaimValues.Remove(ClaimValue);
                await _context.SaveChangesAsync();

                return Ok("Success.");
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

    }
}
