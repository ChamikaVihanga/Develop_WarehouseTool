using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workspace.Shared.Entities.ApprovalPath;

namespace admin.workspace.Server.Controllers.ApprovalPath
{
    [Route("api/[controller]")]
    [ApiController]
    public class AP_FlowOrderController : ControllerBase
    {
        private readonly WorkspaceDbContext _context;

        public AP_FlowOrderController(WorkspaceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApprovalFlowOrder>>> GetFlowOrders()
        {
            if (_context.ap_approvalPathUsers == null)
            {
                return NotFound();
            }
            return await _context.ap_approvalFlowOrder.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddFlowOrder(ApprovalFlowOrder approvalFlowOrder)
        {
            if (_context.ap_approvalFlowOrder == null)
            {
                return Problem("Entity set 'WorkspaceDbContext.ap_approvalFlowOrder'  is null.");
            }
            _context.ap_approvalFlowOrder.Add(approvalFlowOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlowOrders", new { id = approvalFlowOrder.Id }, approvalFlowOrder);
        }
    }
}
