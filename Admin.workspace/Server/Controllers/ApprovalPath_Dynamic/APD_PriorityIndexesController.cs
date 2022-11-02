using ApprovalPath_Utils.Services.ApprovalPriorityIndexService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workspace.Shared.Entities.ApprovalDynamicPaths;

namespace admin.workspace.Server.Controllers.ApprovalPath_Dynamic
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class APD_PriorityIndexesController : ControllerBase
    { 
        private readonly IApprovalPriorityIndexService _approvalPriorityIndexService;

        public APD_PriorityIndexesController(IApprovalPriorityIndexService approvalPriorityIndexService)
        {
     
            _approvalPriorityIndexService = approvalPriorityIndexService;
        }

        [HttpGet]
        public async Task<List<PriorityIndexes>> GetByDocId(Guid? guid)
        {
            return await _approvalPriorityIndexService.GetByDocument(guid);
        }
    }
}
