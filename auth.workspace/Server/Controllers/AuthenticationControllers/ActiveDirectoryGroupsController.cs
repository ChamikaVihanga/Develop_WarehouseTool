
using admin.workspace.Server.ActiveDirectoryAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.DirectoryServices.AccountManagement;

namespace admin.workspace.Server.Controllers.AuthenticationControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActiveDirectoryGroupsController : ControllerBase
    {
        public WorkspaceDbContext _context { get; set; }
        public ActiveDirectoryGroupsController(WorkspaceDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<List<AuthenticationADGroupModal>> getADGroups()
        {
            
            ADAccessProvider accessProvider = new ADAccessProvider();
            return await accessProvider.ADGroups();

        }

        [HttpPost, Route("BindADGroupsToEndPoints"), Authorize(Policy = "VSPolicy")]
        public async Task BindAdGroupsWithEndPoints(HashSet<DataTransferObject.TransferAdGroups> transferAdGroups, int endpointId)
        {
            int EndPointId = endpointId;
            var endPoint = await _context.AuthenticationClaimRequirements.Where(a => a.RequirementId == EndPointId).Include(a => a.AuthenticationADAssignedGroups).FirstOrDefaultAsync();

            endPoint?.AuthenticationADAssignedGroups?.Clear();
            await _context.SaveChangesAsync();

            foreach (DataTransferObject.TransferAdGroups adGroup in transferAdGroups)
            {
                AuthenticationADAssignedGroup? authenticationADAssignedGroup = await _context.AuthenticationADAssignedGroups.Where(a => a.ADGroupGuid == adGroup.AdGroupGuid).FirstOrDefaultAsync();
                //AuthenticationClaimRequirement authenticationClaimRequirement = await _context.AuthenticationClaimRequirements.FindAsync(adGroup.EndPointId);
                //AuthenticationClaimRequirement? authenticationClaimRequirement = await _context.AuthenticationClaimRequirements.Where(a => a.RequirementId == adGroup.EndPointId).Include(a =>a.AuthenticationADAssignedGroups).FirstAsync();
                if (authenticationADAssignedGroup == null)
                {
                    authenticationADAssignedGroup = new AuthenticationADAssignedGroup (){ ADGroupGuid = adGroup.AdGroupGuid };
                    _context.AuthenticationADAssignedGroups.Add(authenticationADAssignedGroup);
                    await _context.SaveChangesAsync();

                }
                authenticationADAssignedGroup = await _context.AuthenticationADAssignedGroups.Where(a => a.ADGroupGuid == adGroup.AdGroupGuid).FirstOrDefaultAsync();
                if(authenticationADAssignedGroup != null)
                {
                    endPoint.AuthenticationADAssignedGroups?.Add(authenticationADAssignedGroup);
                    await _context.SaveChangesAsync();
                }
                
            }


        }

    }
}
