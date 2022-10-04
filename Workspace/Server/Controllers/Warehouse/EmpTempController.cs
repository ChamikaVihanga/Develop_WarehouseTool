using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workspace.Shared.Entities.Readonly;
using Workspace.Shared.Entities.Warehouse;

namespace Workspace.Server.Controllers.Warehouse
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpTempController : ControllerBase
    {
        private readonly WorkspaceDbContext _context;
        public EmpTempController(WorkspaceDbContext dbContext)
        {
            _context = dbContext;
        }


        [HttpGet, Route("333100")]
        public async Task<List<Vs_Employee>> GetWarehouseEmp()
        {
            return await _context.Vs_Employees.Where(a => a.CostCenterID == "333100").ToListAsync();
        }

        [HttpGet, Route("333100/units")]
        public async Task<List<OrganizationUnitDTO>> GetOrganization()
        {
            List<Vs_Employee>  vs_Employees = await _context.Vs_Employees.Where(a => a.CostCenterID == "333100").ToListAsync();
            List<string> OgIds = vs_Employees.Select(a => a.OrganizationalUnitID).Distinct().ToList();
            List<OrganizationUnitDTO> OrgUnitDTOs = new List<OrganizationUnitDTO>();    
            foreach(string OGid in OgIds)
            {
                OrgUnitDTOs.Add(new OrganizationUnitDTO { OrganizationUnitID = OGid, Name = vs_Employees
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
    }
}
