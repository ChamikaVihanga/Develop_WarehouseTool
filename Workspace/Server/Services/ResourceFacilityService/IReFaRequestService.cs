
using Workspace.Shared.Entities.ResourceFacilities;

namespace Workspace.Server.Services.ResourceFacilityService
{
    public interface IReFaRequestService
    {
        Task<ServiceResponse<List<ReFaRequest>>> GetReFaRequestsAsync();
        Task<ServiceResponse<List<ReFaRequest>>> GetReFaRequestAsync(Guid reFaRequestId);
        Task<ServiceResponse<ReFaRequest>> CreateReFaRequest(ReFaRequest reFaRequest);
        Task<ServiceResponse<List<ReFaRequest>>> UpdateReFaRequest(ReFaRequest reFaRequest);
        Task<ServiceResponse<List<ReFaRequest>>> DeleteReFaRequestAsync(Guid reFaRequestId);



    }
}
