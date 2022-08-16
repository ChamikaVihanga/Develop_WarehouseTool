
using Workspace.Shared.Entities.SampleApp;

namespace sample.workspace.Server.Services
{
    public class SampleTodoService : ISampleTodoService
    {
        private readonly WorkspaceDbContext _context;

        public SampleTodoService(WorkspaceDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<SampleTodo>>> GetAllTodos()
        {
            var response = new ServiceResponse<List<SampleTodo>>();
            var todos = await _context.SampleTodos.ToListAsync();
            response.Data = todos;

            return response;
        }
    }
}
