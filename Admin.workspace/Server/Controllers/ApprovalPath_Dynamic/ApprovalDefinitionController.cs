using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workspace.Shared.Entities.ApprovalDynamicPaths;

namespace admin.workspace.Server.Controllers.ApprovalPath_Dynamic
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApprovalDefinitionController : ControllerBase
    {
        private readonly WorkspaceDbContext _context;

        public ApprovalDefinitionController(WorkspaceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<ApprovalDefinitions>> Get()
        {
            return await _context.apd_approvalDefinitions.Include(a => a.DefinitionValues)
                .ThenInclude(a => a.ApprovalConfigurations)
                .ThenInclude(a => a.ApprovalDestinations)
                .ThenInclude(a => a.WorkFlowUsers)
                .Include(a => a.DefinitionValues)
                .ThenInclude(a => a.ApprovalConfigurations)
                .ThenInclude(a => a.ApprovalDocuments).Include(a => a.DefinitionValues)
                .ThenInclude(a => a.ApprovalConfigurations)
                .ThenInclude(a => a.ApprovalDestinations).ThenInclude(a => a.WorkFlowIndex).ToListAsync();
        }
    }
}
