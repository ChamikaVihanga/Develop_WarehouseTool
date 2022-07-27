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
    public class OperationDetailsAPIController : ControllerBase
    {
        private readonly WorkspaceDbContext _context;

        public OperationDetailsAPIController(WorkspaceDbContext context)
        {
            _context = context;
        }

        // GET: api/OperationDetailsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperationDetail>>> GetOperationDetails()
        {
            if (_context.OperationDetails == null)
            {
                return NotFound();
            }
            return await _context.OperationDetails.Include(x => x.OperationList).ToListAsync();
        }

        // GET: api/OperationDetailsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OperationDetail>> GetOperationDetail(int id)
        {
            if (_context.OperationDetails == null)
            {
                return NotFound();
            }
            //Get data to _EditOperationTable.razor
            var operationDetail = await _context.OperationDetails
                .Include(a => a.OperationList)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (operationDetail == null)
            {
                return NotFound();
            }

            return operationDetail;
        }
        /// <summary>
        /// Add new operation details to same List Id.
        /// </summary>
        /// <param name="operationDetail"></param>
        /// <returns></returns>
        //POST: api/OperationDetailsAPI/DetailsOnly
        [HttpPost, Route("DetailsOnly")]
        public async Task<string> PostDetails(OperationDetail operationDetail)
        {
            OperationDetail operationDetail1 = new OperationDetail();

            operationDetail1.TimePeriod = operationDetail.TimePeriod;
            operationDetail1.CreateDate = DateTime.Now;
            operationDetail1.TimeSpan = operationDetail.TimeSpan;
            operationDetail1.EffectiveDate = operationDetail.EffectiveDate;
            operationDetail1.Target = operationDetail.Target;
            operationDetail1.CreatedBy = "Ashen(CEO)";
            operationDetail1.OperationListId = operationDetail.OperationListId;

            _context.OperationDetails.Add(operationDetail1);
            await _context.SaveChangesAsync();

            return string.Empty;
        }


        [HttpGet, Route("getOperationList")]
        public async Task<List<OperationList>> getOperationList()
        {
            return _context.OperationLists.Include(a => a.OperationDetails).ToList();
        }


        // PUT: api/OperationDetailsAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutOperationDetail(int id, OperationSummeryDTO operationSummeryDTO)
        //{
        //    if (id != operationSummeryDTO.DTOid)
        //    {
        //        return BadRequest();
        //    }

        //    OperationList opListSe = new OperationList();
        //    opListSe.ID = id;
        //    opListSe.Name = operationSummeryDTO.OperationName;
        //    opListSe.IsActive = true;

        //    _context.Entry(opListSe).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();            
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OperationDetailExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Ok("hello");
        //}
       
        // POST: api/OperationDetailsAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<string>> PostOperationDetail(OperationSummeryDTO operationSummeryDTO)
        {
            if (_context.OperationDetails == null)
            {
                return Problem("Entity set 'WorkspaceDbContext.OperationDetails'  is null.");
            }
           
            OperationList opList = new OperationList();
            opList.Name = operationSummeryDTO.OperationName;
            opList.IsActive = true;

            _context.OperationLists.Add(opList);
            await _context.SaveChangesAsync();

            var lastRecordID =  _context.OperationLists.Where(a => a.Name == operationSummeryDTO.OperationName).ToList().Select(b => b.ID).Last();

            OperationDetail operationDetail = new OperationDetail();
            operationDetail.EffectiveDate = operationSummeryDTO.EffectiveDate;
            operationDetail.CreateDate = DateTime.Now;
            operationDetail.CreatedBy = "Ashen(CEO)";
            operationDetail.Target = (int)operationSummeryDTO.Target;
            operationDetail.TimeSpan = (int)operationSummeryDTO.AllocatedTime;
            operationDetail.TimePeriod = operationSummeryDTO.TimePeriod;
            operationDetail.OperationListId = lastRecordID;

            _context.OperationDetails.Add(operationDetail);
            await _context.SaveChangesAsync();

            return Ok("Successfull");
            //return CreatedAtAction("GetOperationDetail", new { id = operationDetail.Id }, operationDetail);
        }


        // DELETE: api/OperationDetailsAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperationDetail(int id)
        {
            if (_context.OperationDetails == null)
            {
                return NotFound();
            }
            var operationDetail = await _context.OperationDetails.FindAsync(id);
            if (operationDetail == null)
            {
                return NotFound();
            }

            _context.OperationDetails.Remove(operationDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OperationDetailExists(int id)
        {
            return (_context.OperationDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
