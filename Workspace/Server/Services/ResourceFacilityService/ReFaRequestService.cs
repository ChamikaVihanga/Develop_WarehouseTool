
using DataAccessLayer;
using Workspace.Shared.Entities.ResourceFacilities;

namespace Workspace.Server.Services.ResourceFacilityService
{
    public class ReFaRequestService : IReFaRequestService
    {
        private readonly WorkspaceDbContext _context;
        //private readonly IHttpContextAccessor _httpContextAccessor;

        public ReFaRequestService(WorkspaceDbContext context)
        {
            _context = context;
            //_httpContextAccessor = httpContextAccessor;
        }

        public Task<List<ReFaRequest>> DeleteReFaRequestAsync(Guid reFaRequestId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ReFaRequest>> GetReFaRequestAsync(Guid reFaRequestId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ReFaRequest>> GetReFaRequestsAsync()
        {
            var response = await _context.ReFaRequests.ToListAsync();

            return response;
        }

        public Task<List<ReFaRequest>> UpdateReFaRequest(ReFaRequest reFaRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<ReFaRequest> CreateReFaRequest(ReFaRequest reFaRequest)
        {
            _context.ReFaRequests.Add(reFaRequest);
            await _context.SaveChangesAsync();
            return  reFaRequest ;
        }
    }
}
