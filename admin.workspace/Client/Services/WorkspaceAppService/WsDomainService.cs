using System.Net.Http.Json;
using System.Net;
using Workspace.Shared;
using Workspace.Shared.Entities.WorkspaceApp;

namespace admin.workspace.Client.Services.WorkspaceAppService
{
    public class WsDomainService : IWsDomainService
    {
        private readonly HttpClient _http;

        public WsDomainService(HttpClient http)
        {
            _http = http;
        }

        public async Task<WsDomain> GetWsDomains()
        {
            var response = await _http
                .GetFromJsonAsync<ServiceResponse<WsDomain>>("api/WsDomain");
            return response.Data;
        }
    }
}
