

namespace admin.workspace.Server.Services.ReadOnly
{
    public class EmployeeService : IEmployeeService
    {
        private WorkspaceDbContext _context;

        public EmployeeService(WorkspaceDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Vs_Employee>>> GetAllVsEmployees()
        {
            //throw new NotImplementedException();

            var response = new ServiceResponse<List<Vs_Employee>>
            {
                Data = await _context.Vs_Employees.ToListAsync()
            };

            return response;
        }
    }


}
