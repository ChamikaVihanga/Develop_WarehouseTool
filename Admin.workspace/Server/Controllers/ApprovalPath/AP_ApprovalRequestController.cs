using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workspace.Shared.Entities.ApprovalPath;

namespace admin.workspace.Server.Controllers.ApprovalPath
{
    [Route("api/[controller]")]
    [ApiController]
    public class ap_ApprovalRequestController : ControllerBase
    {
        private readonly WorkspaceDbContext _context;

        public ap_ApprovalRequestController(WorkspaceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApprovalRequest>>> GetRequests()
        {
            if (_context.ap_approvalRequests == null)
            {
                return NotFound();
            }
            return await _context.ap_approvalRequests.Include(a => a.registeredDocument)
                .ThenInclude(a => a.UserBased_Configs)
                .ThenInclude(b => b.approvalPathUser).Include(a => a.registeredDocument)
                .ThenInclude(a => a.UserBased_Configs)
                .ThenInclude(c => c.approvalFlows)
                .ThenInclude(b => b.ApprovalPathUsers).Include(a => a.registeredDocument)
                .ThenInclude(a => a.UserBased_Configs)
                .ThenInclude(c => c.approvalFlows)
                .ThenInclude(a => a.notifiedUserSet)
                .ThenInclude(a => a.approvalPathUsers)
                .ToListAsync();

        }

        [HttpPost]
        public async Task<IActionResult> AddRequest(ApprovalRequest approvalRequest)
        {
            if (_context.ap_approvalRequests == null)
            {
                return Problem("Entity set 'WorkspaceDbContext.ap_registeredDocuments'  is null.");
            }
            _context.ap_approvalRequests.Add(approvalRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequests", new { id = approvalRequest.ApprovalRequestId }, approvalRequest);
        }
    }
}

