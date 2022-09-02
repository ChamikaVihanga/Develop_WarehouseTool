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
            return await _context.OperationRecords.Include(x => x.OperationList).ToListAsync();
        }



        // GET: api/OperationRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<OperationRecord>>> GetOperationRecord(int id)
        {
            if (_context.OperationRecords == null)
            {
                return NotFound();
            }

            var operationRecord = await _context.OperationRecords.Include(a => a.OperationList).Where(b => b.VS_EmployeesId == id).ToListAsync();
            if (operationRecord == null)
            {
                return NotFound();
            }

            return operationRecord;
        }

        // GET: api/OperationRecords/Sap/Date
        // GET: api/OperationRecords/12045/2022-06-03

        [HttpGet("{id}/{SelectedDate}")]
        public async Task<ActionResult<List<OperationRecord>>> OperationRecordsSapDate(int id, DateTime SelectedDate)
        {

            var recordDate = await _context.OperationRecords
                .Include(a => a.OperationList)
                .ThenInclude(b => b.OperationDetails)
                .Include(d => d.VS_Employees)
                .Where(b => b.VS_EmployeesId == id)
                .ToListAsync();

            return recordDate;
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
        public async Task<string> PostOperationRecord(OperationRecord operationRecord)
        /*public async Task<String> PostOperationRecord(OperationRecord operationRecord)*/
        {
            /*if (_context.OperationRecords == null)
            {
                return Problem("Entity set 'WorkspaceDbContext.OperationRecords'  is null.");
            }*/
            //operationRecord.EndTime = null;
            _context.OperationRecords.Add(operationRecord);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetOperationRecord", new { id = operationRecord.Id }, operationRecord);

            return "Susscessful..";

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
