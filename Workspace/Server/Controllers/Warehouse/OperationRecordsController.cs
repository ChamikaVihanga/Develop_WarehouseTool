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
    public class OperationRecordsController : ControllerBase
    {
        private readonly WorkspaceDbContext _context;

        public OperationRecordsController(WorkspaceDbContext context)
        {
            _context = context;
        }

        // GET: api/OperationRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperationRecord>>> GetOperationRecords()
        {
          if (_context.OperationRecords == null)
          {
              return NotFound();
          }
            return _context.OperationRecords.Include(c => c.OperationList).ToList();
        }

        // GET: api/OperationRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OperationRecord>> GetOperationRecord(int id)
        {
          if (_context.OperationRecords == null)
          {
              return NotFound();
          }
            var operationRecord = await _context.OperationRecords.FindAsync(id);

            if (operationRecord == null)
            {
                return NotFound();
            }

            return operationRecord;
        }

        // PUT: api/OperationRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperationRecord(int id, OperationRecord operationRecord)
        {
            if (id != operationRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(operationRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperationRecordExists(id))
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

        // POST: api/OperationRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OperationRecord>> PostOperationRecord(OperationRecord operationRecord)
        {
          if (_context.OperationRecords == null)
          {
              return Problem("Entity set 'WorkspaceDbContext.OperationRecords'  is null.");
          }
            _context.OperationRecords.Add(operationRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOperationRecord", new { id = operationRecord.Id }, operationRecord);
        }

        // DELETE: api/OperationRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperationRecord(int id)
        {
            if (_context.OperationRecords == null)
            {
                return NotFound();
            }
            var operationRecord = await _context.OperationRecords.FindAsync(id);
            if (operationRecord == null)
            {
                return NotFound();
            }

            _context.OperationRecords.Remove(operationRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OperationRecordExists(int id)
        {
            return (_context.OperationRecords?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
