using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Workspace.Shared.Entities.Warehouse;

namespace Workspace.Server.Controllers.Warehouse
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationDetailesController : ControllerBase
    {
        private readonly WorkspaceDbContext _context;

        public OperationDetailesController(WorkspaceDbContext context)
        {
            _context = context;
        }

        // GET: api/OperationDetailes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperationDetaile>>> GetOperationDetailes()
        {
            if (_context.OperationDetailes == null)
            {
                return NotFound();
            }
            return await _context.OperationDetailes.Include(x => x.OperationList).ToListAsync();
        }

        // GET: api/OperationDetailes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OperationDetaile>> GetOperationDetaile(int id)
        {
            if (_context.OperationDetailes == null)
            {
                return NotFound();
            }
            var operationDetaile = await _context.OperationDetailes.FindAsync(id);

            if (operationDetaile == null)
            {
                return NotFound();
            }

            return operationDetaile;
        }

        // PUT: api/OperationDetailes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperationDetaile(int id, OperationDetaile operationDetaile)
        {
            if (id != operationDetaile.Id)
            {
                return BadRequest();
            }

            _context.Entry(operationDetaile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperationDetaileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OperationDetailes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OperationDetaile>> PostOperationDetaile(OperationDetaile operationDetaile)
        {
            if (_context.OperationDetailes == null)
            {
                return Problem("Entity set 'WorkspaceDbContext.OperationDetailes'  is null.");
            }
            _context.OperationDetailes.Add(operationDetaile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOperationDetaile", new { id = operationDetaile.Id }, operationDetaile);
        }

        // DELETE: api/OperationDetailes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperationDetaile(int id)
        {
            if (_context.OperationDetailes == null)
            {
                return NotFound();
            }
            var operationDetaile = await _context.OperationDetailes.FindAsync(id);
            if (operationDetaile == null)
            {
                return NotFound();
            }

            _context.OperationDetailes.Remove(operationDetaile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OperationDetaileExists(int id)
        {
            return (_context.OperationDetailes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
