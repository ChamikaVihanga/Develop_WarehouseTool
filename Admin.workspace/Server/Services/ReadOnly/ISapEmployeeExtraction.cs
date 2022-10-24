namespace admin.workspace.Server.Services.ReadOnly
{
    public interface ISapEmployeeExtraction
    {
        Task<List<SapEmployee>> GetSapEmployees();
        Task<List<SapPlant>> GetUpdatedSapPlants();
        Task<List<SapCostCenter>> GetUpdatedSapCostCenters();
        Task<List<SapOrganizationalUnit>> GetUpdatedSapOrganizationalUnits();
    }
}
