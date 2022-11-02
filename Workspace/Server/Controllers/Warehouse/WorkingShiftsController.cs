using Microsoft.AspNetCore.Mvc;

namespace Workspace.Server.Controllers.Warehouse
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingShiftsController : ControllerBase
    {
        private readonly WorkspaceDbContext _context;

        public WorkingShiftsController(WorkspaceDbContext context)
        {
            _context = context;
        }

        // Get: api/WorkingShifts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Warehouse_WorkingShift>>> GetWorkingShift()
        {
            if (_context.Warehouse_WorkingShifts == null)          //<-----Call from db context (WorkingShift)                 IEnumerable = List
            {
                return NotFound();
            }
            return Ok(await _context.Warehouse_WorkingShifts.ToListAsync());
        }
    }
}
