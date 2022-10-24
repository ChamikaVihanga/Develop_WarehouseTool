using ApprovalPath_Utils.Services.ApprovalDestinationPathsService;
using ApprovalPath_Utils.Services.ApprovalJobManagerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workspace.Shared.Entities.ApprovalDynamicPaths;

namespace admin.workspace.Server.Controllers.ApprovalPath_Dynamic
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class APD_DestinationController : ControllerBase
    {
        
        private IApprovalDestinationPathsService _approvalDestinationPathsService;

        public APD_DestinationController(IApprovalDestinationPathsService approvalPath)
        {
            _approvalDestinationPathsService = approvalPath;
        }

        [HttpGet]
        public async Task<List<ApprovalDestinations>> Get()
        {
            return await _approvalDestinationPathsService.GetDestinations();
        }

        [HttpPost]
        public async Task<WorkFlowUsers> createUser(string? username)
        {
            WorkFlowUsers? user = await _approvalDestinationPathsService.createUser(username);
            return user;
        }

        [HttpPost]
        public async Task<ApprovalDestinations> createDestination(ApprovalDestinations? username)
        {
            ApprovalDestinations? ApprovalDestination = await _approvalDestinationPathsService.createDestination(username);
            return ApprovalDestination;
        }
    }
}
