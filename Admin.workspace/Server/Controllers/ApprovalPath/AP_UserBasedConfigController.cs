using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workspace.Shared.Entities.ApprovalPath;

namespace admin.workspace.Server.Controllers.ApprovalPath
{
    [Route("api/[controller]")]
    [ApiController]
    public class AP_UserBasedConfigController : ControllerBase
    {
        private readonly WorkspaceDbContext _context;

        public AP_UserBasedConfigController(WorkspaceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserBased_Config>>> GetUserBased_Config()
        {
            if (_context.ap_userBased_Configs == null)
            {
                return NotFound();
            }
            return await _context.ap_userBased_Configs.Include(a => a.approvalPathUser).ThenInclude(b => b.ApprovalFlowOrders).Include(a => a.approvalFlows).ThenInclude(b => b.ApprovalPathUsers).ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddUserBased_Config(UserBased_Config userBased_Config)
        {
            if (_context.ap_userBased_Configs == null)
            {
                return Problem("Entity set 'WorkspaceDbContext.ap_approvalPathUsers'  is null.");
            }
            _context.ap_userBased_Configs.Add(userBased_Config);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserBased_Config", new { id = userBased_Config.Conf_Id }, userBased_Config);
        }
    }
}
