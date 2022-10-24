
using Workspace.Shared.Entities.ResourceFacilities;

namespace Workspace.Server.Services.ResourceFacilityService
{
    public interface IReFaRequestService
    {
        Task<List<ReFaRequest>> GetReFaRequestsAsync();
        Task<List<ReFaRequest>> GetReFaRequestAsync(Guid reFaRequestId);
        Task<ReFaRequest> CreateReFaRequest(ReFaRequest reFaRequest);
        Task<List<ReFaRequest>> UpdateReFaRequest(ReFaRequest reFaRequest);
        Task<List<ReFaRequest>> DeleteReFaRequestAsync(Guid reFaRequestId);
    }
}
