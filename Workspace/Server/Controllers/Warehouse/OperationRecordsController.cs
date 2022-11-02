using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
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

        // GET: api/OperationRecords/getbyid?id=5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<OperationRecord>>> GetOperationRecord(int id)
        {
            if (_context.OperationRecords == null)
            {
                return NotFound();
            }

            var operationRecord = await _context.OperationRecords.Include(a => a.OperationList).Where(b => b.SAPNo == id.ToString()).ToListAsync();
            if (operationRecord == null)
            {
                return NotFound();
            }

            return operationRecord;
        }

        // GET: api/OperationRecords/Filteer?id=12045&&SelectedDate=2022-06-03
        [HttpGet, Route("Filter")]
        public async Task<ActionResult<List<OperationRecord>>> OperationRecordsSapDate(int id, DateTime SelectedDate)
        {

            var recordDate = await _context.OperationRecords
                .Include(a => a.OperationList)
                .ThenInclude(b => b.OperationDetails)
                .Where(b => b.SAPNo == id.ToString())
                .Where(b => b.CreateDate.Date == SelectedDate)

                .ToListAsync();

            return recordDate;
        }

        //Get: api/OperationRecords/Efficiency
        [HttpGet("Efficiency")]
        public async Task<ActionResult<List<OperationRecord>>> GetEfficiencyDetil(string SapNo, DateTime SelectMonth)
        {           

            var efficiencyRecord = await _context.OperationRecords
               .Include(a => a.OperationList)
               .ThenInclude(b => b.OperationDetails)
               .Where(a => a.SAPNo == SapNo)
               .Where(a => a.CreateDate.Month == SelectMonth.Month)
               .ToListAsync();

            return
                efficiencyRecord;
        } 

        // PUT: api/OperationRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
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
        {            
            _context.OperationRecords.Add(operationRecord);
            await _context.SaveChangesAsync();            

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
