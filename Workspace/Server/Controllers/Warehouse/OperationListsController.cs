using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("Active"), Authorize(Policy = "VSPolicy")]
        public async Task<ActionResult<IEnumerable<OperationDetail>>> GetActiveOperationLists()
        {
            if (_context.OperationLists == null)
            {
                return NotFound();
            }
            //return await _context.OperationLists
            //    .Include(x => x.OperationDetails)
            //    .ToListAsync();

    
            var opDetail = await _context.OperationDetails.Include(a => a.OperationList).ToListAsync();
            List<OperationDetail> getActiveOperations = new List<OperationDetail>();

            List<int> listIds = new List<int>();
            listIds = opDetail.Select(a => a.Id).Distinct().ToList();

            List<OperationDetail> ActiveRecords = new List<OperationDetail>();
            ActiveRecords = opDetail.Where(b => b.EffectiveDate < DateTime.Now).ToList();


            foreach (int a in listIds)
            {
                List<OperationDetail> ActiveDetails = ActiveRecords.Where(b => b.OperationListId == a).ToList();
                OperationDetail? maxDate = ActiveDetails.MaxBy(p => p.EffectiveDate);
                if (maxDate != null)
                {
                    getActiveOperations.Add(maxDate);
                }
            }
            return getActiveOperations;
        }


        // GET: api/OperationLists/Upcoming
        //[HttpGet("Upcoming"), Authorize(Policy = "VSPolicy")]
        [HttpGet("Upcoming")]
        public async Task<ActionResult<IEnumerable<OperationDetail>>> GetUpcomingOperationLists()
        {
            if (_context.OperationLists == null)
            {
                return NotFound();
            }

            //return await _context.OperationLists
            //    .Include(x => x.OperationDetails)
            //    .ToListAsync();
           
            var opDetail = await _context.OperationDetails.Include(b =>b.OperationList).ToListAsync();
            List<OperationDetail> getUpcommingOperations = new List<OperationDetail>();

            List<int> listIds = new List<int>();
            listIds = opDetail.Select(a => a.OperationList.Id).Distinct().ToList();

            List<OperationDetail> UpcommingRecords = new List<OperationDetail>();
            UpcommingRecords = opDetail.Where(b => b.EffectiveDate > DateTime.Now).ToList();

            foreach (int a in listIds)
            {
                List<OperationDetail> UpcommingDetails = UpcommingRecords.Where(b => b.OperationListId == a).ToList();
                OperationDetail? minDate = UpcommingDetails.MinBy(p => p.EffectiveDate);
                if (minDate != null)
                {
                    getUpcommingOperations.Add(minDate);
                }
            }
            return getUpcommingOperations;
        }


        //.Include(x => x.OperationDetails)
        // GET: api/OperationLists/getOperationName/5
        [HttpGet, Route("getOperationName")]
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
        [HttpPut]   /*, Authorize(Policy = "VSPolicy")*/
        public async Task<ActionResult<List<OperationList>>> EditOperationName(OperationList operationList, int id)
        {
            var editOpName = await _context.OperationLists
                    .Include(a => a.OperationDetails)
                    .FirstOrDefaultAsync(a => a.Id == id);
            if(editOpName == null)
                return NotFound("Not Found");

            editOpName.Name = operationList.Name;  
            editOpName.Id = id;

            await _context.SaveChangesAsync();

            return Ok("Changes have been successfully saved");
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
