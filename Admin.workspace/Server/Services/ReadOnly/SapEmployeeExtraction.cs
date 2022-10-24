using System.Collections.Immutable;
using Workspace.Shared.Entities.Readonly;
using Workspace.Shared.Entities.ResourceFacilities;

namespace admin.workspace.Server.Services.ReadOnly
{
    public class SapEmployeeExtraction : ISapEmployeeExtraction
    {
        private WorkspaceDbContext _context;

        public SapEmployeeExtraction(WorkspaceDbContext context)
        {
            _context = context;
        }
        public async Task<List<SapEmployee>> GetSapEmployees()
        {
            var response = await _context.SapEmployee.ToListAsync();

            return response;
        }

        public async Task<List<SapPlant>> GetUpdatedSapPlants()
        {
            var PlantsFromSap = await _context.Vs_Employees.Select(x => x.CountryCode).Distinct().ToListAsync();

            //List<SapPlant> newPlants = new List<SapPlant>();

            foreach (var countryCode in PlantsFromSap)
            {
                SapPlant sapPlant = new();
                //sapPlant.Code = Int32.Parse(countryCode);
                sapPlant.Code = countryCode;
                bool exist = _context.SapPlants.Where(x => x.Code == countryCode).Any();
                if (!exist)
                {
                    _context.SapPlants.Add(sapPlant);
                }
            }

            await _context.SaveChangesAsync();


            var response = await _context.SapPlants.ToListAsync();

            return response;
        }


        public async Task<List<SapCostCenter>> GetUpdatedSapCostCenters() // Add foreign key

        {
            //List all distinct values of Cost Centers in SAP
            var CostCentersFromSap = await _context.Vs_Employees.Select(x => x.CostCenterID).Distinct().ToListAsync();


            foreach (var costCenter in CostCentersFromSap)
            {
                // Assign the values
                SapCostCenter? sapCostCenter = new();
                Vs_Employee? DetailFromSap = new();
                //sapCostCenter.Code = Int32.Parse(costCenter);
                sapCostCenter.Code = costCenter;
                DetailFromSap = await _context.Vs_Employees.Where(x => x.CostCenterID == costCenter).FirstOrDefaultAsync();
                sapCostCenter.Title = DetailFromSap.CostCenterName;

                //Check the Costcenter ID availability
                bool exist = _context.SapCostCenters.Where(x => x.Code == costCenter).Any();
                if (!exist)
                {
                    //Create new if not available
                    _context.SapCostCenters.Add(sapCostCenter);
                }
                await _context.SaveChangesAsync();

            }


            var response = await _context.SapCostCenters.ToListAsync();

            return response;
        }

        public async Task<List<SapOrganizationalUnit>> GetUpdatedSapOrganizationalUnits()
        {
            //List all distinct values of Organizational Unit in SAP
            var OrganizationalUnitsFromSap = await _context.Vs_Employees.Select(x => x.OrganizationalUnitID).Distinct().ToListAsync();


            foreach (var VsEmployeeOrganizationalUnit in OrganizationalUnitsFromSap)
            {

                //Create a SapOrganizationalUnit instant and Assign Organizational Unit
                SapOrganizationalUnit? sapOrganizationalUnit = new();
                sapOrganizationalUnit.Code = VsEmployeeOrganizationalUnit;

                //Create a Vs_Employee instant
                //Get data for that row from Vs Employee
                // Asign data
                Vs_Employee DetailFromVsEmployee = new();
                DetailFromVsEmployee = await _context.Vs_Employees.Where(x => x.OrganizationalUnitID == VsEmployeeOrganizationalUnit).FirstOrDefaultAsync();
                sapOrganizationalUnit.Code = DetailFromVsEmployee.OrganizationalUnitID;
                sapOrganizationalUnit.Title = DetailFromVsEmployee.OrganizationalUnit;


                // get primary key from SapCostcenters
                // Asign data
                var CostCenterGuid = await _context.SapCostCenters.Where(x => x.Code == DetailFromVsEmployee.OrganizationalUnitID).FirstOrDefaultAsync();
                //sapOrganizationalUnit.SapCostCenterId = CostCenterGuid.Id;

                //sapCostCenter.Code = Int32.Parse(costCenter);
                //sapOrganizationalUnit.Code = organizationalUnit;
                //SapCostCenter foreignKey = new();
                //foreignKey = await _context.SapCostCenters.Where(x=>x.Code == organizationalUnit).FirstOrDefault();
                //sapOrganizationalUnit.SapCostCenterId = foreignKey.Id;
                //sapOrganizationalUnit.Title = DetailFromSap.OrganizationalUnit;
                //sapOrganizationalUnit.SapCostCenterId =
                //Check the Organizational Unit ID availability
                bool exist = _context.SapOrganizationalUnits.Where(x => x.Code == VsEmployeeOrganizationalUnit).Any();
                if (!exist)
                {
                    //Create new if not available
                    _context.SapOrganizationalUnits.Add(sapOrganizationalUnit);
                }
                //else
                //{
                //    SapOrganizationalUnit ExixtingData = new();
                //     ExixtingData = await _context.SapOrganizationalUnits.Where(x => x.Code == organizationalUnit).FirstOrDefaultAsync();
                //    sapOrganizationalUnit.Id = ExixtingData.Id;
                //    _context.Entry(sapOrganizationalUnit).State = EntityState.Modified;
                //}
                await _context.SaveChangesAsync();

            }

            var response = await _context.SapOrganizationalUnits.ToListAsync();

            return response;
        }

    }
}
