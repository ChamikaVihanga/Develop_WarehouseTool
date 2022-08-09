using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Workspace.Server.Data;
using Workspace.Shared.Entities.Warehouse;

namespace Workspace.Server.Controllers.Warehouse
{
    [Route("api/[controller]")]
    [ApiController]
    public class VS_EmployeesController : ControllerBase
    {
        private readonly WorkspaceDbContext _context;

        public VS_EmployeesController(WorkspaceDbContext context)
        {
            _context = context;
        }

        // GET: api/VS_Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VS_Employees>>> GetVS_Employees()
        {
            if (_context.VS_Employees == null)
            {
                return NotFound();
            }
            return await _context.VS_Employees.ToListAsync();
        }

        // GET: api/VS_Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VS_Employees>> GetVS_Employees(int id)
        {
            if (_context.VS_Employees == null)
            {
                return NotFound();
            }
            var vS_Employees = await _context.VS_Employees.FindAsync(id);

            if (vS_Employees == null)
            {
                return NotFound();
            }

            return vS_Employees;
        }

        // PUT: api/VS_Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVS_Employees(int id, VS_Employees vS_Employees)
        {
            if (id != vS_Employees.Id)
            {
                return BadRequest();
            }

            _context.Entry(vS_Employees).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VS_EmployeesExists(id))
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

        // POST: api/VS_Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VS_Employees>> PostVS_Employees(VS_Employees vS_Employees)
        {
            if (_context.VS_Employees == null)
            {
                return Problem("Entity set 'WorkspaceDbContext.VS_Employees'  is null.");
            }
            _context.VS_Employees.Add(vS_Employees);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVS_Employees", new { id = vS_Employees.Id }, vS_Employees);
        }

        // DELETE: api/VS_Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVS_Employees(int id)
        {
            if (_context.VS_Employees == null)
            {
                return NotFound();
            }
            var vS_Employees = await _context.VS_Employees.FindAsync(id);
            if (vS_Employees == null)
            {
                return NotFound();
            }

            _context.VS_Employees.Remove(vS_Employees);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VS_EmployeesExists(int id)
        {
            return (_context.VS_Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
