using Workspace.Shared.Entities.ResourceFacilities;

namespace Workspace.Client.Services.ResourceFacilityService
{
    public interface IReFaRequestService
    {
        Task GetReFaRequests();
        Task<ReFaRequest> CreateReFaRequest(ReFaRequest reFarequest);

    }
}
