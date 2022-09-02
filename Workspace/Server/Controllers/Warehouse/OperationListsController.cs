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

        // GET: api/OperationLists/Active
        [HttpGet("Active")]
        public async Task<ActionResult<IEnumerable<OperationList>>> GetActiveOperationLists()
        {
            if (_context.OperationLists == null)
            {
                return NotFound();
            }
            return await _context.OperationLists
                .Include(x => x.OperationDetails)
                .ToListAsync();
        }


        // GET: api/OperationLists/Upcoming
        [HttpGet("Upcoming")]
        public async Task<ActionResult<IEnumerable<OperationList>>> GetUpcomingOperationLists()
        {
            if (_context.OperationLists == null)
            {
                return NotFound();
            }          

            return await _context.OperationLists
                .Include(x => x.OperationDetails)
                .ToListAsync();

            var opList = await _context.OperationLists.ToListAsync();
            var opDetail = await _context.OperationDetails.ToListAsync();
            List<OperationDetail> getUpcommingOperations = new List<OperationDetail>();

            List<int> listIds = new List<int>();
            listIds = opList.Select(a => a.Id).Distinct().ToList(); 

            List<OperationDetail> UpcommingRecords = new List<OperationDetail>();
            UpcommingRecords = opDetail.Where(b => b.EffectiveDate > DateTime.Now).ToList();

            foreach (int a in listIds)
            {
                List<OperationDetail> UpcommingDetails = UpcommingRecords.Where(b => b.Id == a).ToList();
                OperationDetail? minDate = UpcommingDetails.MinBy(p => p.EffectiveDate);
                if(minDate != null)
                {
                    getUpcommingOperations.Add(minDate);
                }
            }
        }


        //.Include(x => x.OperationDetails)
        // GET: api/OperationLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OperationList>> GetOperationList(int id)
        {
            if (_context.OperationLists == null)
            {
                return NotFound();
            }
            //Get data to _EditOperationTable.razor -----------> not using
            var operationList = await _context.OperationLists.FindAsync(id);
                //.Include(x => x.OperationDetails)
                //.FirstOrDefaultAsync(y => y.ID == id);

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
        public async Task<ActionResult<OperationList>> PostOperationList(OperationList operationList, bool isActive)
        {
          if (_context.OperationLists == null)
        {
              return Problem("Entity set 'WorkspaceDbContext.OperationLists'  is null.");
          }
            if (isActive == true)
            {
                operationList.IsActive = true;  
            }
            else
            {
                operationList.IsActive = false;
            }
          OperationList operationActivation = new OperationList();
            operationActivation.IsActive = operationList.IsActive;


            _context.OperationLists.Add(operationList);
            await _context.SaveChangesAsync();

            return Ok("Successfully Activated");
            //return CreatedAtAction("GetOperationList", new { id = operationList.Id }, operationList);
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
