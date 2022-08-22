using Workspace.Shared.Entities.SampleApp;

namespace sample.workspace.Server.Services
{
    public interface ISampleTodoService
    {
        Task<ServiceResponse<List<SampleTodo>>> GetAllTodos();
    }
}
