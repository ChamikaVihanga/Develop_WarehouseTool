
using Workspace.Shared.Entities.ResourceFacilities;

namespace Workspace.Client.Services.ResourceFacilityService
{
    public class ReFaRequestService : IReFaRequestService
    {
        private readonly HttpClient _http; 
        public ReFaRequestService(HttpClient http)
        {
            _http = http;
        }

        public List<ReFaRequest> ReFaRequests { get; set; }
        public string Message { get; set; } = "Loading products...";


        public async Task<ReFaRequest> CreateReFaRequest(ReFaRequest reFarequest)
        {
            var result = await _http.PostAsJsonAsync("api/ReFaRequest", reFarequest);
            var newReFaRequest = (await result.Content
                .ReadFromJsonAsync<ServiceResponse<ReFaRequest>>()).Data;
            return newReFaRequest;
        }

        public async Task GetReFaRequests()
        {
            var result = await _http
                .GetFromJsonAsync<ServiceResponse<List<ReFaRequest>>>("api/ReFaRequests/");
            ReFaRequests = result.Data;
            //CurrentPage = 1;
            //PageCount = 0;
            if (ReFaRequests.Count == 0)
                Message = "No products found.";
        }
    }
}
