

namespace admin.workspace.Server.Services.ReadOnly
{
    public interface IEmployeeService
    {
        Task<ServiceResponse<List<Vs_Employee>>> GetAllVsEmployees();

    }

    
}
