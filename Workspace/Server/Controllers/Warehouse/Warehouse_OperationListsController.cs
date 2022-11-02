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
    public class Warehouse_OperationListsController : ControllerBase
    {
        private readonly WorkspaceDbContext _context;

        public Warehouse_OperationListsController(WorkspaceDbContext context)
        {
            _context = context;
        }

        // GET: api/Warehouse_OperationLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Warehouse_OperationList>>> GetOperationLists()
        {
            if (_context.Warehouse_OperationLists == null)
            {
                return NotFound();
            }
            return await _context.Warehouse_OperationLists.ToListAsync();
        }

        // GET: api/Warehouse_OperationLists/Active
        [HttpGet("Active"), Authorize(Policy = "VSPolicy")]
        public async Task<ActionResult<IEnumerable<Warehouse_OperationDetail>>> GetActiveOperationLists()
        {
            if (_context.Warehouse_OperationLists == null)
            {
                return NotFound();
            }           
                
            var opDetail = await _context.Warehouse_OperationDetails.Include(a => a.OperationList).ToListAsync();
            List<Warehouse_OperationDetail> getActiveOperations = new List<Warehouse_OperationDetail>();

            List<int> listIds = new List<int>();
            listIds = opDetail.Select(a => a.Id).Distinct().ToList();

            List<Warehouse_OperationDetail> ActiveRecords = new List<Warehouse_OperationDetail>();
            ActiveRecords = opDetail.Where(b => b.EffectiveDate < DateTime.Now).ToList();

            foreach (int a in listIds)
            {
                List<Warehouse_OperationDetail> ActiveDetails = ActiveRecords.Where(b => b.OperationListId == a).ToList();
                Warehouse_OperationDetail? maxDate = ActiveDetails.MaxBy(p => p.EffectiveDate);
                if (maxDate != null)
                {
                    getActiveOperations.Add(maxDate);
                }
            }
            return getActiveOperations;
        }

        // GET: api/Warehouse_OperationLists/Upcoming
        //[HttpGet("Upcoming"), Authorize(Policy = "VSPolicy")]
        [HttpGet("Upcoming")]
        public async Task<ActionResult<IEnumerable<Warehouse_OperationDetail>>> GetUpcomingOperationLists()
        {
            if (_context.Warehouse_OperationLists == null)
            {
                return NotFound();
            }
                       
            var opDetail = await _context.Warehouse_OperationDetails.Include(b =>b.OperationList).ToListAsync();
            List<Warehouse_OperationDetail> getUpcommingOperations = new List<Warehouse_OperationDetail>();

            List<int> listIds = new List<int>();
            listIds = opDetail.Select(a => a.OperationList.Id).Distinct().ToList();

            List<Warehouse_OperationDetail> UpcommingRecords = new List<Warehouse_OperationDetail>();
            UpcommingRecords = opDetail.Where(b => b.EffectiveDate > DateTime.Now).ToList();

            foreach (int a in listIds)
            {
                List<Warehouse_OperationDetail> UpcommingDetails = UpcommingRecords.Where(b => b.OperationListId == a).ToList();
                Warehouse_OperationDetail? minDate = UpcommingDetails.MinBy(p => p.EffectiveDate);
                if (minDate != null)
                {
                    getUpcommingOperations.Add(minDate);
                }
            }
            return getUpcommingOperations;
        }

        //.Include(x => x.Warehouse_OperationDetails)
        // GET: api/Warehouse_OperationLists/getOperationName/5
        [HttpGet, Route("getOperationName")]
        public async Task<ActionResult<Warehouse_OperationList>> GetOperationList(int id)
        {
            if (_context.Warehouse_OperationLists == null)
            {
                return NotFound();
            }

            var operationList = await _context.Warehouse_OperationLists.FindAsync(id);               

            if (operationList == null)
            {
                return NotFound();
            }

            return operationList;
        }

        // PUT: api/Warehouse_OperationLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut , Authorize(Policy = "VSPolicy")]  
        public async Task<ActionResult<List<Warehouse_OperationList>>> EditOperationName(Warehouse_OperationList operationList, int id)
        {
            var editOpName = await _context.Warehouse_OperationLists
                    .Include(a => a.Warehouse_OperationDetails)
                    .FirstOrDefaultAsync(a => a.Id == id);
            if(editOpName == null)
                return NotFound("Not Found");

            editOpName.Name = operationList.Name;  
            editOpName.Id = id;

            await _context.SaveChangesAsync();

            return Ok("Changes have been successfully saved");
        }

        // POST: api/Warehouse_OperationLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Warehouse_OperationList>> PostOperationList(Warehouse_OperationList operationList, bool isActive)
        {
          if (_context.Warehouse_OperationLists == null)
        {
              return Problem("Entity set 'WorkspaceDbContext.Warehouse_OperationLists'  is null.");
          }
            if (isActive == true)
            {
                operationList.IsActive = true;  
            }
            else
            {
                operationList.IsActive = false;
            }
          Warehouse_OperationList operationActivation = new Warehouse_OperationList();
            operationActivation.IsActive = operationList.IsActive;

            _context.Warehouse_OperationLists.Add(operationList);
            await _context.SaveChangesAsync();

            return Ok("Successfully Activated");
        }

        // DELETE: api/Warehouse_OperationLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperationList(int id)
        {
            if (_context.Warehouse_OperationLists == null)
            {
                return NotFound();
            }
            var operationList = await _context.Warehouse_OperationLists.FindAsync(id);
            if (operationList == null)
            {
                return NotFound();
            }

            _context.Warehouse_OperationLists.Remove(operationList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OperationListExists(int id)
        {
            return (_context.Warehouse_OperationLists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
