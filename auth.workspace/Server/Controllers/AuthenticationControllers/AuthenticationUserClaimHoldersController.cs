using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace admin.workspace.Server.Controllers.AuthenticationControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationUserClaimHoldersController : ControllerBase
    {
        private readonly WorkspaceDbContext _context;

        public AuthenticationUserClaimHoldersController(WorkspaceDbContext context)
        {
            _context = context;

        }

        [HttpGet, Authorize(Policy ="VSPolicy")]
        public async Task<ActionResult<AuthenticationUserClaimsHolder>> GetUsers(string? UserName)
        {
            var user = _context.AuthenticationUserClaimsHolders
                .Where(a => a.UserName == UserName)
                .Include(a => a.authenticationClaimValues)
                .ThenInclude(b => b.AuthenticationClaim).ToList();

            if (user.Count > 0 && user != null)
            {
                return user.LastOrDefault();
            }
            return BadRequest();

        }

        [HttpPost, Route("AddDomainUser"), Authorize(Policy = "VSPolicy")]
        public async Task<ActionResult<string>> AddDomainUser(AuthenticationUserClaimsHolder username)
        {
            try
            {
                await _context.AddAsync(username);
                await _context.SaveChangesAsync();
                return Ok("User has been added.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
            

        }

        [HttpGet, Route("GetUsersList"), Authorize(Policy = "VSPolicy")]
        public async Task<ActionResult<List<AuthenticationUserClaimsHolder>>> GetUsersList()
        {
            try
            {
                return _context.AuthenticationUserClaimsHolders
                    .ToList();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        

        [HttpPost, Route("AddClaimValuesToUser"), Authorize(Policy = "VSPolicy")]
        public async Task<ActionResult<string>> AddClaimValuesToUser(DataTransferObject.ClaimValues Values)
        {
            AuthenticationClaimValue? ClaimValue = _context.AuthenticationClaimValues.Single(p => p.ClaimValueId == Values.ValueId);

            AuthenticationUserClaimsHolder? authentication_UserClaimHolder = await _context.AuthenticationUserClaimsHolders
                .Include(a => a.authenticationClaimValues)
                .SingleAsync(b => b.UserName == Values.username);

            if (authentication_UserClaimHolder is not null && ClaimValue is not null)
            {
                try
                {
                    authentication_UserClaimHolder.authenticationClaimValues.Add(ClaimValue);
                    await _context.SaveChangesAsync();
                    return Ok("Success.");
                }
                catch(Exception ex)
                {
                    return BadRequest(ex);
                }
                
            }
            return Ok();
        }

        [HttpPost, Route("DeleteClaimsFromUsers"), Authorize(Policy = "VSPolicy")]
        public async Task<ActionResult<string>> DeleteClaimsFromUsers(DataTransferObject.ClaimValues claimValues)
        {
            try
            {

                if (claimValues.ValueId is not null)
                {
                    AuthenticationUserClaimsHolder? user = await _context.AuthenticationUserClaimsHolders.Include(b => b.authenticationClaimValues).SingleAsync(a => a.UserName == claimValues.username);
                    AuthenticationClaimValue? value = await _context.AuthenticationClaimValues.FindAsync(claimValues.ValueId);
                    if (user.authenticationClaimValues != null && value != null)
                    {
                        user.authenticationClaimValues.Remove(value);
                        await _context.SaveChangesAsync();
                        return Ok($"{value.Value} removed.");
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }

            return BadRequest();

        }
    }
}
