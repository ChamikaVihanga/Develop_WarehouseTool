using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workspace.Shared.Entities.ApprovalPath;

namespace admin.workspace.Server.Controllers.ApprovalPath
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly WorkspaceDbContext _context;

        public DocumentController(WorkspaceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisteredDocuments>>> GetDocuemnts()
        {
            if (_context.ap_registeredDocuments == null)
            {
                return NotFound();
            }
            return await _context.ap_registeredDocuments
                .Include(a => a.UserBased_Configs)
                .ThenInclude(b => b.approvalPathUser)
                .Include(a => a.UserBased_Configs)
                .ThenInclude(c => c.approvalFlows)
                .ThenInclude(b => b.ApprovalPathUsers)
                .Include(a => a.UserBased_Configs)
                .ThenInclude(c => c.approvalFlows )
                .ThenInclude(a => a.notifiedUserSet)
                .ThenInclude(a => a.approvalPathUsers)
                .ToListAsync();

        }

        [HttpPost]
        public async Task<IActionResult> AddDocuments(RegisteredDocuments registeredDocuments)
        {
            if (_context.ap_registeredDocuments == null)
            {
                return Problem("Entity set 'WorkspaceDbContext.ap_registeredDocuments'  is null.");
            }
            _context.ap_registeredDocuments.Add(registeredDocuments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocuemnts", new { id = registeredDocuments.id }, registeredDocuments);
        }
    }
}
