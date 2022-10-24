
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace admin.workspace.Server.Controllers.AuthenticationControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationClaimsController : ControllerBase
    {
        public WorkspaceDbContext _context { get; set; }
        public AuthenticationClaimsController(WorkspaceDbContext context)
        {
            _context = context;
        }

        [HttpGet, Authorize(Policy = "VSPolicy")]
        public async Task<ActionResult<List<AuthenticationClaim>>> Get()
        {
            if (_context.AuthenticationClaims is null)
            {
                return NotFound();
            }
            return await _context.AuthenticationClaims.Include(i => i.AuthenticationClaimValues).ToListAsync(); 
        }


        //route api/AuthenticationClaims/AddClaimsWithValues
        [HttpPost, Route("AddClaimsWithValues"), Authorize(Policy = "VSPolicy")]
        public async Task<ActionResult> AddClaimsWithValues(DataTransferObject.ClaimValueDTO claimValueDTO)
        {
            if (claimValueDTO is null)
            {
                return BadRequest();
            }

            AuthenticationClaim authentication_Claim = new AuthenticationClaim();
            AuthenticationClaimValue authentication_ClaimValue = new AuthenticationClaimValue();

            if(claimValueDTO.ClaimId is null)
            {
                authentication_Claim.Claim = claimValueDTO.newClaimName;
                authentication_Claim.IsActive = true;

                await _context.AuthenticationClaims.AddAsync(authentication_Claim);
                await _context.SaveChangesAsync();

                claimValueDTO.ClaimId = authentication_Claim.ClaimId;


                //claimValueDTO.ClaimId = _context.authentication_Claims.Where(a => a.Claim == claimValueDTO.newClaimName).Select(x => x.ClaimId).ToList().Last();
            }
           
          
            foreach (string Value in claimValueDTO.Values)
            {
                authentication_ClaimValue.AuthenticationClaimId = claimValueDTO.ClaimId;
                authentication_ClaimValue.Value = Value;
                if (authentication_ClaimValue.ClaimValueId != 0)
                {
                    
                    authentication_ClaimValue.ClaimValueId = 0;
                }
                await _context.AuthenticationClaimValues.AddAsync(authentication_ClaimValue);
                await _context.SaveChangesAsync();
               
            }
            return Ok();

        }

        [HttpPost, Route("DeleteClaimsOrValues"), Authorize(Policy = "VSPolicy")]
        public async Task<ActionResult<string>> DeleteClaimsOrValues(DataTransferObject.ClaimValues claim)
        {
            if (claim.ClaimId is not null && claim.ValueId is not null)
            {
                var value = await _context.AuthenticationClaimValues.FindAsync(claim.ValueId);
                if (value == null)
                {
                    return NotFound();
                }
                _context.AuthenticationClaimValues.Remove(value);
                await _context.SaveChangesAsync();
                return Ok();

            }
            if (claim.ValueId is null)
            {
                var Claim = await _context.AuthenticationClaims.FindAsync(claim.ClaimId);
                var values = await _context.AuthenticationClaimValues.Where(a => a.AuthenticationClaimId == claim.ClaimId).ToListAsync();

                if (values != null)
                {
                    try
                    {
                        foreach (var value in values)
                        {
                            _context.AuthenticationClaimValues.Remove(value);
                            await _context.SaveChangesAsync();
                        }
                       
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message.ToString());
                    }

                }
                if (claim.ClaimId is not null)
                {
                    _context.AuthenticationClaims.Remove(Claim);
                    await _context.SaveChangesAsync();
                }
                return Ok();



            }
            return BadRequest();

        }
 
    }
}
