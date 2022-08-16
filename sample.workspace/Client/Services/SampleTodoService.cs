
using System.Net.Http.Json;
using Workspace.Shared.Entities.SampleApp;

namespace sample.workspace.Client.Services
{
    public class SampleTodoService : ISampleTodoService
    {
        private readonly HttpClient _http;

        public SampleTodoService(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<SampleTodo>> GetAllTodos()
        {
            //   throw new NotImplementedException();
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<SampleTodo>>>("api/SampleTodo");
            return result.Data;
        }
    }
}
