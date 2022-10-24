

namespace admin.workspace.Server.Services.ReadOnly
{
    public interface IEmployeeService
    {
        Task<List<Vs_Employee>> GetAllVsEmployees();

    }

    
}
