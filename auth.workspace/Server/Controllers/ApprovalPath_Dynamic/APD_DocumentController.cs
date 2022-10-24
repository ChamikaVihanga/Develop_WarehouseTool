using ApprovalPath_Utils.ApprovalPathService;
using ApprovalPath_Utils.Services.ApprovalDocuementService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Workspace.Shared.Entities.ApprovalDynamicPaths;

namespace admin.workspace.Server.Controllers.ApprovalPath_Dynamic
{
    [Route("api/[controller]")]
    [ApiController]
    public class APD_DocumentController : ControllerBase
    {
        private readonly WorkspaceDbContext _context;
        private readonly IApprovalDocuementService _approvalPathService;

        public APD_DocumentController(WorkspaceDbContext context, IApprovalDocuementService approvalPath)
        {
            _context = context;
            _approvalPathService = approvalPath;
        }

        [HttpGet]
        public async Task<List<ApprovalDocuments>> Get()
        {
            return await _context.apd_approvalDocuments.Include(a => a.PriorityIndexes).ThenInclude(a => a.ApprovalDefinition).ThenInclude(a => a.DefinitionValues)
                .ThenInclude(a => a.ApprovalConfigurations)
                .ThenInclude(a => a.ApprovalDestinations)
                .ThenInclude(a => a.WorkFlowUsers)
                .Include(a => a.PriorityIndexes).ThenInclude(a => a.ApprovalDefinition)
                .ThenInclude(a => a.DefinitionValues)
                .ThenInclude(a => a.ApprovalConfigurations)
                .ThenInclude(a => a.ApprovalDocuments)
                .Include(a => a.PriorityIndexes)
                .ThenInclude(a => a.ApprovalDefinition)
                .ThenInclude(a => a.DefinitionValues)
                .ThenInclude(a => a.ApprovalConfigurations)
                .ThenInclude(a => a.ApprovalDestinations)
                .ThenInclude(a => a.WorkFlowIndex)
                .ToListAsync();
        }

        [HttpGet("Get-Docuement-types")]
        public async Task<List<ApprovalDocuments>> GetDocTypes()
        {
            return await _approvalPathService.ApprovalDocuments();
        }

        [HttpPost("Add-Document")]
        public async Task<IActionResult> AddDoc(ApprovalDocuments approvalDocuments)
        {
            try
            {
                await _approvalPathService.AddApprovalDocument(approvalDocuments);
                return Ok();

            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}
