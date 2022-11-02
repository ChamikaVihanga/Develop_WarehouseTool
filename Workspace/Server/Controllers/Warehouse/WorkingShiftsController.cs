using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workspace.Shared.Entities.Warehouse;

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
        public async Task<ActionResult<IEnumerable<WorkingShifts>>> GetWorkingShift()
        {
            if (_context.WorkingShift == null)          //<-----Call from db context (WorkingShift)                 IEnumerable = List
            {
                return NotFound();
            }
            return Ok(await _context.WorkingShift.ToListAsync());
        }               
    }
}
