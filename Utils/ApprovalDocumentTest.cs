

using Workspace.Shared.Entities.ApprovalDynamicPaths;

namespace UtilLib
{
    public class ApprovalDocumentTest
    {
        public WorkspaceDbContext _context;

        public ApprovalDocumentTest(WorkspaceDbContext workspaceDbContext)
        {
            _context = workspaceDbContext;
        }

        public async Task<List<ApprovalDocuments>> ApprovalDocuments()
        {
            return await _context.apd_approvalDocuments.ToListAsync();
        }

    }
}