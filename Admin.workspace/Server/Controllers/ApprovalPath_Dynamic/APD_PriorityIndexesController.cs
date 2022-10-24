using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workspace.Shared.Entities.ApprovalDynamicPaths;

namespace admin.workspace.Server.Controllers.ApprovalPath_Dynamic
{
    [Route("api/[controller]")]
    [ApiController]
    public class APD_PriorityIndexesController : ControllerBase
    {
        private readonly WorkspaceDbContext _context;

        public APD_PriorityIndexesController(WorkspaceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<PriorityIndexes>> Get(Guid? guid)
        {
            return await _context.apd_priorityIndexes.Where(a => a.ApprovalDocumentId == guid)
                .Include(a => a.ApprovalDefinition)
                .ThenInclude(a => a.DefinitionValues)
                .ThenInclude(a => a.ApprovalConfigurations)
                .ThenInclude(a => a.ApprovalDestinations)
                .ThenInclude(a => a.WorkFlowUsers)
                .Include(a => a.ApprovalDefinition)
                .ThenInclude(a => a.DefinitionValues)
                .ThenInclude(a => a.ApprovalConfigurations)
                .ThenInclude(a => a.ApprovalDocuments)
                .ToListAsync();
        }
    }
}
