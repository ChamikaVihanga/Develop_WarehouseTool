using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workspace.Shared.Entities.ApprovalPath;

namespace admin.workspace.Server.Controllers.ApprovalPath
{
    [Route("api/[controller]")]
    [ApiController]
    public class AP_NotifiedSetsController : ControllerBase
    {
        private readonly WorkspaceDbContext _context;

        public AP_NotifiedSetsController(WorkspaceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotifiedUserSets>>> GetFlowOrders()
        {
            if (_context.ap_userSetsToNotify == null)
            {
                return NotFound();
            }
            return await _context.ap_userSetsToNotify.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddFlowOrder(NotifiedUserSets notifiedUserSets)
        {
            if (_context.ap_userSetsToNotify == null)
            {
                return Problem("Entity set 'WorkspaceDbContext.ap_userSetsToNotify'  is null.");
            }
            _context.ap_userSetsToNotify.Add(notifiedUserSets);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlowOrders", new { id = notifiedUserSets.NotifyUserSetId }, notifiedUserSets);
        }
    }
}
