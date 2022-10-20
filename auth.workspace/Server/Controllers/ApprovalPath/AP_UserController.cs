using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Workspace.Shared.Entities.ApprovalPath;
using Workspace.Shared.Entities.ResourceFacilities;

namespace admin.workspace.Server.Controllers.ApprovalPath
{
    [Route("api/[controller]")]
    [ApiController]
    public class AP_UserController : ControllerBase
    {
        private readonly WorkspaceDbContext _context;

        public AP_UserController(WorkspaceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApprovalPathUsers>>> GetUsers()
        {
            if (_context.ap_approvalPathUsers == null)
            {
                return NotFound();
            }
            return await _context.ap_approvalPathUsers.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> addUsers(ApprovalPathUsers approvalPathUsers)
        {
            if (_context.ap_approvalPathUsers == null)
            {
                return Problem("Entity set 'WorkspaceDbContext.ap_approvalPathUsers'  is null.");
            }
            _context.ap_approvalPathUsers.Add(approvalPathUsers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsers", new { id = approvalPathUsers.Id }, approvalPathUsers);
        }

        [HttpGet("getUser")]
        public async Task<ApprovalPathUsers> getUser(string username)
        {
            return await _context.ap_approvalPathUsers.Where(a => a.UserName == username).Include(a => a.ApprovalFlowOrders).ThenInclude(a => a.userBased_Configs).ThenInclude(a => a.RegisteredDocument).ThenInclude(a => a.ApprovalRequests).FirstOrDefaultAsync();
        }
    }
}
