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
    public class OperationListsController : ControllerBase
    {
        private readonly WorkspaceDbContext _context;

        public OperationListsController(WorkspaceDbContext context)
        {
            _context = context;
        }

        // GET: api/OperationLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperationList>>> GetOperationLists()
        {
            if (_context.OperationLists == null)
            {
                return NotFound();
            }
            return await _context.OperationLists.ToListAsync();
        }

        // GET: api/OperationLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OperationList>> GetOperationList(int id)
        {
            if (_context.OperationLists == null)
            {
                return NotFound();
            }
            var operationList = await _context.OperationLists.FindAsync(id);

            if (operationList == null)
            {
                return NotFound();
            }

            return operationList;
        }

        // PUT: api/OperationLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperationList(int id, OperationList operationList)
        {
            if (id != operationList.Id)
            {
                return BadRequest();
            }

            _context.Entry(operationList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperationListExists(id))
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

        // POST: api/OperationLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<string> PostOperationList(OperationList operationList)
        {

            _context.OperationLists.Add(operationList);
            await _context.SaveChangesAsync();

            /*return CreatedAtAction("GetOperationList", new { id = operationList.Id }, operationList);*/
            return "Susscessful.";

        }


        // DELETE: api/OperationLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperationList(int id)
        {
            if (_context.OperationLists == null)
            {
                return NotFound();
            }
            var operationList = await _context.OperationLists.FindAsync(id);
            if (operationList == null)
            {
                return NotFound();
            }

            _context.OperationLists.Remove(operationList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OperationListExists(int id)
        {
            return (_context.OperationLists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
