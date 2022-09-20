namespace admin.workspace.Server.Services.ReadOnly
{
    public interface ISapEmployeeExtraction
    {
        Task<ServiceResponse<List<SapEmployee>>> GetSapEmployees();
        Task<ServiceResponse<List<SapPlant>>> GetUpdatedSapPlants();
        Task<ServiceResponse<List<SapCostCenter>>> GetUpdatedSapCostCenters();
        Task<ServiceResponse<List<SapOrganizationalUnit>>> GetUpdatedSapOrganizationalUnits();
    }
}
