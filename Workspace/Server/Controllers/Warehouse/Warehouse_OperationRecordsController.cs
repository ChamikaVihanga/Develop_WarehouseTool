using Microsoft.AspNetCore.Mvc;

namespace Workspace.Server.Controllers.Warehouse
{
    [Route("api/[controller]")]
    [ApiController]
    public class Warehouse_OperationRecordsController : ControllerBase
    {
        private readonly WorkspaceDbContext _context;

        public Warehouse_OperationRecordsController(WorkspaceDbContext context)
        {
            _context = context;
        }

        [HttpGet("ValidateTimeSpan")]
        public async Task<ActionResult<bool>> ValidateTime(int id, DateTime EnterdStartTime, DateTime EnterdEndTime)
        {                                 
            bool checkTimeSpan = _context.Warehouse_OperationRecords.Where(a=>a.Id == id && a.StartTime == EnterdStartTime && a.EndDate == EnterdEndTime).Any();        
            return checkTimeSpan;
        }

        // GET: api/Warehouse_OperationRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Warehouse_OperationRecord>>> GetOperationRecords()
        {
            if (_context.Warehouse_OperationRecords == null)
            {
                return NotFound();
            }
            return await _context.Warehouse_OperationRecords.Include(x => x.OperationList).ToListAsync();
        }

        // GET: api/Warehouse_OperationRecords/getbyid?id=5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Warehouse_OperationRecord>>> GetOperationRecord(int id)
        {
            if (_context.Warehouse_OperationRecords == null)
            {
                return NotFound();
            }

            var operationRecord = await _context.Warehouse_OperationRecords.Include(a => a.OperationList).Where(b => b.SAPNo == id.ToString()).ToListAsync();
            if (operationRecord == null)
            {
                return NotFound();
            }

            return operationRecord;
        }

        // GET: api/Warehouse_OperationRecords/Filteer?id=12045&&SelectedDate=2022-06-03
        [HttpGet, Route("Filter")]
        public async Task<ActionResult<List<Warehouse_OperationRecord>>> OperationRecordsSapDate(int id, DateTime SelectedDate)
        {

            var recordDate = await _context.Warehouse_OperationRecords
                .Include(a => a.OperationList)
                .ThenInclude(b => b.Warehouse_OperationDetails)
                .Where(b => b.SAPNo == id.ToString())
                .Where(b => b.CreateDate.Date == SelectedDate)

                .ToListAsync();

            return recordDate;
        }

        //Get: api/Warehouse_OperationRecords/Efficiency
        [HttpGet("Efficiency")]
        public async Task<ActionResult<List<Warehouse_OperationRecord>>> GetEfficiencyDetil(string SapNo, DateTime SelectMonth)
        {

            var efficiencyRecord = await _context.Warehouse_OperationRecords
               .Include(a => a.OperationList)
               .ThenInclude(b => b.Warehouse_OperationDetails)
               .Where(a => a.SAPNo == SapNo)
               .Where(a => a.CreateDate.Month == SelectMonth.Month)
               .ToListAsync();

            return
                efficiencyRecord;
        }

        // PUT: api/Warehouse_OperationRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutOperationRecord(int id, Warehouse_OperationRecord operationRecord)
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
            return Ok("Your submission successfully recorded");
        }

        // POST: api/Warehouse_OperationRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<string> PostOperationRecord(Warehouse_OperationRecord operationRecord)
        {
            _context.Warehouse_OperationRecords.Add(operationRecord);
            await _context.SaveChangesAsync();

            return "Susscessfully Submit";
        }

        // DELETE: api/Warehouse_OperationRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperationRecord(int id)
        {
            if (_context.Warehouse_OperationRecords == null)
            {
                return NotFound();
            }
            var operationRecord = await _context.Warehouse_OperationRecords.FindAsync(id);
            if (operationRecord == null)
            {
                return NotFound();
            }

            _context.Warehouse_OperationRecords.Remove(operationRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OperationRecordExists(int id)
        {
            return (_context.Warehouse_OperationRecords?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
