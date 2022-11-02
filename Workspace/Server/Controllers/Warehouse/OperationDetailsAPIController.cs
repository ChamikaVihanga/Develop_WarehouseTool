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
    public class OperationDetailsAPIController : ControllerBase
    {
        private readonly WorkspaceDbContext _context;

        public OperationDetailsAPIController(WorkspaceDbContext context)
        {
            _context = context;
        }

        // GET: api/OperationDetailsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Warehouse_OperationDetail>>> GetOperationDetails()
        {
            if (_context.Warehouse_OperationDetails == null)
            {
                return NotFound();
            }
            return await _context.Warehouse_OperationDetails.Include(x => x.OperationList).ToListAsync();            
        }

        // GET: api/OperationDetailsAPI/ValidateOperationCreateDate
        [HttpGet("ValidateOperationCreateDate")]
        public async Task<ActionResult<bool>> ValidateOperationCreateDate(int OperationListId , DateTime SelectedDate)             // in this didn't create a object call Warehouse_OperationDetail and didn't include 
        {                                                                                                                          //   a OperationList. Because get values from OperatonListId.
            bool checkOperationEffectiveDate = _context.Warehouse_OperationDetails                                                           //   if we assign to a bool variable extession should be .Any(); 
                .Where(a => a.OperationListId == OperationListId &&  a.EffectiveDate.Month == SelectedDate.Month)
                .Any();



            // make sure the month is not calculate for efficiency



            return checkOperationEffectiveDate;
        }


        // GET: api/OperationDetailsAPI/Active
        [HttpGet("Active")]
        public async Task<ActionResult<IEnumerable<Warehouse_OperationDetail>>> GetActiveOperationDetails()
        {
            if (_context.Warehouse_OperationDetails == null)
            {
                return NotFound();
            }
            return await _context.Warehouse_OperationDetails.Include(x => x.OperationList)
                .Where( e => e.EffectiveDate < DateTime.Today)
                .ToListAsync();

        }

        // GET: api/OperationDetailsAPI/Upcoming
        [HttpGet("Upcoming")]
        public async Task<ActionResult<IEnumerable<Warehouse_OperationDetail>>> GetUpcomingOperationDetails()
        {
            if (_context.Warehouse_OperationDetails == null)
            {
                return NotFound();
            }

            return await _context.Warehouse_OperationDetails.Include(x => x.OperationList)
                .Where(e => e.EffectiveDate > DateTime.Today)
                .ToListAsync();
        }

        [HttpGet("getOnlyOrgUnit")]
        public async Task<ActionResult<Warehouse_OperationDetail>> GetOrganizationUnit(int id)
        {
            if(_context.Warehouse_OperationDetails == null)
            {
                return NotFound();
            }

            var getOrgUnit = await _context.Warehouse_OperationDetails.Where(a => a.OperationListId == id).FirstOrDefaultAsync();

            if (getOrgUnit == null)
            {
                return NotFound();
            }
            return getOrgUnit;
        }

        // GET: api/OperationDetailsAPI/5
        [HttpGet("getEffectiveDate")]
        public async Task<ActionResult<Warehouse_OperationDetail>> GetOperationDetail(int id)
        {
            if (_context.Warehouse_OperationDetails == null)
            {
                return NotFound();
            }
            //Get data to _EditOperationTable.razor
            var operationDetail = await _context.Warehouse_OperationDetails
                .Include(a => a.OperationList)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (operationDetail == null)
            {
                return NotFound();
            }

            return operationDetail;
        }
        /// <summary>
        /// This API for display data to (UpdateTargetForOperation.razor) 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetListofOpDetails")]
        [HttpGet]
        public async Task<List<Warehouse_OperationDetail>> getOpList(int id)
        {
            var detailsList = await _context.Warehouse_OperationDetails.Where(a => a.OperationListId == id).ToListAsync();
            return detailsList;
        }

        /// <summary>
        /// Add new operation details to same List Id.
        /// </summary>
        /// <param name="operationDetail"></param>
        /// <returns></returns>
        //POST: api/OperationDetailsAPI/DetailsOnly
        [HttpPost, Route("DetailsOnly"), Authorize(Policy = "VSPolicy")]
        public async Task<string> PostDetails(Warehouse_OperationDetail operationDetail)
        {
            try
            {
                Warehouse_OperationDetail operationDetail1 = new Warehouse_OperationDetail();

                operationDetail1.TimePeriod = operationDetail.TimePeriod;
                operationDetail1.CreateDate = DateTime.Now;
                operationDetail1.TimeSpan = operationDetail.TimeSpan;
                operationDetail1.EffectiveDate = operationDetail.EffectiveDate;
                operationDetail1.Target = operationDetail.Target;
                operationDetail1.CreatedBy = User.Identity.Name;
                operationDetail1.OperationListId = operationDetail.OperationListId;
                operationDetail1.OrganizationUnit = operationDetail.OrganizationUnit;

                _context.Warehouse_OperationDetails.Add(operationDetail1);
                await _context.SaveChangesAsync();

                return "Successfully Updated";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }                       
        }

        [HttpGet, Route("getOperationList")]
        public async Task<List<Warehouse_OperationList>> getOperationList()
        {
            return _context.Warehouse_OperationLists.Include(a => a.Warehouse_OperationDetails).ToList();
        }       
        
        /// <summary>
        /// get inputs from (Operation.razor) and save data two seperate tables
        /// </summary>
        /// <param name="operationSummeryDTO"></param>
        /// <returns></returns>
        [HttpPost, Authorize(Policy ="VSPolicy")]
        public async Task<ActionResult<string>> PostOperationDetail(Warehouse_OperationSummeryDTO operationSummeryDTO)
        {           
                if (_context.Warehouse_OperationDetails == null)
                {
                    return Problem("Entity set 'WorkspaceDbContext.Warehouse_OperationDetails'  is null.");
                }

                Warehouse_OperationList opList = new Warehouse_OperationList();
                opList.Name = operationSummeryDTO.OperationName;
                opList.IsActive = true;

                _context.Warehouse_OperationLists.Add(opList);
                await _context.SaveChangesAsync();

                var lastRecordID = _context.Warehouse_OperationLists.Where(a => a.Name == operationSummeryDTO.OperationName).ToList().Select(b => b.Id).Last();

                Warehouse_OperationDetail operationDetail = new Warehouse_OperationDetail();
                operationDetail.EffectiveDate = operationSummeryDTO.EffectiveDate;
                operationDetail.CreateDate = DateTime.Now;
                operationDetail.CreatedBy = User.Identity.Name;
                operationDetail.Target = (int)operationSummeryDTO.Target;
                operationDetail.TimeSpan = (int)operationSummeryDTO.AllocatedTime;
                operationDetail.TimePeriod = operationSummeryDTO.TimePeriod;
                operationDetail.OperationListId = lastRecordID;
                operationDetail.OrganizationUnit = operationSummeryDTO.OrganizationUnit;

                _context.Warehouse_OperationDetails.Add(operationDetail);
                await _context.SaveChangesAsync();

                return Ok("Successfully Created");
        }

        [HttpPut, Authorize(Policy = "VSPolicy")]
        public async Task<ActionResult<List<Warehouse_OperationDetail>>> EditOperationDetails(Warehouse_OperationDetail operationDetail, int id)
        {
            var operationDetail1 = await _context.Warehouse_OperationDetails
                .Include(a => a.OperationList)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (operationDetail1 == null)
                return NotFound("Not Found");

            operationDetail1.Target = operationDetail.Target;
            operationDetail1.TimeSpan = operationDetail.TimeSpan;
            operationDetail1.TimePeriod = operationDetail.TimePeriod;
            operationDetail1.EffectiveDate = operationDetail.EffectiveDate;
            operationDetail1.CreateDate = DateTime.Now;
            operationDetail1.CreatedBy = User.Identity.Name;
            operationDetail1.OrganizationUnit = operationDetail.OrganizationUnit;
            operationDetail1.Id = id;

            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/OperationDetailsAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperationDetail(int id)
        {
            if (_context.Warehouse_OperationDetails == null)
            {
                return NotFound();
            }
            var operationDetail = await _context.Warehouse_OperationDetails.FindAsync(id);
            if (operationDetail == null)
            {
                return NotFound();
            }

            _context.Warehouse_OperationDetails.Remove(operationDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OperationDetailExists(int id)
        {
            return (_context.Warehouse_OperationDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }       
    }
}
