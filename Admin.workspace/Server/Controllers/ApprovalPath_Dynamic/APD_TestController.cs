using ApprovalPath_Utils.ApprovalPathService;
using ApprovalPath_Utils.Services.ApprovalJobManagerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Workspace.Shared.Entities.ApprovalDynamicPaths;

namespace admin.workspace.Server.Controllers.ApprovalPath_Dynamic
{
    [Route("api/[controller]")]
    [ApiController]
    public class APD_TestController : ControllerBase
    {
        //private readonly IApprovalPathService _approvalPathService;
        private readonly IApprovalJobManagerService _approvalPathService;
        public APD_TestController(IApprovalJobManagerService approvalPath)
        {
            _approvalPathService = approvalPath;
        }
        [HttpGet, Authorize]
        public async Task<ApprovalConfigurations> test(Guid doc)
        {
            var conf = await _approvalPathService.CreateJob(doc, User);
           
            return conf;
        }
    }
}
