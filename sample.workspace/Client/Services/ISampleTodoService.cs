using Workspace.Shared.Entities.SampleApp;

namespace sample.workspace.Client.Services
{
    public interface ISampleTodoService
    {
        Task<List<SampleTodo>> GetAllTodos();
    }
}
