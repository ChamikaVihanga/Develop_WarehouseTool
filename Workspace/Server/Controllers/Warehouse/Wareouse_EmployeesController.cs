using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Workspace.Server.Controllers.Warehouse
{
    [Route("api/[controller]")]
    [ApiController]
    public class Wareouse_EmployeesController : ControllerBase
    {
        private readonly WorkspaceDbContext _context;
        public Wareouse_EmployeesController(WorkspaceDbContext dbContext)
        {
            _context = dbContext;
        }


        [HttpGet, Route("333100")]
        public async Task<List<Vs_Employee>> GetWarehouseEmp()
        {
            return await _context.Vs_Employees.Where(a => a.CostCenterID == "333100").ToListAsync();
        }

        [HttpGet, Route("333100/units")]
        public async Task<List<Warehouse_OrganizationUnitDTO>> GetOrganization()
        {
            List<Vs_Employee>  vs_Employees = await _context.Vs_Employees.Where(a => a.CostCenterID == "333100").OrderBy(a=>a.OrganizationalUnitID).ToListAsync();
            List<string> OgIds = vs_Employees.Select(a => a.OrganizationalUnitID).Distinct().ToList();
            List<Warehouse_OrganizationUnitDTO> OrgUnitDTOs = new List<Warehouse_OrganizationUnitDTO>();    
            foreach(string OGid in OgIds)
            {
                OrgUnitDTOs.Add(new Warehouse_OrganizationUnitDTO { OrganizationUnitID = OGid, Name = vs_Employees
                    .Where(a => a.OrganizationalUnitID == OGid)
                    .Select(b => b.OrganizationalUnit).FirstOrDefault() });
            }
            return OrgUnitDTOs;
        }

        [HttpGet, Route("GetEmp")]
        public async Task<Vs_Employee> GetEmp(string SAP)
        {
            return await _context.Vs_Employees.Where(a => a.SAPNo == SAP).FirstOrDefaultAsync();
        }

        [HttpGet("ValidateSapNumber")]
        public async Task<ActionResult<bool>> ValidateSap(string EnteredSAP)
        {
            bool checkSAPExists = _context.Vs_Employees.Where(a => a.SAPNo == EnteredSAP).Any();

            return checkSAPExists;
        }
    }
}
